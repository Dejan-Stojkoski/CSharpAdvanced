using Models.Interfaces;

namespace Models
{
    public class Teacher : User, ITeacher
    {
        public string Subject { get; set; }

        public Teacher(int id, string name, string username, string password, string subject) : base(id, name, username, password)
        {
            Subject = subject;
        }

        public override string GetUserInfo()
        {
            return $"{Id}. {Name} - Username: {Username}.\n {Name} teaches {Subject}.";
        }
    }
}
