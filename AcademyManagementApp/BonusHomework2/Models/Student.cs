using System.Collections.Generic;
using System.Linq;
using Models.DB;

namespace Models
{
    public class Student : User
    {
        public SubjectEnum CurrentSubject { get; private set; }
        public Dictionary<string, int> Grades { get; private set; }

        public Student(int id, string fullname, string username, string password) : base(id, fullname, username, password, RoleEnum.Student)
        {
            CurrentSubject = SubjectEnum.Intro;
            //Subject into = Database.Subjects.FirstOrDefault(x => x.Name == SubjectEnum.Intro);
            //into.EnrolledStudents.Add(FullName);
            Grades = new Dictionary<string, int> { };
        }

        public string GetStudentInfo()
        {
            string info = $"Current subject : {CurrentSubject}\n";

            if(Grades.Count > 0)
            {
                info += "Grades:";
                foreach(KeyValuePair<string, int> grade in Grades)
                {
                    info += $"\n{grade.Key} : {grade.Value}";
                }
            }

            return info;
        }

        public string ChangeSubjectAndGradeOldSubject(SubjectEnum subject, int grade)
        {
            if(CurrentSubject == subject || Grades.ContainsKey(subject.ToString()))
            {
                return $"{FullName} is already listening to this class, or the student has finished this class.";
            }

            SubjectEnum oldSubject = CurrentSubject;
            Grades.Add(CurrentSubject.ToString(), grade);

            foreach(Subject subject1 in Database.Subjects)
            {
                if(CurrentSubject == subject1.Name)
                {
                    if (subject1.EnrolledStudents.Any(x => x == FullName))
                    {
                        subject1.EnrolledStudents.Remove(FullName);
                    }
                }
            }

            CurrentSubject = subject;

            Subject newSub = Database.Subjects.Where(x => x.Name == subject).FirstOrDefault();
            newSub.EnrolledStudents.Add(FullName);

            return $"{FullName} current subject changed to {subject}, and {oldSubject} was graded with {grade}";
        }
    }
}
