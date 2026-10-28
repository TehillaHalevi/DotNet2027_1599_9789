using DalApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class DalList : IDal
    {
        public IStudent Student => new StudentImplementation();
        public IExam Exam =>  new ExamImplementation();

        public IQuestion Question =>  new QuestionImplementation();

        public IExamineeQuestion ExamineeQuestion => new ExamineeOuestionImplementation();

        public IAnswer Answer =>  new AnswerImplementation();
    }
}
