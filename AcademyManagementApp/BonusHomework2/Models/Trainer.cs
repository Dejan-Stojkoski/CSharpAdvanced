using System.Collections.Generic;
using System.Linq;
using Models.DB;

namespace Models
{
    public class Trainer : User
    {

        public Trainer(int id, string fullname, string username, string password) : base(id, fullname, username, password, RoleEnum.Trainer)
        {
        }

        public string GetAllStudents()
        {
            List<User> studentsList = Database.Users.Where(x => x.Role == RoleEnum.Student).ToList();
            if(studentsList.Count == 0)
            {
                return $"There are no students enrolled in the academy yet!";
            }

            string students = "\nThis are the students that are enroled in the academy: ";

            foreach(User student in studentsList)
            {
                students += $"\n{student.ID}. {student.FullName}";
            }

            students += "\n";
            return students;
        }

        public Student getStudent(int id)
        {
            User user = Database.Users.Where(x => x.ID == id && x.Role == RoleEnum.Student).FirstOrDefault();

            if(user == null)
            {
                throw new System.Exception("There is no such user!");
            }

            Student student = (Student)user;

            return student;
        }

        public string GetSubjectsInfo()
        {
            string info = "\nThis are all the subjects in the academy and how many stydents are attending: ";

            foreach(Subject subject in Database.Subjects)
            {
                info += $"\nTitle: {subject.Name}   -   Students attending: {subject.EnrolledStudents.Count}";
            }

            info += "\n";
            return info;
        }
    }
}
