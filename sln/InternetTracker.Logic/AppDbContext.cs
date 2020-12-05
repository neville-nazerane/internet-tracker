using InternetTracker.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetTracker.Logic
{

    public class AppDbContext : DbContext
    {

        public DbSet<FailedLog> FailedLogs { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


    }
}
