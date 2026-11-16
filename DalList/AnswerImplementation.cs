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
            WirteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
            , "Create answer");
            Answer ans = item with { answerId = Config.AnswerId };
            answers.Add(ans);
            WirteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
           , "The answer was successfully created with ID: " +ans.answerId);
            return ans.answerId;
        }

        public void Delete(int id)
        {

            int index = answers.FindIndex(x => x?.answerId == id);
            try
            {
                answers.RemoveAt(index);
            }
            catch (NotExistException e)
            {
                WirteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
                , $"Not found answer {id} to delete");
                WirteToLog(e.Message);
                throw new NotExistException($"A answer of Id: {id} not exist", e);

            }
            WirteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
            , "The anser was successfully deleted with ID: " + id);

        }

        public Answer? Read(int id)
        {
            WirteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
            , "Read answer " + id);
            int index = answers.FindIndex(x => x?.answerId == id);
            if (index == -1)
            {
                WirteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
                , $"Not found to read answer " + id);
                return null;
            }
            return answers[index];
        }
        public List<Answer> ReadAll()
        {
            WirteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "ReadAll answer");
            return new List<Answer>(answers);
        }
        public void Update(Answer item)
        {
            WirteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
            , "Update answer " + item.answerId);
            int index = answers.FindIndex(x => x?.answerId == item.answerId);
            try
            {
                answers.Remove(answers[index]);
                answers.Add(item);
            }
            catch (NotExistException e)
            {
                WirteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
                , $"Not found answer {item.answerId} to update");
                wirteToLog(e.Message);
                throw new NotExistException($"A answer of Id: {item.answerId} not exist", e);
            }
            WirteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
            , "The answer was successfully updated with ID: " + item.answerId);

        }
    }
}
