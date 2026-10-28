using DalApi;
using DO;
using Exceptions;
using static Dal.DataSource;

namespace Dal
{
    internal class StudentImplementation : IStudent
    {
        public int Create(Student item)
        {
            int index = students.FindIndex(x => x?.studentId ==item.studentId);
            if (index != -1)
                throw new ExistsIDException("this id is already exist");
            students.Add(item);
            return item.studentId;
        }
        public void Delete(int id)
        {
            
        }

        public Student? Read(int id)
        {
            int index = students.FindIndex(x => x?.studentId == id);
            if (index == -1)
                return null;
            return students[index];
        }

        public List<Student> ReadAll()
        {
            return new List<Student>(students);
        }

        public void Update(Student item)
        {
        }
    }
}
