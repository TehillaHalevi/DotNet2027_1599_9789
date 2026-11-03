using DO;
using DalApi;
namespace DalTest
{
    public static class Initialization
    {
        static IDal s_dal;
        private static void createStudents()
        {
            s_dal.Student.Create(new Student(111, "sari", 2, 9));
            s_dal.Student.Create(new Student(123, "sari", 2, 9));
            s_dal.Student.Create(new Student(123, "sari", 2, 9));
            s_dal.Student.Create(new Student(123, "sari", 2, 9));
            s_dal.Student.Create(new Student(123, "sari", 2, 9));
        }
    }
}
