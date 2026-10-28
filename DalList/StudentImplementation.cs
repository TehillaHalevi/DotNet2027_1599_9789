using DalApi;
using DO;
using Exceptions;
using System.Linq.Expressions;
using static Dal.DataSource;

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
            int index=students.FindIndex(x=>x?.studentId==item.studentId);
            try
            {
                students.Remove(students[index]);
                students.Add(item);
            }
            catch(NotExistException e)
            {
                throw new NotExistException($"A student of Id: {item.studentId} not exist",e);
            }
        }
    }
}
