using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace week10_practice13
{
    class Program
    {
        static void Main(String[] args)
        {
            DAO dao = new DAO();
            List<Student> students = dao.List();

            foreach(Student student in students)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine("Enter a name:");
            String name = Console.ReadLine();
            dao.Add(name);

            students = dao.List();

            foreach(Student student in students)
            {
                Console.WriteLine(student);
            }

            // Student john = new Student(12345, "John");
            // Student mary = new Student(98765, "Mary");
            // Student joe = new Student(45678, "Joe");

            // Context myContext = new Context();
            // myContext.Database.EnsureCreated();
            // myContext.myStudents.Add(john);
            // myContext.myStudents.Add(mary);
            // myContext.myStudents.Add(joe);
            // myContext.SaveChanges();

            // List<Student> students = new List<Student>();

            // students.Add(john);
            // students.Add(mary);
            // students.Add(joe);

            // foreach (Student s in students)
            // {
            //     Console.WriteLine(s.ToString());
            // }
        }
    }

    public class DAO
    {
        private Context context { get; set; }

        public Student student { get; set; }

        public DAO()
        {
            context = new Context();
            context.Database.EnsureCreated();
        }

        public List<Student> List()
        {
            List<Student> result = new List<Student>();
            foreach (Student student in context.myStudents)
            {
                result.Add(student);
            }

            return result;
        }

        public void Add(String name)
        {
            context.myStudents.Add(new Student(name));
            context.SaveChanges();
        }
    }

    public class Student
    {
        public int id { get; private set; }

        public String name { get; private set; }

        public Student(String name)
        {
            this.name = name;
        }
        public Student(int id, String name)
        {
            this.id = id;
            this.name = name;
        }

        public override String ToString()
        {
            return $"Student name: { name }   Student id: { id }";
        }
    }

    public class Context : DbContext
    {
        public DbSet<Student> myStudents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./students.db");
        }
    }
}
