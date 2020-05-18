using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.CreditCalculatorBase=new After2010CreditCalculator();
            customerManager.SaveCredit();

            customerManager.CreditCalculatorBase = new Before2010CreditCalculator();
            customerManager.SaveCredit();

            Console.ReadLine();

        }
    }

    abstract class CreditCalculatorBase
    {
        public abstract void Calculate();
    }

    class Before2010CreditCalculator:CreditCalculatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("Before 2010 caltulated");
        }
    }

    class After2010CreditCalculator : CreditCalculatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("After 2010 caltulated");
        }
    }

    class CustomerManager
    {
        public CreditCalculatorBase CreditCalculatorBase { get; set; }
        public void SaveCredit()
        {
            Console.WriteLine("Customer Manager Business");
            CreditCalculatorBase.Calculate();
        }
    }
}
