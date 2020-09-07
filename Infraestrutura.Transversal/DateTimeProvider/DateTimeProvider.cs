using System;

/// <summary>
/// https://github.com/akazemis/TestableDateTimeProvider
/// </summary>
namespace Infraestrutura.Transversal
{
    public class DateTimeProvider : IDateTimeProvider
    {
        private static readonly Lazy<DateTimeProvider> _lazyInstance = new Lazy<DateTimeProvider>(() => new DateTimeProvider());

        public static DateTimeProvider Instance { get { return _lazyInstance.Value; } }

        private readonly Func<DateTime> _defaultCurrentFunction = () => DateTime.UtcNow;

        public DateTime GetNow()
        {
            return DateTimeProviderContext.Current == null
                ? _defaultCurrentFunction.Invoke()
                : DateTimeProviderContext.Current.Context;
        }
    }
}