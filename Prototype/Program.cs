﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer
            {
                FirstName = "Furkan",
                Lastname = "Karataş",
                City = "Kocaeli",
                Id = 1
            };

            Customer customer2 = (Customer) customer.Clone();
            customer2.FirstName = "Salih";

            Console.WriteLine(customer.FirstName);
            Console.WriteLine(customer2.FirstName);

            Console.ReadLine();
            
        }
    }

    public abstract class Person
    {
        public abstract Person Clone();

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
    }

    public class Customer : Person
    {
        public string City { get; set; }

        public override Person Clone()
        {
            return (Person) MemberwiseClone();
        }
    }

    public class Employee : Person
    {
        public string Salary { get; set; }

        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }
}
