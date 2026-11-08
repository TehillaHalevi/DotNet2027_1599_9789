using Dal;
using DalApi;
using DO;
using System;
using static System.Net.Mime.MediaTypeNames;


namespace DalTest
{
  
    internal class Program
    {
        static IDal s_dal = new Dal.DalList();

        private static void RunMain()
        {
            string selection = "start";
            try
            {
                while (selection != "0")
                {

                    PrintMainMenu();
                    selection = Console.ReadLine();
                    switch (selection)
                    {
                        case "1":
                            SubMenu<Student>("student", s_dal.Student, GetStudent);
                            break;
                        case "2":
                            SubMenu<Question>("question", s_dal.Question, GetQuestion);
                            break;
                        case "3":
                            SubMenu<Answer>("answer", s_dal.Answer, GetAnswer);
                            break;
                        case "4":
                            SubMenu<ExamineeQuestion>("examineeQuestion", s_dal.ExamineeQuestion, GetExamineeQuestion);
                            break;
                        case "5":
                            SubMenu<Exam>("exam", s_dal.Exam, GetExam);
                            break;
                        case "0":
                            break;
                        default:
                            Console.WriteLine("worng input, Please enter again");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("error");
                Console.WriteLine(ex.Message);
            }
        }
        private static void PrintMainMenu()
        {
            Console.WriteLine("====== Main Menu ======");
            Console.WriteLine("1. Student");
            Console.WriteLine("2. Question");
            Console.WriteLine("3. Answer");
            Console.WriteLine("4. ExamineeQuestion");
            Console.WriteLine("5. Exam");
            Console.WriteLine("0. Exit");
            Console.Write("Select the desired extension: ");

        }
        private static void PrintSecondMenu(string name) {
            Console.WriteLine();
            Console.WriteLine($"===== {name} Menu =====");
            Console.WriteLine("1. Create");
            Console.WriteLine("2. Read");
            Console.WriteLine("3. ReadAll");
            Console.WriteLine("4. Update");
            Console.WriteLine("5. Delete");
            Console.WriteLine("0. Back to main menu");
            Console.Write("Choose an operation: ");
        }
        private static void SubMenu<T>(string name, ICrud<T> crud, Func<bool, T> getParams)
        {
            string selection = string.Empty;
            try
            {
                while (selection != "0")
                {
                    PrintSecondMenu(name);
                    selection = Console.ReadLine() ?? string.Empty;

                    switch (selection)
                    {
                        case "1":
                            T newEntity = getParams(false);
                            int idEntity = crud.Create(newEntity);
                            Console.WriteLine($"{name} created successfully. Id: {idEntity}");
                            break;
                        case "2":
                            int readId = GetIntInput("Enter Id to search:");
                            T? entity = crud.Read(readId);

                            if (entity is null)
                            {
                                Console.WriteLine($"{name} {readId} was'nt found.");
                            }
                            else
                            {
                                Console.WriteLine(entity);
                            }
                            break;
                        case "3":
                            List<T> entityList = crud.ReadAll();
                            if (entityList.Count == 0)
                                Console.WriteLine($"There are no {name}s.");
                            else
                            {
                                foreach (T item in entityList)
                                {
                                    Console.WriteLine(item + ", ");
                                }
                            }
                            break;
                        case "4":
                            T updateEntity = getParams(true);
                            crud.Update(updateEntity);
                            Console.WriteLine($"{name} updated successfully.");
                            break;
                        case "5":
                            int deleteId = GetIntInput("Enter Id to delete:");
                            crud.Delete(deleteId);
                            Console.WriteLine("Entity deleted successfully.");
                            break;
                        case "0": break;
                        default:
                            Console.WriteLine("Worng input, Please enter again"); break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error!");
                Console.WriteLine(ex.Message);
            }

        }


        private static int GetIntInput(string message)
        {
            int value;
            do
            {
                Console.WriteLine(message);
            } while (!int.TryParse(Console.ReadLine(), out value));
            return value;
        }
        private static string GetStringInput(string massege)
        {
            Console.WriteLine(massege);
            return Console.ReadLine();
        }
        private static QuestionTopic GetQuestionTopic()
        {
            Console.WriteLine("Choose question subject:");
            Console.WriteLine("0. Math");
            Console.WriteLine("1. English");
            Console.WriteLine("2. History");

            int subjectNumber = GetIntInput("Enter subject number: ");

            return (QuestionTopic)subjectNumber;
        }
        private static ExamTopic GetExamTopic()
        {
            Console.WriteLine("Choose question subject:");
            Console.WriteLine("0. Math");
            Console.WriteLine("1. English");
            Console.WriteLine("2. History");

            int subjectNumber = GetIntInput("Enter subject number: ");

            return (ExamTopic)subjectNumber;
        }
        private static DateTime GetDateTimeInput(string message)
        {
            DateTime value;

            do
            {
                Console.Write(message);
            }
            while (!DateTime.TryParse(Console.ReadLine(), out value));

            return value;
        }


       
        private static Student GetStudent(bool isupdate) {
            int studentId = GetIntInput("Enter student Id: ");
            string studentName = GetStringInput("Enter student name: ");
            int ExamId = GetIntInput("Enter exam Id: ");
            int grade = GetIntInput("Enter grade: ");
           
            return new Student(
                studentId,
                studentName,
                ExamId,
                grade);
        }
        private static Question GetQuestion(bool isupdate)
        {
            int id = GetIntInput("Enter question Id: ");
            QuestionTopic subject = GetQuestionTopic();
            string content = GetStringInput("Enter question content: ");
            int correctAnswerId = GetIntInput("Enter correct answer Id: ");

            return new Question(
                id,
                subject,
                content,
                correctAnswerId);
        }
        private static Answer GetAnswer(bool isupdate)
        {
            int id = GetIntInput("Enter answer Id: ");
            int questionId = GetIntInput("Enter question Id: ");
            string content = GetStringInput("Enter answer content: ");

            return new Answer(
                id,
                questionId,
                content);
        
        }
        private static ExamineeQuestion GetExamineeQuestion(bool isupdate)
        {
            int id = GetIntInput("Enter student-question Id: ");
            int studentId = GetIntInput("Enter student Id: ");
            int testId = GetIntInput("Enter exam Id: ");
            int questionId = GetIntInput("Enter question Id: ");
            int selectedAnswerId =
                GetIntInput("Enter selected answer Id, or leave empty: ");
     
            return new ExamineeQuestion(
                id,
                studentId,
                testId,
                questionId,
                selectedAnswerId);
        }
        private static Exam GetExam(bool isupdate)
        {
            int id = GetIntInput("Enter test Id: ");
            ExamTopic subject = GetExamTopic();
            DateTime testDate = GetDateTimeInput("Enter test date: ");
            int questionCount = GetIntInput("Enter question count: ");

            return new Exam(
                id,
                subject,
                testDate,
                questionCount);
        }


        static void Main(string[] args)
        {
            try
            {
                Initialization.Initialize(s_dal);
            }
            catch (Exception ex)
            {
                Console.WriteLine("error");
                Console.WriteLine(ex.Message);
            }
            RunMain();
        }
    }
}


