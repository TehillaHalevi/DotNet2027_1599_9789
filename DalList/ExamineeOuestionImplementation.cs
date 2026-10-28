using DalApi;
using DO;
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
            throw new NotImplementedException();
        }
    }
}
