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
            var findExam = from exam in exams
                           where exam.examId == id
                           select new
                           {
                               examId = exam.examId,
                               examTopic = exam.examTopic,
                               examDate = exam.examDate,
                               numberOfQuestions = exam.numberOfQuestions
                           };
            if (findExam == null)
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
            , $"Not found exam {id} to delete");
                throw new NotExistException($"A exam of Id: {id} not exist");
            }
            var newExams = (from exam in exams
                            where exam.examId != id
                            select exam
                           ).ToList();

            exams =newExams;
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
            , "The exam was successfully deleted with ID: " + id);
        }

        public Exam? Read(int id)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
            , "Read exam " + id);
            var findExam = (from exam in exams
                            where exam.examId== id
                            select exam).FirstOrDefault();
            if (findExam == null)
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
              , $"Not found to read exam " + id);
                return null;
            }
            return findExam;
        }

        public Exam? Read(Func<Exam, bool> filter)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
           , "Read exam by filter");
            var findExam = (from exam in exams
                            where filter(exam)
                            select exam).FirstOrDefault();
            if (findExam == null)
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
              , $"Not found to read exam that meet the condition");
                return null;
            }
            return findExam;
        }

        public List<Exam?> ReadAll(Func<Exam, bool>? filter = null)
        {

            if (filter==null)
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "ReadAll exam");
                return new List<Exam>(exams);
            }
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "ReadAll exam by filter");

            var listExams =(from exam in exams
                           where filter(exam)
                           select exam).ToList();
            return listExams;
        }

        public void Update(Exam item)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
            , "Update exam " + item.examId);
            var findExam = from exam in exams
                           where exam.examId == item.examId
                           select new
                           {
                               examId = exam.examId,
                               examTopic = exam.examTopic,
                               examDate = exam.examDate,
                               numberOfQuestions = exam.numberOfQuestions
                           };
            if (findExam == null)
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
              , $"Not found exam {item.examId} to update");
                throw new NotExistException($"A exam of Id: {item.examId} not exist");
            }
            Delete(item.examId);
            exams.Add(item);
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
            , "The exam was successfully updated with ID: " + item.examId);

        }
    }
}
