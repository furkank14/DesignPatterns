using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Save();

            Console.ReadLine();

        }
    }

    class Logging:ILogging
    {
        public void Log()
        {
            Console.WriteLine("Logged");
        }
    }

    internal interface ILogging
    {
        void Log();
    }

    class Caching:ICaching
    {
        public void Cache()
        {
            Console.WriteLine("Cached");
        }
    }

    internal interface ICaching
    {
        void Cache();
    }

    class Authorize:IAuthorize
    {
        public void CheckUser()
        {
            Console.WriteLine("User Check");
        }
    }

    internal interface IAuthorize
    {
        void CheckUser();
    }

    class CustomerManager
    {
        private CrossCuttingConcernsFacade _crossCuttingConcernsFacade;
        public CustomerManager()
        {
            _crossCuttingConcernsFacade = new CrossCuttingConcernsFacade();
        }

        public void Save()
        {
            _crossCuttingConcernsFacade.Caching.Cache();
            _crossCuttingConcernsFacade.Authorize.CheckUser();
            _crossCuttingConcernsFacade.Logging.Log();
            Console.WriteLine("Saved");
        }
    }

    class CrossCuttingConcernsFacade
    {
        public ILogging Logging;
        public IAuthorize Authorize;
        public ICaching Caching;

        public CrossCuttingConcernsFacade()
        {
            Authorize = new Authorize();
            Caching = new Caching();
            Logging = new Logging();
        }
    }
}
