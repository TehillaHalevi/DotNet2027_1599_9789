using DalApi;
using DO;
using Exceptions;
using System.Reflection;
using Tools;
using static Dal.DataSource;

namespace Dal
{
    internal class ExamineeQuestionImplementation : IExamineeQuestion
    {
        public int Create(ExamineeQuestion item)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
            , "Create question for examinee");

            ExamineeQuestion exq = item with { examineeQuestionId = Config.ExamineeOuestionId };
            examineeQuestions.Add(exq);
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
            , "The question for examinee was successfully created with ID: " + exq.examineeQuestionId);
            return exq.examineeQuestionId;
        }

        public void Delete(int id)
        {

            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
           , "Delete question for examinee " + id);
            var findExaminee = from examinee in examineeQuestions
                               where examinee.examineeQuestionId == id
                          select new
                          {
                              studentId=examinee.studentId,
                              examineeQuestionId = examinee.examineeQuestionId,
                              examId=examinee.examId,
                              questionId = examinee.questionId,
                              chosenAnsId=examinee.chosenAnsId,
                          };
            if (findExaminee == null)
            { 
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
                , $"Not found question for examinee {id} to delete");
                throw new NotExistException($"A question for examinee of Id: {id} not exist");
            }

            var listExamineeQuestions = (from examinee in examineeQuestions
                                         where examinee.examineeQuestionId != id
                               select examinee).ToList();
            examineeQuestions = listExamineeQuestions;
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
            , "The question for examinee was successfully deleted with ID: " + id);

        }

        public ExamineeQuestion? Read(int id)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
            , "Read question for examinee " + id);
            var findExaminee = (from examinee in examineeQuestions
                                where examinee.examineeQuestionId== id
                                select examinee).FirstOrDefault();
            if (findExaminee == null)
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
                , $"Not found to read question for examinee " + id);
                return null;
            }
            return findExaminee;
        }
        public ExamineeQuestion? Read(Func<ExamineeQuestion, bool> filter)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
            , "Read examineeQuestion by filter");
            var findExaminee = (from examinee in examineeQuestions
                           where filter(examinee)
                           select examinee).FirstOrDefault();
            if (findExaminee == null)
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
                , $"Not found to read examinee that meets the condition");
                return null;
            }
            return findExaminee;
        }

        List<ExamineeQuestion?> ICrud<ExamineeQuestion>.ReadAll(Func<ExamineeQuestion, bool>? filter)
        {
            if (filter == null)
            {

                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "ReadAll students");
                return new List<ExamineeQuestion>(examineeQuestions);
            }
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "ReadAll examineeQuestions by filter");
            var listExamineeQuestions = (from examinee in examineeQuestions
                                where filter(examinee)
                                select examinee).ToList();
            return listExamineeQuestions;
        }

        public void Update(ExamineeQuestion item)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
            , "Update question for examinee " + item.examId);
            var findExaminee = from examinee in examineeQuestions
                               where examinee.examineeQuestionId == examinee.examineeQuestionId
                               select new
                               {
                                   studentId = examinee.studentId,
                                   examineeQuestionId = examinee.examineeQuestionId,
                                   examId = examinee.examId,
                                   questionId = examinee.questionId,
                                   chosenAnsId = examinee.chosenAnsId,
                               };
            if (findExaminee == null)
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
               , $"Not found question for examinee {item.examId} to update");
                throw new NotExistException($"A question for examinee of Id: {item.examineeQuestionId} not exist");
            }
          
             Delete(item.examineeQuestionId);
             examineeQuestions.Add(item);
           
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
            , "The question for examinee was successfully updated with ID: " + item.examId);

        }
    }
}
