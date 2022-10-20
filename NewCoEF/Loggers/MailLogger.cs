using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace NewCoEF.Loggers
{
    public class MailLogger : ILogger
    {
        private string category;
 
        public MailLogger(string category)
        {
            this.category = category;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            var values = state as IEnumerable<KeyValuePair<string, object>>;

            string json = JsonConvert.SerializeObject(values);

            string message = formatter(state, exception);

            #region send log

            var log = new Log();
            log.Id = Guid.NewGuid();
            log.DateLog = DateTime.Now;
            log.Category = logLevel.ToString();
            log.Message = message;

            //SEND MAIL
            //https://blog.elmah.io/how-to-send-emails-from-csharp-net-the-definitive-tutorial/


            #endregion
        }
    }
}
