using System;

namespace Infrastructure.ApplicationSettings
{
    public interface IStaticApplicationSettings
    {
        TimeSpan PasswordResetExpirationPeriodInMinutes { get; }
    }
}
