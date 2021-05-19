using NLog;
using NLog.Config;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.Text;

namespace Theater.NLogger
{
    public class LogFileDev : FileTarget
    {
        public static readonly string FILENAME = "LogFileDev";
        public LogFileDev()
        {
            this.FileName = "${basedir}/logs/${shortdate}.log";
            this.Layout = "${longdate}|${event-properties:item=EventId_Id}|${uppercase:${level}}|${logger}|${message} ${exception:format=tostring}";
            this.Name = LogFileDev.FILENAME;
        }

        public LoggingRule LoggingRule(LogLevel level)
        {
            return new LoggingRule("*", level, this);
        }
    }
}
