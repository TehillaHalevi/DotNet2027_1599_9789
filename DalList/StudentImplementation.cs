using DalApi;
using DO;
using Exceptions;
using System.Diagnostics;
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
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Student creation failed");
                throw new ExistsIDException("this id is already exist");
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
            var findStudent = from student in students
                              where student.studentId == id
                          select new
                          {
                              studentId = student.studentId,
                              studentName = student.studentName,
                              ExamId = student.ExamId,
                              grade=student.grade
                          };
            if (findStudent == null)
            {

                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
                ,$"Not found student {id} to delete");
                throw new NotExistException($"A student of Id: {id} not exist");
            }
            var listStudents = (from student in students
                               where student.studentId != id
                               select student).ToList();
            students = listStudents;
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
            ,"The student was successfully deleted with ID: " + id);
        }

        public Student? Read(int id)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
            ,"Read student " + id);
            var findStudent = (from student in students
                               where student.studentId== id
                               select student).FirstOrDefault();
            if (findStudent == null)
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
                , $"Not found to read student " + id);
                return null;
            }
            return findStudent;
        }
        public Student? Read(Func<Student, bool> filter)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
            , "Read student by filter");
            var findStudent = (from student in students
                           where filter(student)
                           select student).FirstOrDefault();
            if (findStudent == null)
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
                , $"Not found to read student that meets the condition");
                return null;
            }
            return findStudent;
        }
        List<Student?> ICrud<Student>.ReadAll(Func<Student, bool>? filter)
        {
            if(filter == null)
            {

                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "ReadAll students");
                return new List<Student>(students);
            }
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "ReadAll students by filter");
            var listStudents = (from student in students
                               where filter(student)
                               select student).ToList();
            return listStudents;
        }

        public void Update(Student item)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
            , "Update student " + item.studentId);
            var findStudent = from student in students
                              where student.studentId == item.studentId
                              select new
                              {
                                  studentId = student.studentId,
                                  studentName = student.studentName,
                                  ExamId = student.ExamId,
                                  grade = student.grade
                              };
            if (findStudent == null)
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
               , $"Not found student {item.studentId} to update");
                throw new NotExistException($"A student of Id: {item.studentId} not exist");
            }
                Delete(item.studentId);
                students.Add(item);
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
           , "The student was successfully updated with ID: " + item.studentId);
        }

        
    }
}
