using System;
using System.Collections.Generic;
using Models;

namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Teacher teacher1 = new Teacher(1, "Bill", "bill", "bill123", "Math");
            Teacher teacher2 = new Teacher(2, "Jill", "jill", "jill123", "Physics");

            Student student1 = new Student(3, "Greg", "greg", "greg123", new List<int> { 3, 4, 3, 5, 5, 4, 2 });
            Student student2 = new Student(4, "Bob", "bob", "bob123", new List<int> { 5, 4, 5, 5, 5, 5, 3 });

            Console.WriteLine(teacher1.GetUserInfo());
            Console.WriteLine(teacher2.GetUserInfo());
            Console.WriteLine(student1.GetUserInfo());
            Console.WriteLine(student2.GetUserInfo());
        }
    }
}
