using DalApi;
using DO;
using Exceptions;
using static Dal.DataSource;

namespace Dal
{
    internal class AnswerImplementation : IAnswer
    {
        public int Create(Answer item)
        {
            Answer ans = item with { answerId = Config.AnswerId };
            answers.Add(ans);
            return ans.answerId;
        }

        public void Delete(int id)
        {
            int index = students.FindIndex(x => x?.studentId == id);
            try
            {
                students.RemoveAt(index);
            }
            catch (NotExistException e)
            {
                throw new NotExistException($"A student of Id: {id} not exist", e);
            }

        }

        public Answer? Read(int id)
        {
            int index = answers.FindIndex(x => x?.answerId == id);
            if (index == -1)
                return null;
            return answers[index];
        }

        public List<Answer> ReadAll()
        {
            return new List<Answer>(answers);
        }

        public void Update(Answer item)
        {
            int index = answers.FindIndex(x => x?.answerId == item.answerId);
            try
            {
                answers.Remove(answers[index]);
                answers.Add(item);
            }
            catch (NotExistException e)
            {
                throw new NotExistException($"A student of Id: {item.answerId} not exist", e);
            }
        }
    }
}
