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
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ExamineeOuestion? Read(int id)
        {
            throw new NotImplementedException();
        }

        public List<ExamineeOuestion> ReadAll()
        {
            throw new NotImplementedException();
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
