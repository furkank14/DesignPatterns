using System;

namespace DependenceInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new ProductDal());
            productManager.Save();

            Console.ReadLine();

        }
    }

    interface IProductDal
    {
        void Save();
    }

    class ProductDal:IProductDal
    {
        public void Save()
        {
            Console.WriteLine("Saved by ef");
        }
    }

    class ProductManager
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Save()
        {
            _productDal.Save();
        }
    }
}
