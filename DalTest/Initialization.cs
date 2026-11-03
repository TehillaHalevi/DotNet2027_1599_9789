using DO;
using DalApi;

namespace DalTest
{
    public static class Initialization
    {
        static IDal s_dal;
        public static void Initialize(IDal dal)
        {
            s_dal = dal;
            CreateStudents();
            CreateAnswer();
            CreateQuestion();
            CreateExam();
            CreateExamineeQuestion();
        }
        private static void CreateAnswer()
        {
            s_dal.Answer.Create(new Answer(0, 100, "answer 1"));
            s_dal.Answer.Create(new Answer(0, 100, "answer 2"));
            s_dal.Answer.Create(new Answer(0, 100, "answer 3"));
            s_dal.Answer.Create(new Answer(0, 100, "answer 4"));

            s_dal.Answer.Create(new Answer(0, 101, "answer 1"));
            s_dal.Answer.Create(new Answer(0, 101, "answer 2"));
            s_dal.Answer.Create(new Answer(0, 101, "answer 3"));
            s_dal.Answer.Create(new Answer(0, 101, "answer 4"));

            s_dal.Answer.Create(new Answer(0, 102, "answer 1"));
            s_dal.Answer.Create(new Answer(0, 102, "answer 2"));
            s_dal.Answer.Create(new Answer(0, 102, "answer 3"));
            s_dal.Answer.Create(new Answer(0, 102, "answer 4"));

            s_dal.Answer.Create(new Answer(0, 103, "answer 1"));
            s_dal.Answer.Create(new Answer(0, 103, "answer 2"));
            s_dal.Answer.Create(new Answer(0, 103, "answer 3"));
            s_dal.Answer.Create(new Answer(0, 103, "answer 4"));

            s_dal.Answer.Create(new Answer(0, 104, "answer 1"));
            s_dal.Answer.Create(new Answer(0, 104, "answer 2"));
            s_dal.Answer.Create(new Answer(0, 104, "answer 3"));
            s_dal.Answer.Create(new Answer(0, 104, "answer 4"));
        }
        private static void CreateExamineeQuestion()
        {
            s_dal.ExamineeQuestion.Create(new ExamineeQuestion(0, 111, 100, 100, 100));
            s_dal.ExamineeQuestion.Create(new ExamineeQuestion(0, 111, 100, 101, 100));
            s_dal.ExamineeQuestion.Create(new ExamineeQuestion(0, 111, 100, 102, 103));
            s_dal.ExamineeQuestion.Create(new ExamineeQuestion(0, 111, 100, 103, 100));
            s_dal.ExamineeQuestion.Create(new ExamineeQuestion(0, 111, 100, 104, 102));

            s_dal.ExamineeQuestion.Create(new ExamineeQuestion(0, 222, 100, 100, 104));
            s_dal.ExamineeQuestion.Create(new ExamineeQuestion(0, 222, 100, 101, 100));
            s_dal.ExamineeQuestion.Create(new ExamineeQuestion(0, 222, 100, 102, 103));
            s_dal.ExamineeQuestion.Create(new ExamineeQuestion(0, 222, 100, 103, 101));
            s_dal.ExamineeQuestion.Create(new ExamineeQuestion(0, 222, 100, 104, 100));

            s_dal.ExamineeQuestion.Create(new ExamineeQuestion(0, 333, 100, 100, 100));
            s_dal.ExamineeQuestion.Create(new ExamineeQuestion(0, 333, 100, 101, 100));
            s_dal.ExamineeQuestion.Create(new ExamineeQuestion(0, 333, 100, 102, 103));
            s_dal.ExamineeQuestion.Create(new ExamineeQuestion(0, 333, 100, 103, 101));
            s_dal.ExamineeQuestion.Create(new ExamineeQuestion(0, 333, 100, 104, 100));

            s_dal.ExamineeQuestion.Create(new ExamineeQuestion(0, 444, 100, 100, 104));
            s_dal.ExamineeQuestion.Create(new ExamineeQuestion(0, 444, 100, 101, 100));
            s_dal.ExamineeQuestion.Create(new ExamineeQuestion(0, 444, 100, 102, 102));
            s_dal.ExamineeQuestion.Create(new ExamineeQuestion(0, 444, 100, 103, 101));
            s_dal.ExamineeQuestion.Create(new ExamineeQuestion(0, 444, 100, 104, 104));

            s_dal.ExamineeQuestion.Create(new ExamineeQuestion(0, 555, 100, 100, 102));
            s_dal.ExamineeQuestion.Create(new ExamineeQuestion(0, 555, 100, 101, 102));
            s_dal.ExamineeQuestion.Create(new ExamineeQuestion(0, 555, 100, 102, 103));
            s_dal.ExamineeQuestion.Create(new ExamineeQuestion(0, 555, 100, 103, 101));
            s_dal.ExamineeQuestion.Create(new ExamineeQuestion(0, 555, 100, 104, 100));
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
