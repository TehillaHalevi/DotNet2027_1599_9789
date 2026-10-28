using DalApi;
using DO;
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
