using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Employe Furkan = new Employe();
            Furkan.Name = "Furkan Karataş";

            Employe Emre = new Employe();
            Emre.Name = "Emre";
            Employe Ahmet = new Employe();
            Ahmet.Name = "Ahmet";
            Employe Ali = new Employe();
            Ali.Name = "Ali";
            Employe veli = new Employe();
            veli.Name = "veli";
            Employe ismail = new Employe();
            ismail.Name = "İsmail";

            Contractor Ayse = new Contractor();
            Ayse.Name = "Ayşe";

            Furkan.AddSubOrdinate(Emre);
            Furkan.AddSubOrdinate(veli);
            Furkan.AddSubOrdinate(ismail);
            Furkan.AddSubOrdinate(Ahmet);
            Furkan.AddSubOrdinate(Ali);

            Ahmet.AddSubOrdinate(Ali);
            Ahmet.AddSubOrdinate(ismail);

            ismail.AddSubOrdinate(veli);
            Ali.AddSubOrdinate(Ayse);


            Console.WriteLine(Furkan.Name);
            foreach (Employe manager in Furkan)
            {
                Console.WriteLine("|__{0}",manager.Name);

                foreach (IPerson person in manager)
                {
                    Console.WriteLine("   |__{0}", person.Name);

                }

            }


            Console.ReadLine();

        }
    }

    interface IPerson
    {
        string Name { get; set; }
    }

    class Contractor:IPerson
    {

        public string Name { get; set; }
    }

    class Employe:IPerson,IEnumerable<IPerson>
    {
        List<IPerson> _subOrdinates = new List<IPerson>();

        public void AddSubOrdinate(IPerson person)
        {
            _subOrdinates.Add(person);
        }
        public void RemoveSubOrdinate(IPerson person)
        {
            _subOrdinates.Remove(person);
        }

        public IPerson GetSubOrdinate(int index)
        {
            return _subOrdinates[index];
        }

        public string Name { get; set; }
        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var subOrdinate in _subOrdinates)
            {
                yield return subOrdinate;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
