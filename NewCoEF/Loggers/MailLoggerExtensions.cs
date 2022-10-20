using Microsoft.Extensions.DependencyInjection;
using NewCoEF;
using NewCoEF.Loggers;

namespace Microsoft.Extensions.Logging
{
    public static class MailLoggerExtensions
    {
        public static ILoggingBuilder AddMail(this ILoggingBuilder builder)
        {
            builder.Services.AddSingleton<ILoggerProvider, MailLoggerProvider>();
            return builder;
        }
    }
}
