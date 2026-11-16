using DalApi;
using DO;
using Exceptions;
using System.Reflection;
using Tools;
using static Dal.DataSource;

namespace Dal
{
    internal class QuestionImplementation : IQuestion
    {
        public int Create(Question item)
        {
            WirteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
            , "create question");
            Question q = item with { questionId = Config.QuestionId };
            questions.Add(q);
            WirteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
           , "The question was successfully created with ID: " + q.questionId);
            return q.questionId;
        }

        public void Delete(int id)
        {
            WirteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
            , "Delete question " + id);
            int index = questions.FindIndex(x => x?.questionId == id);
            try
            {
                questions.RemoveAt(index);
            }
            catch (NotExistException e)
            {
                WirteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
               , $"Not found question {id} to delete");
                wirteToLog(e.Message);
                throw new NotExistException($"A student of Id: {id} not exist", e);
            }
            WirteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
            , "The question was successfully deleted with ID: " + id);

        }

        public Question? Read(int id)
        {
            WirteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
            , "Read question " + id);

            int index = questions.FindIndex(x => x?.questionId == id);
            if (index == -1)
            { 
                WirteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
               , $"Not found to read question " + id);
                return null;
            }
            return questions[index];
        }

        public List<Question> ReadAll()
        {
            return new List<Question>(questions);
        }

        public void Update(Question item)
        {
            WirteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
            , "Update question " + item.questionId);
            int index = questions.FindIndex(x => x?.questionId == item.questionId);
            try
            {
                questions.Remove(questions[index]);
                questions.Add(item);
            }
            catch (NotExistException e)
            {
                WirteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
                , $"Not found question {item.questionId} to update");
                wirteToLog(e.Message);
                throw new NotExistException($"A question of Id: {item.questionId} not exist", e);
            }
            WirteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
            , "The question was successfully updated with ID: " + item.questionId);

        }
    }
}
