using Dal;
using DalApi;
using DO;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace DalTest
{
  
    internal class Program
    {
        private static void PrintMainMenu() {

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
        private static void SubMenu<T>(string name,ICrud<T> crud,Func<bool,T> getParams) { }
        private static Student GetStudent(bool isupdate) {
            return new Student();
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
        
        
        private static IDal s_dal = new DalList();
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
        }
    }

