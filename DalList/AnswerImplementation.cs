using DalApi;
using DO;
using Exceptions;
using Tools;
using System.Reflection;
using static Dal.DataSource;

namespace Dal
{
    internal class AnswerImplementation : IAnswer
    {
        public int Create(Answer item)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
            , "Create answer");
            Answer ans = item with { answerId = Config.AnswerId };
            answers.Add(ans);
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
           , "The answer was successfully created with ID: " +ans.answerId);
            return ans.answerId;
        }

        public void Delete(int id)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
             , "Delete exam " + id);
            var findAns=from ans in answers
                       where ans.answerId == id
                       select new{
                           answerId = ans.answerId,questionId=ans.questionId, answerContent=ans.answerContent
                       };
            if (findAns == null)
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
               , $"Not found answer {id} to delete");
                throw new NotExistException($"A answer of Id: {id} not exist");
            }
             var listAnswers=(from answer in answers
             where answer.answerId != id
             select answer).ToList();
            answers=listAnswers;
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
            , "The anser was successfully deleted with ID: " + id);

        }

        public Answer? Read(int id)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
            , "Read answer " + id);
            var findAns = (from ans in answers
                           where ans.answerId == id
                           select ans).FirstOrDefault();
            if (findAns == null)
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
                , $"Not found to read answer " + id);
                return null;
            }
            return findAns;
        }

        public Answer? Read(Func<Answer, bool> filter)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
            , "Read answer by filter");
            var findAns = (from ans in answers
                          where filter(ans)
                          select ans).FirstOrDefault();
            if (findAns == null)
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
                , $"Not found to read answer that meets the condition");
                return null;
            }
            return findAns;
        }


        public List<Answer?> ReadAll(Func<Answer, bool>? filter = null)
        {
            if (filter == null)
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "ReadAll answer");
                return new List<Answer>(answers);
            }
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "ReadAll answer by filter");
            var listAnswers =(from answer in answers
                             where filter(answer)
                             select answer).ToList();
            return listAnswers;
        }

        public void Update(Answer item)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
            , "Update answer " + item.answerId);
            var findAns = from ans in answers
                          where ans.answerId == item.answerId
                          select new
                          {
                              answerId = ans.answerId,
                              questionId = ans.questionId,
                              answerContent = ans.answerContent
                          };
            if (findAns == null)
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
                , $"Not found answer {item.answerId} to update");
                throw new NotExistException($"A answer of Id: {item.answerId} not exist");
            }
            Delete(item.answerId);
            answers.Add(item);
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
            , "The answer was successfully updated with ID: " + item.answerId);

        }
    }
}
