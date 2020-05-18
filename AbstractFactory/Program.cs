using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager _productManager= new ProductManager(new Factory2());
            _productManager.GetAll();
            Console.ReadLine();
        }
    }

    public abstract class Logging
    {
        public abstract void Log(string message);
    }

    public class Log4NetLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged by Log4Net");
        }
    }

    public class NLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged by NLogger");
        }
    }

    public abstract class Caching
    {
        public abstract void Cache(string data);
    }

    public class MemCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cache with MemCache");
        }
    }

    public class RedisCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cache with RedisCache");
        }
    }

    public abstract class CrossCuttingConcernFactory
    {
        public abstract Logging CreateLogger();
        public abstract Caching CreateCaching();
    }

    public class Factory1 : CrossCuttingConcernFactory
    {
        public override Logging CreateLogger()
        {
            return new Log4NetLogger();
        }

        public override Caching CreateCaching()
        {
            return new RedisCache();
        }
    }

    public class Factory2 : CrossCuttingConcernFactory
    {
        public override Logging CreateLogger()
        {
            return new NLogger();
        }

        public override Caching CreateCaching()
        {
            return new RedisCache();
        }
    }

    public class ProductManager
    {
        private CrossCuttingConcernFactory _crossCuttingConcernFactory;

        private Logging _logging;
        private Caching _caching;

        public ProductManager(CrossCuttingConcernFactory cuttingConcernFactory)
        {
            _crossCuttingConcernFactory = cuttingConcernFactory;
            _logging = _crossCuttingConcernFactory.CreateLogger();
            _caching = _crossCuttingConcernFactory.CreateCaching();
        }

        public void GetAll()
        {
            _logging.Log("Logged");
            _caching.Cache("Data");
            Console.WriteLine("product Listed");
        }
    }
}
