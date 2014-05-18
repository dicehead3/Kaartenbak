using System;

namespace Utilities.ApplicationSettings
{
    public class StaticApplicationSettings : IStaticApplicationSettings
    {
        public TimeSpan PasswordResetExpirationPeriodInMinutes
        {
            get { return new TimeSpan(0, 30, 0); }
        }
    }
}
