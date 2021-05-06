using System;
using System.Collections.Generic;

namespace Models.DB
{
    public static class Database
    {
        public static List<User> Users { get; set; }
        public static List<Subject> Subjects;

        static Database()
        {
            Users = new List<User>
            {
                new Admin(1,"Bob Bobsky", "bob", "bob123"),
                new Admin(2,"Jill Jillsky", "jill", "jill123"),
                new Trainer(3,"Bill Billsky", "bill", "bill123"),
                new Trainer(4,"John Snow", "john", "john123"),
                new Trainer(5,"Mallory Mon", "Mallory", "mallory123"),
                new Student(6,"Greg Gregsky", "greg", "greg123"),
                new Student(7,"Emily Pa", "emily", "emily123"),
                new Student(8,"Brie Bob", "brie", "brie123"),
                new Student(9,"Jeff", "jeff", "jeff123"),
                new Student(10,"Sam Jony", "sam", "sam123"),
                new Student(11,"Jony Jony", "jony", "jony123")
            };

            Subjects = new List<Subject>
            {
                //new Subject(SubjectEnum.Intro),
                new Subject(SubjectEnum.CSharp),
                new Subject(SubjectEnum.JavaScript),
                new Subject(SubjectEnum.Math),
                new Subject(SubjectEnum.Physics)
            };
        }

        public static string Greet(string name)
        {
            return $"\nWelcome back {name}.";
        }

        public static int ParseInt(string number)
        {
            if(int.TryParse(number, out int num))
            {
                return num;
            }

            throw new Exception("The input is not a number!");
        }
    }
}
