using InternetTracker.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InternetTracker.Logic
{
    public class TotalTrackingService
    {
        private readonly AppDbContext _context;
        private readonly HttpClient _client;

        public TotalTrackingService(AppDbContext context,
                                    HttpClient client)
        {
            _context = context;
            _client = client;
        }

        public async Task VerifyAllAsync(TimeSpan? timeout = null)
        {
            if (timeout is null)
                timeout = TimeSpan.FromSeconds(8);

            DateTime start = DateTime.Now;
            try
            {
                start = DateTime.Now;
                await Task.WhenAny(KillerDelayAsync(timeout.Value), VerifyInternetAsync());
            }
            catch (Exception e)
            {
                var end = DateTime.Now;
                await LogAsync(new FailedLog
                {
                    ErrorMessage = e.Message,
                    Elapsed = (end - start).TotalMilliseconds,
                    TimeStamp = start
                });
            }
        }

        public async Task KillerDelayAsync(TimeSpan time)
        {
            await Task.Delay(time);
            throw new Exception($"Timed out for {time}");
        }

        public async Task VerifyInternetAsync()
        {
            var res = await _client.GetAsync("nettest");
            res.EnsureSuccessStatusCode();
        }

        public async Task LogAsync(FailedLog log)
        {
            await _context.FailedLogs.AddAsync(log);
            await _context.SaveChangesAsync();
        }


    }
}
