using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace InternetTracker.Core
{

    [Index(nameof(TimeStamp))]
    public class FailedLog
    {

        public int Id { get; set; }

        [Required]
        public DateTime TimeStamp { get; set; }

        [Required]
        public double Elapsed { get; set; }

        public string ErrorMessage { get; set; }

    }
}
