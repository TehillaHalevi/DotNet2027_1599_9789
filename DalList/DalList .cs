
using DalApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
     sealed internal class DalList : IDal
    {
        static private  readonly DalList instance= new DalList();
        static public DalList Instance { get { return instance; } }
        private DalList()
        {

        }
        public IStudent Student => new StudentImplementation();
        public IExam Exam =>  new ExamImplementation();

        public IQuestion Question =>  new QuestionImplementation();

        public IExamineeQuestion ExamineeQuestion => new ExamineeQuestionImplementation();

        public IAnswer Answer =>  new AnswerImplementation();
    }
}
