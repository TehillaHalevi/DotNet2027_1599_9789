using DalApi;
using DO;
using static Dal.DataSource;

namespace Dal
{
    internal class ExamImplementation : IExam
    {
        public int Create(Exam item)
        {
            Exam ex = item with { examId = Config.ExamId };
            exams.Add(ex);
            return ex.examId;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Exam? Read(int id)
        {
            int index = exams.FindIndex(x => x?.examId == id);
            if (index == -1)
                return null;
            return exams[index];
        }

        public List<Exam> ReadAll()
        {
            return new List<Exam>(exams);
        }

        public void Update(Exam item)
        {
            throw new NotImplementedException();
        }
    }
}
