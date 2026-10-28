using DalApi;
using DO;
using static Dal.DataSource;
using Exceptions;

namespace Dal
{
    internal class QuestionImplementation : IQuestion
    {
        public int Create(Question item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Question? Read(int id)
        {
            throw new NotImplementedException();
        }

        public List<Question> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Question item)
        {
            int index = examineeQuestions.FindIndex(x => x?.questionId == item.examineeQuestionId);
            try
            {
                questions.Remove(questions[index]);
                questions.Add(item);
            }
            catch (NotExistException e)
            {
                throw new NotExistException($"A student of Id: {item.questionId} not exist", e);
            }
        }
    }
}
