using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowLevelDesign.DesignPatterns.Creational.Singelton
{
    class smth
    {
        public static smth _instance;
        public string _connString {  get; set; }


        public smth(string connString)
        {
            _connString = connString;
        }

        public static smth Instance(string dbString)
        {
            if(_instance == null)
            {
                _instance = new smth(dbString);
            }
            return _instance;
        }
    }

    class Logger
    {
        static Logger _instance;

        public static Logger GetLogger()
        {
            if (_instance == null)
            {
                _instance = new Logger();
                _instance.Log("Deafult Logger Instantaited");
            }
            return _instance;
        }

        protected Logger()
        {
            Log("Deafult Logger Instantaited");
        }

        public virtual void Log(string message)
        {
            Console.WriteLine("[ Deafult Logger ] : " + message);
        }

        public static void SetInstance(Logger logger)
        {
            _instance = logger;
        }
    };

    class FileLogger : Logger
    {
        public override void Log(string message)
        {
            Console.WriteLine("[  File Logger   ] : " + message);
        }
    }

}


/*

there must be exactly one instance of a class, and it must be accessible to clients from a well-known access point.







| Aspect                  | Summary                                                                |
| ----------------------- | ---------------------------------------------------------------------- |
| **Good for**            | Shared global resources (DB, logger, config)                           |
| **Don’t use for**       | Business models, temporary objects, UI controllers                     |
| **Be careful of**       | Thread safety, passing params, overusing like a global                 |
| **Better alternatives** | Dependency Injection, Service Container (used in ASP.NET, Spring, etc) |




NEVER cache Singleton instance in a variable if you expect it to be replaceable later
Always use Logger.GetLogger() when calling it
This ensures you always get the LATEST active Singleton 
 
 */