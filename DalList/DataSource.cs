
using DO;
     namespace Dal
    {
    static internal class DataSource{
        static internal List<Answer> answers = new List<Answer>();
        static internal List<Exam> exams = new List<Exam>();
        static internal List<Student> students = new List<Student>();
        static internal List<Question> questions = new List<Question>();
        static internal List<ExamineeOuestion> examineeOuestions = new List<ExamineeOuestion>();
        static internal class Config
        {
           //שדה רץ עבור המחלקה answer
            internal const int minAnswerId = 100;
            static private int answerId=minAnswerId;
            public static int AnswerId => answerId++;


            //שדה רץ עבור המחלקה student
            internal const int minStudentId = 100;
            static private int studentId = minStudentId;
            public static int StudentId => studentId++;


            //שדה רץ עבור המחלקה student
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
