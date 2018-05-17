using AnayaRojo.Tools.Logs.Models;
using System.Configuration;

namespace AnayaRojo.Tools.Logs.Implementation
{
    public abstract class BaseLog
    {
        private LogConfigurationModel mObjConfiguration;

        public LogConfigurationModel Configuration
        {
            get 
            {
                if (mObjConfiguration == null)
                {
                    mObjConfiguration = GetConfiguration();
                }
                return mObjConfiguration;
            }
        }

        protected LogConfigurationModel GetConfiguration()
        {
            return ConfigurationManager.GetSection("logConfiguration") as LogConfigurationModel;
        }
    }
}
