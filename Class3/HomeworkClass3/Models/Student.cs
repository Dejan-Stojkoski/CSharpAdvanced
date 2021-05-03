using System.Collections.Generic;
using Models.Interfaces;

namespace Models
{
    public class Student : User, IStudent
    {
        public List<int> Grades { get; set; }

        public Student(int id, string name, string username, string password, List<int> grades) : base(id, name, username, password)
        {
            Grades = grades;
        }

        public override string GetUserInfo()
        {
            string grades = $"{Id}. {Name} - Username: {Username}\n";

            if (Grades.Count == 0)
            {
                return $"The student {Name} has no grades yet!";
            }

            grades += $"{Name} grades are: ";

            foreach(int grade in Grades)
            {
                grades += $"{grade} ";
            }
            return grades;
        }
    }
}
