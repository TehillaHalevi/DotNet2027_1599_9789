using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalApi
{
    public interface IDal
    {
        IStudent Student { get; }
        IExam Exam { get; }
        IQuestion Question { get; }
        IExamineeQuestion ExamineeQuestion { get; }
        IAnswer Answer { get; }

    }
}
