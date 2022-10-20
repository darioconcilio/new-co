using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;

namespace NewCoEF.Loggers
{
    [ProviderAlias("Mail")]
    public class MailLoggerProvider : ILoggerProvider
    {
        private readonly ConcurrentDictionary<string, MailLogger> loggers = new ConcurrentDictionary<string, MailLogger>();

        public ILogger CreateLogger(string categoryName)
        {
            return loggers.GetOrAdd(categoryName, c => new MailLogger(c));
        }

        public void Dispose()
        {
            loggers.Clear();
        }
    }
}
