using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            var personelCar = new PersonalCar { Make = "BMW", Model = "3.20", HirePrice = 2500 };

            SpecialOffer specialOffer = new SpecialOffer(personelCar);
            specialOffer.DiscountPercentege = 50;

            Console.WriteLine(personelCar.HirePrice);
            Console.WriteLine(specialOffer.HirePrice);
            Console.ReadLine();

        }
    }

    abstract class CarBase
    {
        public abstract string Make { get; set; }
        public abstract string Model { get; set; }
        public abstract decimal HirePrice { get; set; }
    }

    class PersonalCar : CarBase
    {
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }

    class CommercialCar : CarBase
    {
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }

    abstract class CarDecoratorBase : CarBase
    {
        private CarBase _carBase;

        protected CarDecoratorBase(CarBase carBase)
        {
            _carBase = carBase;
        }
    }

    class SpecialOffer : CarDecoratorBase
    {
        public int DiscountPercentege { get; set; }

        private readonly CarBase _carBase;

        public SpecialOffer(CarBase carBase) : base(carBase)
        {
            _carBase = carBase;
        }

        public override string Make { get; set; }
        public override string Model { get; set; }

        public override decimal HirePrice
        {
            get { return _carBase.HirePrice-_carBase.HirePrice*DiscountPercentege/100; }
            set {}
        }
    }
}
