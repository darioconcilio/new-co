using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewCoEF.Loggers
{
    public class Log
    {
        public Log()
        {

        }

        [Key]
        public Guid Id { get; set; }
        public string Category { get; set; }
        public DateTime DateLog { get; set; }

        public string Message { get; set; }
    }
}
