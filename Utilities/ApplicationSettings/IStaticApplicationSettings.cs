using System;

namespace Utilities.ApplicationSettings
{
    public interface IStaticApplicationSettings
    {
        TimeSpan PasswordResetExpirationPeriodInMinutes { get; }
    }
}
