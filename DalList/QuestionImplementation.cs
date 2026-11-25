using DalApi;
using DO;
using Tools;
using Exceptions;
using System.Reflection;
using static Dal.DataSource;

namespace Dal
{
    internal class QuestionImplementation : IQuestion
    {
        public int Create(Question item)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
            , "create question");
            Question q = item with { questionId = Config.QuestionId };
            questions.Add(q);
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
           , "The question was successfully created with ID: " + q.questionId);
            return q.questionId;
        }

        public void Delete(int id)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
            , "Delete question " + id);
            var findQuestion = from question in questions
                               where question.questionId == id
                           select new
                           {
                               questionId = question.questionId,
                               questionTopic=question.questionTopic,
                               questionContent=question.questionContent,
                               correctAnsId = question.correctAnsId
                               
                           };
            if (findQuestion == null)
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
             , $"Not found question {id} to delete");
                throw new NotExistException($"A question of Id: {id} not exist");
            }
            var newQuestion = (from question in questions
                               where question.questionId != id
                            select question
                          ).ToList();

            questions = (List<Question>)(newQuestion);
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
            , "The question was successfully deleted with ID: " + id);

        }

        public Question? Read(int id)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
            , "Read question " + id);

            var findQuestion = (from question in questions
                                where question.questionId == id
                                select question).FirstOrDefault();
         
                             
            if (findQuestion == null)
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
               , $"Not found to read question " + id);
                return null;
            }
            return findQuestion;
        }

        public Question? Read(Func<Question, bool> filter)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
            , "Read question by filter");

            var findQuestion = (from question in questions
                               where filter(question)
                               select question).FirstOrDefault();

            if (findQuestion == null)
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
               , $"Not found to read question that meeting the condition");
                return null;
            }
            return findQuestion;
        }

        public List<Question?> ReadAll(Func<Question, bool>? filter = null)
        {
           if(filter == null)
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "ReadAll question");
                return new List<Question>(questions);
            }
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "ReadAll question by filter");

            var listQuestions = (from question in questions
                                 where filter(question)
                             select question).ToList();
            return listQuestions;
        }

        public void Update(Question item)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
            , "Update question " + item.questionId);
            var findQuestion = from question in questions
                               where question.questionId == item.questionId
                               select new
                               {
                                   questionId = question.questionId,
                                   questionTopic = question.questionTopic,
                                   questionContent = question.questionContent,
                                   correctAnsId = question.correctAnsId

                               };
            if (findQuestion == null)
            {
                LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
                , $"Not found question {item.questionId} to update");
                throw new NotExistException($"A question of Id: {item.questionId} not exist");
            }
            Delete(item.questionId);
            questions.Add(item);
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
            , "The question was successfully updated with ID: " + item.questionId);
        }
    }
}
