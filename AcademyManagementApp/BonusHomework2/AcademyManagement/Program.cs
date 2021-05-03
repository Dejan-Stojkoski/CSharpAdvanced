using System;
using System.Linq;
using Models;
using Models.DB;

namespace AcademyManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    User loginUser = Login();

                    if(loginUser == null)
                    {
                        throw new Exception("Invalid username! Please try again.");
                    }

                    switch (loginUser.Role)
                    {
                        case RoleEnum.Admin:
                            AdminUI((Admin)loginUser);
                            break;
                        case RoleEnum.Trainer:
                            TrainerUI((Trainer)loginUser);
                            break;
                        case RoleEnum.Student:
                            StudentUI((Student)loginUser);
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }



        static User Login()
        {
            Console.Write("\nPlease enter your username: ");
            string username = Console.ReadLine();

            Console.Write("Please enter your password: ");
            string password = Console.ReadLine();

            User user = Database.Users.FirstOrDefault(x => x.Login(username, password) != null);

            return user;
        }


        static void AdminUI(Admin admin)
        {
            Console.WriteLine(Database.Greet(admin.FullName));

            while (true)
            {
                try
                {
                    Console.WriteLine("\nWhat do you want to do: " +
                        "\n1. Delete User" +
                        "\n2. Add User" +
                        "\n3. Log out");

                    string numberString = Console.ReadLine();
                    int number = Database.ParseInt(numberString);

                    if(number < 1 || number > 3)
                    {
                        throw new Exception("There are only three options. Try again: ");
                    }

                    switch (number)
                    {
                        case 1:
                            Console.WriteLine(admin.GetAllUsers());
                            Console.WriteLine("\nPlease enter the ID of the user you want to delete: ");

                            string idString = Console.ReadLine();
                            int id = Database.ParseInt(idString);

                            User deleteUser = Database.Users.Where(x => x.ID == id).FirstOrDefault();

                            if (deleteUser == null)
                            {
                                throw new Exception($"There is no user with ID number {id}.");
                            }

                            Console.WriteLine(admin.DeleteUser(deleteUser));
                            Console.WriteLine(admin.GetAllUsers());
                            continue;

                        case 2:
                            Console.WriteLine(admin.AddUser(CreateUser()));
                            Console.WriteLine(admin.GetAllUsers());
                            continue;

                        case 3:
                            break;
                    }

                    break;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }



        static void StudentUI(Student student)
        {
            Console.WriteLine(Database.Greet(student.FullName));

            Console.WriteLine(student.GetStudentInfo());
        }



        static void TrainerUI(Trainer trainer)
        {
            Console.WriteLine(Database.Greet(trainer.FullName));

            while (true)
            {
                try
                {
                    Console.WriteLine("\nWhat do you want to do?\n" +
                    "1. See Students\n" +
                    "2. See Subjects\n" +
                    "3. Log out");

                    int option;
                    while (true)
                    {
                        string optionString = Console.ReadLine();
                        option = Database.ParseInt(optionString);

                        if (option > 3 || option < 1)
                        {
                            Console.Write("There are only three options. please try again: ");
                            continue;
                        }
                        break;
                    }

                    switch (option)
                    {
                        case 1:
                            Console.WriteLine(trainer.GetAllStudents());
                            Console.Write("Please choose student ID: ");
                            Student student;
                            while (true)
                            {
                                string idString = Console.ReadLine();
                                int id = Database.ParseInt(idString);
                                student = trainer.getStudent(id);

                                if (student == null)
                                {
                                    Console.Write("There is no student with that id. Please try again: ");
                                    continue;
                                }
                                break;
                            }
                            Console.WriteLine($"Student : {student.FullName}\n {student.GetStudentInfo()}");
                            Console.WriteLine("If you want to give a grade to the current student course and change the course write \"Yes\": ");
                            string input = Console.ReadLine().ToLower();

                            if(input == "yes")
                            {
                                Console.WriteLine("\nPlease choose new subject: ");
                                foreach (SubjectEnum subject in Enum.GetValues(typeof(SubjectEnum)))
                                {
                                    Console.WriteLine($"{(int)subject}. {subject}");
                                }

                                int newSubject;
                                while (true)
                                {
                                    string subjectString = Console.ReadLine();
                                    newSubject = Database.ParseInt(subjectString);

                                    if(newSubject < 0 || !Enum.IsDefined(typeof(SubjectEnum), newSubject))
                                    {
                                        Console.Write("There is no such subject. Please try again: ");
                                        continue;
                                    }
                                    break;
                                }

                                Console.Write($"Please enter a grade for {student.CurrentSubject}: ");
                                int grade;
                                while (true)
                                {
                                    string gradeString = Console.ReadLine();
                                    grade = Database.ParseInt(gradeString);

                                    if(grade > 5 || grade < 1)
                                    {
                                        Console.Write("Grade should be between 1-5. Try again: ");
                                        continue;
                                    }
                                    break;
                                }

                                Console.WriteLine(student.ChangeSubjectAndGradeOldSubject((SubjectEnum)newSubject, grade));
                            }
                            continue;

                        case 2:
                            Console.WriteLine(trainer.GetSubjectsInfo());
                            continue;

                        case 3:
                            break;
                    }
                    break;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                
            }
        }




        static User CreateUser()
        {
            Console.Write("Please enter a user id: ");
            int id;
            while (true)
            {
                string idString = Console.ReadLine();
                id = Database.ParseInt(idString);

                if (id < 0 || Database.Users.Any(x => x.ID == id))
                {
                    Console.Write("This user id already exist or the id is a negative number. Please try again: ");
                    continue;
                }
                break;
            }

            Console.WriteLine("Please choose the role of tge new user: ");
            foreach (RoleEnum role in Enum.GetValues(typeof(RoleEnum)))
            {
                Console.WriteLine($"{(int)role}. {role}");
            }
            int roleValue;
            while (true)
            {
                string roleValueString = Console.ReadLine();
                roleValue = Database.ParseInt(roleValueString);

                if(roleValue < 0 || !Enum.IsDefined(typeof(RoleEnum), roleValue))
                {
                    Console.Write("There is no such role. Please try again! ");
                    continue;
                }
                break;
            }

            Console.Write("Please enter the new user full name: ");
            string fullname = Console.ReadLine();

            Console.Write("Please enter the new user Username: ");
            string username = Console.ReadLine();

            Console.Write("Please enter the new user password: ");
            string password = Console.ReadLine();

            if((RoleEnum)roleValue == RoleEnum.Admin)
            {
                Admin user = new Admin(id, fullname, username, password);
                return user;
            }
            else if ((RoleEnum)roleValue == RoleEnum.Student)
            {
                Student user = new Student(id, fullname, username, password);
                return user;
            }
            else
            {
                Trainer user = new Trainer(id, fullname, username, password);
                return user;
            }
        }
    }
}
