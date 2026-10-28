using DalApi;
using DO;
using Exceptions;
using static Dal.DataSource;

namespace Dal
{
    internal class ExamineeOuestionImplementation : IExamineeQuestion
    {
        public int Create(ExamineeOuestion item)
        {
            ExamineeOuestion exq = item with { examineeOuestionId = Config.ExamineeOuestionId };
            examineeQuestions.Add(exq);
            return exq.examineeOuestionId;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ExamineeOuestion? Read(int id)
        {
            int index = examineeQuestions.FindIndex(x => x?.examineeOuestionId == id);
            if (index == -1)
                return null;
            return examineeQuestions[index];
        }

        public List<ExamineeOuestion> ReadAll()
        {
            return new List<ExamineeOuestion>(examineeQuestions);
        }

        public void Update(ExamineeOuestion item)
        {
            int index = examineeQuestions.FindIndex(x => x?.examineeQuestionId == item.examineeQuestionId);
            try
            {
                examineeQuestions.Remove(examineeQuestions[index]);
                examineeQuestions.Add(item);
            }
            catch (NotExistException e)
            {
                throw new NotExistException($"A student of Id: {item.examineeQuestionId} not exist", e);
            }
        }
    }
}
