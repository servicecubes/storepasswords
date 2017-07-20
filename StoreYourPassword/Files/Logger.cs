using System;
using System.IO;

namespace StoreYourPassword
{
    public class Logger
    {
        

        public void log(string logText)
        {            
            File.AppendAllText(@"log.txt", DateTime.Now + " - " + logText + "\n");            
        }
    }
}

