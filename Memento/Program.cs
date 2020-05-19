using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book =new Book
            {
                Isbn = "123456789",
                Title = "Sefiller",
                Author = "Victor Hugo"
            };
            book.ShowBook();
            CareTaker historyCareTaker = new CareTaker();
            historyCareTaker.Memento = book.CreateUndo();
            book.Isbn = "271457896";
            book.Title = "SEFİLLER";
            book.ShowBook();

            book.RestoreFromUndo(historyCareTaker.Memento);
            book.ShowBook();

            Console.ReadLine();

        }
    }

    class Book
    {
        private string _title;
        private string _author;
        private string _isbn;
        private DateTime _lastEdited;

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                SetLastEdited();
            }
        }

        public string Author
        {
            get => _author;
            set
            {
                _author = value;
                SetLastEdited();
            }

        }

        public string Isbn
        {
            get => _isbn;
            set
            {
                _isbn = value;
                SetLastEdited();
            }

        }

        private void SetLastEdited()
        {
            _lastEdited = DateTime.UtcNow;
        }

        public Memento CreateUndo()
        {
            return new Memento(_isbn,_author,_title,_lastEdited);
        }

        public void RestoreFromUndo(Memento memento)
        {
            _title = memento.Title;
            _author = memento.Author;
            _lastEdited = memento.LastEdited;
            _isbn = memento.Isbn;
        }

        public void ShowBook()
        {
            Console.WriteLine("{0},{1},{2},{3}",Isbn,Title,Author,_lastEdited);
        }
    }

    class Memento
    {
        public string Title { get; set; }
        public string Isbn { get; set; }
        public string Author { get; set; }
        public DateTime LastEdited { get; set; }

        public Memento(string isbn, string author, string title, DateTime lastEdited)
        {
            Isbn = isbn;
            Title = title;
            Author = author;
            LastEdited = lastEdited;
        }
    }

    class CareTaker
    {
        public Memento Memento { get; set; }
    }
}
