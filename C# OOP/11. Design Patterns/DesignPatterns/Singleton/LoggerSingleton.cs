using System;
using System.Collections.Generic;
using System.Text;

namespace Singleton
{
    public sealed class LoggerSingleton
    {
        private static LoggerSingleton instance;

        private LoggerSingleton()
        {

        }

        public static LoggerSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (instance)
                    {
                        if (instance == null)
                        {
                            instance = new LoggerSingleton();
                        }
                    }
                }
                return instance
            }
        }
    }
}
