using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();
            VicePresident vicePresident = new VicePresident();
            President president = new President();

            manager.SetSuccessor(vicePresident);
            vicePresident.SetSuccessor(president);

            Expense expense = new Expense {Detail = "Salatalık",Amount = 1100};

            manager.HandlerExpence(expense);
            Console.ReadLine();

        }
    }

    class Expense
    {
        public string Detail { get; set; }
        public decimal Amount { get; set; }

    }

    abstract class ExpenseHandlerBase
    {
        protected ExpenseHandlerBase Successor;
        public abstract void HandlerExpence(Expense expense);

        public void SetSuccessor(ExpenseHandlerBase successor)
        {
            Successor = successor;
        }

    }

    class Manager : ExpenseHandlerBase
    {
        public override void HandlerExpence(Expense expense)
        {
            if (expense.Amount<=100)
            {
                Console.WriteLine("Manager handler the expense");
            }
            else if(Successor!=null)
            {
                Successor.HandlerExpence(expense);
            }
        }
    }

    class VicePresident : ExpenseHandlerBase
    {
        public override void HandlerExpence(Expense expense)
        {
            if (expense.Amount > 100 && expense.Amount<=1000)
            {
                Console.WriteLine("Vice President handler the expense");
            }
            else if (Successor != null)
            {
                Successor.HandlerExpence(expense);
            }
        }
    }

    class President : ExpenseHandlerBase
    {
        public override void HandlerExpence(Expense expense)
        {
            if (expense.Amount > 1000)
            {
                Console.WriteLine("President handler the expense");
            }
            else if (Successor != null)
            {
                Successor.HandlerExpence(expense);
            }
        }
    }
}
