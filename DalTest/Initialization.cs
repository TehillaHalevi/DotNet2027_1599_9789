using DO;
using DalApi;

namespace DalTest
{
    public static class Initialization
    {
        static IDal s_dal;
        private static void CreateStudents()
        {
            s_dal.Student.Create(new Student(111, "sari", 1, 9));
            s_dal.Student.Create(new Student(222, "Tehilla", 2, 9));
            s_dal.Student.Create(new Student(333, "Tamar", 2, 8));
            s_dal.Student.Create(new Student(444, "Yael", 3, 7));
            s_dal.Student.Create(new Student(555, "Dasi", 4, 8));
        }
        private static void CreateQuestion()
        {
            s_dal.Question.Create(new Question(0, QuestionTopic.MATH, "question 1",100));
            s_dal.Question.Create(new Question(0, QuestionTopic.MATH, "question 2", 100));
            s_dal.Question.Create(new Question(0, QuestionTopic.MATH, "question 3", 100));
            s_dal.Question.Create(new Question(0, QuestionTopic.MATH, "question 4", 100));
            s_dal.Question.Create(new Question(0, QuestionTopic.MATH, "question 5", 100));
        }
        private static void CreateExam()
        {
            s_dal.Exam.Create(new Exam(0, ExamTopic.MATH, DateTime.Now,5));

        }
    }
}
