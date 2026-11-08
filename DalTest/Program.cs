using Dal;
using DalApi;
using DO;


namespace DalTest
{
    internal class Program
    {

        static IDal s_dal = new DalList();

        static void Main(string[] args)
        {
            try
            {
                Initialization.Initialize(s_dal);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error!");
                Console.WriteLine(ex.Message);
            }

            string selection = "start";

            try
            {
                while (selection != "0")
                {
                    PrintMainMenu();
                    switch (selection)
                    {
                        case "1":
                            SubMenu<Student>("student", s_dal.Student, GetStudent); break;
                        case "2":
                            SubMenu<Question>("question", s_dal.Question, GetQuestion); break;
                        case "3":
                            SubMenu<Answer>("answer", s_dal.Answer, GetAnswer); break;
                        case "4":
                            SubMenu<ExamineeQuestion>("exmineeQuestion", s_dal.ExamineeQuestion, GetExamineeQuestion); break;
                        case "5":
                            SubMenu<Exam>("exam", s_dal.Exam, GetExam); break;
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

        private static void PrintMainMenu()
        {
            Console.WriteLine("======Main Menu=====");
            Console.WriteLine("1. Student");
            Console.WriteLine("2. Question");
            Console.WriteLine("3. Answer");
            Console.WriteLine("4. ExamineeQuestion");
            Console.WriteLine("5. Exam");
            Console.WriteLine("0. Exit");
            Console.Write("Select the desired extension: ");

        }
        private static void PrintSecondMenu(string name) { }


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
       


    }
}


