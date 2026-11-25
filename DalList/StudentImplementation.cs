using DalApi;
using DO;
using Exceptions;
using System.Linq.Expressions;
using System.Reflection;
using Tools;
using static Dal.DataSource;

namespace Dal
{
    internal class StudentImplementation : IStudent
    {
        public int Create(Student item)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,
                MethodBase.GetCurrentMethod().Name,"Create student");

            int index = students.FindIndex(x => x?.studentId == item.studentId);
            if (index != -1)
            {
                throw new ExistsIDException("this id is already exist");
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name,"Student creation failed");
            }
            students.Add(item);
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
             ,"The student was successfully created with ID: " + item.studentId);
            return item.studentId;
        }
        public void Delete(int id)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
           ,"Delete student " + id);
            int index = students.FindIndex(x => x?.studentId == id);
            try
            {
                students.RemoveAt(index);
            }
            catch (NotExistException e)
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
                ,$"Not found student {id} to delete");
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name,e.Message);
                throw new NotExistException($"A student of Id: {id} not exist", e);
            }
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
            ,"The student was successfully deleted with ID: " + id);
        }

        public Student? Read(int id)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
            ,"Read student " + id);
            int index = students.FindIndex(x => x?.studentId == id);
            if (index == -1)
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
                , $"Not found to read student " + id);
                return null;
            }
            return students[index];
        }

        public List<Student> ReadAll()
        {

            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "ReadAll students");
            return new List<Student>(students);
        }

        public void Update(Student item)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
            , "Update student " + item.studentId);
            int index = students.FindIndex(x => x?.studentId == item.studentId);
            try
            {
                students.Remove(students[index]);
                students.Add(item);
            }
            catch (NotExistException e)
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
                , $"Not found student {item.studentId} to update");
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name,e.Message);
                throw new NotExistException($"A student of Id: {item.studentId} not exist", e);
            }
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
            , "The student was successfully updated with ID: " + item.studentId);
        }
    }
}
