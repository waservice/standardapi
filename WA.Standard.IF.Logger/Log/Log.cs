using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;
using log4net.Config;

namespace WA.Standard.IF.Logger.Log
{
    public class Log
    {
        static Log()
        {
            XmlConfigurator.Configure();
            RootLogger = LogManager.GetLogger("root");
        }

        public static ILog RootLogger
        {
            get;
            private set;
        }

        public static ILog GetLogger(string name)
        {
            return LogManager.GetLogger(name);
        }

        public static ILog GetLogger(Type type)
        {
            return LogManager.GetLogger(type);
        }
    }
}