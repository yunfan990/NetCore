using System;
using System.IO;
using log4net;
using log4net.Repository;
using log4net.Config;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ILoggerRepository repository = log4net.LogManager.CreateRepository("NETCoreRepository");
            XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));
            BasicConfigurator.Configure(repository);





            ILog log = log4net.LogManager.GetLogger(repository.Name, "NETCorelog4net");
            
           
            log.Info("11111");
          
            Console.WriteLine("Hello World!");
        }
    }
}
