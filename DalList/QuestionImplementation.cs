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
            Question q = item with { questionId = Config.QuestionId };
            questions.Add(q);
            return q.questionId;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Question? Read(int id)
        {
            int index = questions.FindIndex(x => x?.questionId == id);
            if (index == -1)
            return null;
            return questions[index];
        }

        public List<Question> ReadAll()
        {
            return new List<Question>(questions);
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
