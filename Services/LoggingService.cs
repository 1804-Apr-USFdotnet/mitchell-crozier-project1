using System;
using NLog;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceInterfaces;

namespace Services
{
    public class LoggingService : ILoggingService
    {
        private ILogger nlogger = LogManager.GetCurrentClassLogger();
        public LoggingService()
        {
            var config = new NLog.Config.LoggingConfiguration();
            //comment for a commit change
            var logfile = new NLog.Targets.FileTarget() { FileName = "file.txt", Name = "logfile" };
            var logconsole = new NLog.Targets.ConsoleTarget() { Name = "logconsole" };

            config.LoggingRules.Add(new NLog.Config.LoggingRule("*", LogLevel.Info, logconsole));
            config.LoggingRules.Add(new NLog.Config.LoggingRule("*", LogLevel.Debug, logfile));

            LogManager.Configuration = config;

        }
        public void Log(Exception e)
        {
            nlogger.Log(LogLevel.Info, e);
        }

        public void Log(string message)
        {
            nlogger.Log(LogLevel.Info, message);
        }

    }
}
