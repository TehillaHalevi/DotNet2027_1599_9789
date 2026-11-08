using DO;
using DalApi;
namespace DalTest
{
    public static class Initialization
    {
        static IDal s_dal;

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

        }
    }
}
