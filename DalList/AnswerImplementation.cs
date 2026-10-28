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
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Answer? Read(int id)
        {
            throw new NotImplementedException();
        }

        public List<Answer> ReadAll()
        {
            throw new NotImplementedException();
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
