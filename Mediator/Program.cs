using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator = new Mediator();
            Teacher teacher = new Teacher(mediator);
            teacher.Name = "Furkan";
            mediator.Teacher = teacher;
            Student student = new Student(mediator);
            student.Name = "Ali";
            Student student2 = new Student(mediator);
            student2.Name = "Salih";

            mediator.Students= new List<Student>{student2,student};

            teacher.SendNewImageUrl("image1.jpg");
            teacher.RecieveQuestion("Is it true",student2);

            Console.ReadLine();
            
        }

        
    }

    abstract class CourseMember
    {
        protected Mediator Mediator;

        public CourseMember(Mediator mediator)
        {
            Mediator = mediator;
        }
    }

    class Teacher:CourseMember
    {

        public Teacher(Mediator mediator) : base(mediator)
        {
        }

        public string Name { get; set; }

        public void RecieveQuestion(string question, Student student)
        {
            Console.WriteLine("Teacher recieved question from {0},{1}",student.Name,question);
        }

        public void SendNewImageUrl(string url)
        {
            Console.WriteLine("Teacher changed slide : {0}",url);
            Mediator.UpdateImage(url);
        }

        public void AnswerQuestion(string answer, Student student)
        {
            Console.WriteLine("Teacher answered question {0},{1}",student.Name,answer);
        }

    }

    class Student:CourseMember
    {
        public Student(Mediator mediator) : base(mediator)
        {
        }
        public void RecieveImage(string url)
        {
            Console.WriteLine("Student revieved image: {0}",url);
        }

        public void RecieveAnswer(string answer)
        {
            Console.WriteLine("Student recieved answer, {0}",answer);
        }

        public string Name { get; set; }

        
    }

    class Mediator
    {
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }

        public void UpdateImage(string url)
        {
            foreach (var student in Students)
            {
                student.RecieveImage(url);
            }
        }

        public void SendQuestion(string question,Student student)
        {
            Teacher.RecieveQuestion(question, student);
        }

        public void SendAnswer(string answer, Student student)
        {
            student.RecieveAnswer(answer);
        }
    }
}
