using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using NLog.Targets;
using System;
using Theater.API.NLog;

namespace Theater.API.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestLog()
        {
            ConfigNlog configNlog = new ConfigNlog("Development");
            LogManager.Configuration = configNlog.GetLogConfig();
            var logger = LogManager.GetCurrentClassLogger();
            Guid guid = Guid.NewGuid();
            logger.Error(guid.ToString());
            FileTarget target = (FileTarget)logger.Factory.Configuration.FindTargetByName(LogFileDev.FILENAME);
            string[] lines = System.IO.File.ReadAllLines(target.FileName.Render(new LogEventInfo()).Replace(@"/", @"\"));
            bool found = false;
            foreach (string line in lines)
            {
                if (line.Contains(guid.ToString()))
                {
                    found = true;
                    break;
                }
            }
            Assert.IsTrue(found);
        }
    }
}
