using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager managerF = new Manager {Name = "Furkan", Salary = 1000};
            Manager managerS = new Manager {Name = "Salih", Salary = 900};
            Worker ali = new Worker {Name = "Ali", Salary = 600};
            Worker ayse = new Worker {Name = "Ayşe", Salary = 500};

            managerF.Subordinates.Add(managerS);
            managerS.Subordinates.Add(ali);
            managerS.Subordinates.Add(ayse);

            OrganisationalStructure organisationalStructure = new OrganisationalStructure(managerF);
            PayrolVisitor payrolVisitor = new PayrolVisitor();
            PayriseVisitor payriseVisitor = new PayriseVisitor();

            organisationalStructure.Accept(payriseVisitor);
            organisationalStructure.Accept(payrolVisitor);

            Console.ReadLine();
        }
    }

    class OrganisationalStructure
    {
        public EmployeeBase Employee;

        public OrganisationalStructure(EmployeeBase firstEmployee)
        {
            Employee = firstEmployee;
        }

        public void Accept(VisitorBase visitor)
        {
            Employee.Accept(visitor);
        }
    }

    abstract class EmployeeBase
    {
        public abstract void Accept(VisitorBase visitor);
        public string Name { get; set; }
        public decimal Salary { get; set; }

    }

    class Manager:EmployeeBase
    {
        public Manager()
        {
            Subordinates = new List<EmployeeBase>();
        }

        public List<EmployeeBase> Subordinates { get; set; }
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);

            foreach (var employeeBase in Subordinates)
            {
                employeeBase.Accept(visitor);
            }
        }
    }

    class Worker:EmployeeBase
    {
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
        }
    }

    abstract class VisitorBase
    {
        public abstract void Visit(Worker worker);
        public abstract void Visit(Manager manager);
    }

    class PayrolVisitor:VisitorBase
    {

        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} paid {1}",worker.Name,worker.Salary);
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} paid {1}",manager.Name,manager.Salary);
        }
    }

    class PayriseVisitor:VisitorBase
    {

        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} salary increased to {1}",worker.Name,worker.Salary*(decimal)1.1);
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} salary increased to {1}",manager.Name,manager.Salary*(decimal)1.3);
        }
    }
}
