
using DO;
     namespace Dal
    {
    static internal class DataSource{
        static internal List<Answer> answers = new List<Answer>();
        static internal List<Exam> exams = new List<Exam>();
        static internal List<Student> students = new List<Student>();
        static internal List<Question> questions = new List<Question>();
        static internal List<ExamineeOuestion> examineeQuestions = new List<ExamineeOuestion>();
        static internal class Config
        {
           //שדה רץ עבור המחלקה answer
            internal const int minAnswerId = 100;
            static private int answerId=minAnswerId;
            public static int AnswerId => answerId++;


            //שדה רץ עבור המחלקה ExamineeOuestion
            internal const int minExamineeOuestionId = 100;
            static private int examineeOuestionId = minExamineeOuestionId;
            public static int ExamineeOuestionId => examineeOuestionId++;


            //שדה רץ עבור המחלקה Exam
            internal const int minExamId = 100;
            static private int examId = minExamId;
            public static int ExamId => examId++;


            //שדה רץ עבור המחלקה question
            internal const int minQuestionId = 100;
            static private int questionId = minQuestionId;
            public static int QuestionId => questionId++;

        }
    }
    
    }
