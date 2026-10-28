using DalApi;
using DO;
using Exceptions;
using static Dal.DataSource;


namespace Dal
{
    internal class ExamImplementation : IExam
    {
        public int Create(Exam item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Exam? Read(int id)
        {
            throw new NotImplementedException();
        }

        public List<Exam> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Exam item)
        {
            int index = exams.FindIndex(x => x?.examId == item.examId);
            try
            {
                exams.Remove(exams[index]);
                exams.Add(item);
            }
            catch (NotExistException e)
            {
                throw new NotExistException($"A student of Id: {item.examId} not exist", e);
            }
        }
    }
}
