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
            ExamineeOuestion exq = item with { examineeQuestionId = Config.ExamineeOuestionId };
            examineeQuestions.Add(exq);
            return exq.examineeQuestionId;
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

        public ExamineeOuestion? Read(int id)
        {
            int index = examineeQuestions.FindIndex(x => x?.examineeQuestionId == id);
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
