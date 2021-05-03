using System.Collections.Generic;

namespace Models
{
    public class Subject
    {
        public SubjectEnum Name { get; set; }
        public List<string> EnrolledStudents { get; set; }

        public Subject(SubjectEnum name)
        {
            Name = name;
            EnrolledStudents = new List<string>();
        }
    }
}
