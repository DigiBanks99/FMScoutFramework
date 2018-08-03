using System.Configuration;

namespace FMScoutFramework
{
    public class FMScoutFrameworkConfigurationManager
    {
        private static FMScoutFrameworkConfigurationManager _instance = null;

        public static FMScoutFrameworkConfigurationManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new FMScoutFrameworkConfigurationManager();

                return _instance;
            }
        }

        public string ProcessName
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("processName");
            }
        }
    }
}
