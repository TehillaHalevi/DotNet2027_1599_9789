using DalApi;
using DO;
using Exceptions;
using Tools;
using System.Reflection;
using static Dal.DataSource;

namespace Dal
{
    internal class ExamImplementation : IExam
    {
        public int Create(Exam item)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
            , "Create exam");
            Exam ex = item with { examId = Config.ExamId };
            exams.Add(ex);
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
            , "The exam was successfully created with ID: " + ex.examId);
            return ex.examId;
        }


        public void Delete(int id)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
             , "Delete exam " + id);
            int index = exams.FindIndex(x => x?.examId == id);
            try
            {
                exams.RemoveAt(index);
            }
            catch (NotExistException e)
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
               , $"Not found exam {id} to delete");
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name,e.Message);
                throw new NotExistException($"A exam of Id: {id} not exist", e);
            }
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
            , "The exam was successfully deleted with ID: " + id);
   
        }

        public Exam? Read(int id)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
            , "Read exam " + id);
            int index = exams.FindIndex(x => x?.examId == id);
            if (index == -1)
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
              , $"Not found to read exam " + id);
                return null;
            }
            return exams[index];
        }

        public List<Exam> ReadAll()
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "ReadAll exam");
            return new List<Exam>(exams);
        }

        public void Update(Exam item)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
            , "Update exam " + item.examId);
            int index = exams.FindIndex(x => x?.examId == item.examId);
            try
            {
                exams.Remove(exams[index]);
                exams.Add(item);
            }
            catch (NotExistException e)
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
               , $"Not found exam {item.examId} to update");
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name,e.Message);
                throw new NotExistException($"A exam of Id: {item.examId} not exist", e);
            }

            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
            , "The exam was successfully updated with ID: " + item.examId);

        }
    }
}
