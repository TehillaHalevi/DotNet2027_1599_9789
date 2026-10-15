using DO;
using DalApi;

namespace Dal
{
    internal class StudentImplementation : IStudent
    {
        public int Create(Student item)
        {
            return 0;
        }

        public void Delete(int id)
        {
            
        }

        public Student? Read(int id)
        {
            Student student = null;
            return student;
        }

        public List<Student> ReadAll()
        {
            return new List<Student>();
        }

        public void Update(Student item)
        {
        }
    }
}
