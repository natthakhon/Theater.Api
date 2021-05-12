using NLog;
using NLog.Config;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Theater.API.NLog
{
    public class ConfigNlog
    {
        private string env;
        private LoggingConfiguration config = null;
        public ConfigNlog(string env)
        {
            this.env = env;
        }

        public LoggingConfiguration GetLogConfig()
        {
            if (this.env == "Development")
            {
                config = new LoggingConfiguration();
                var logfile = new LogFileDev();
                config.AddTarget(logfile.Name,logfile);
                config.LoggingRules.Add(logfile.LoggingRule(LogLevel.Debug));
                return config;
            }
            throw new InvalidOperationException("Cannot generate config for NLog");
        }

        public string Environment
        {
            get { return this.env; }
        }


    }
}
