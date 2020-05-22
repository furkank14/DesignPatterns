using System;
using Ninject;

namespace DependenceInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<IProductDal>().To<ProductDal>().InSingletonScope();
            ProductManager productManager = new ProductManager(kernel.Get<IProductDal>());
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
