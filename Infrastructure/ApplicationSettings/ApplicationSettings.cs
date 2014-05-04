using System;
using System.Globalization;
using System.Linq;
using System.Configuration;

namespace Infrastructure.ApplicationSettings
{
    public class ApplicationSettings
    {
        public string ConnectionString
        {
            get { return GetSetting<string>("ConnectionString"); }
        }

        private T GetSetting<T>(string setting)
        {
            if (!ConfigurationManager.AppSettings.AllKeys.Contains(setting))
            {
                throw new ApplicationException(string.Format("Setting '{0}' not found.", setting));
            }

            var fetchedValue = ConfigurationManager.AppSettings[setting];

            return (T) Convert.ChangeType(fetchedValue, typeof (T), CultureInfo.InvariantCulture);
        }
    }
}
