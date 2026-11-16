using DalApi;
using DO;
using Exceptions;
using System.Reflection;
using Tools;
using static Dal.DataSource;

namespace Dal
{
    internal class ExamineeOuestionImplementation : IExamineeQuestion
    {
        public int Create(ExamineeQuestion item)
        {
            WirteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
            , "Create question for examinee");

            ExamineeQuestion exq = item with { examineeQuestionId = Config.ExamineeOuestionId };
            examineeQuestions.Add(exq);
            WirteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
            , "The question for examinee was successfully created with ID: " + exq.examineeQuestionId);
            return exq.examineeQuestionId;
        }

        public void Delete(int id)
        {

            WirteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
           , "Delete question for examinee " + id);
            int index = examineeQuestions.FindIndex(x => x?.examineeQuestionId == id);
            try
            {
                examineeQuestions.RemoveAt(index);
            }
            catch (NotExistException e)
            {
                WirteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
                , $"Not found question for examinee {id} to delete");
                wirteToLog(e.Message);
                throw new NotExistException($"A question for examinee of Id: {id} not exist", e);
            }
            WirteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
            , "The question for examinee was successfully deleted with ID: " + id);

        }

        public ExamineeQuestion? Read(int id)
        {
            WirteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
            , "Read question for examinee " + id);
            int index = examineeQuestions.FindIndex(x => x?.examineeQuestionId == id);
            if (index == -1)
            {
                WirteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
                , $"Not found to read question for examinee " + id);
                return null;
            }
            return examineeQuestions[index];
        }

        public List<ExamineeQuestion> ReadAll()
        {
            return new List<ExamineeQuestion>(examineeQuestions);
        }

        public void Update(ExamineeQuestion item)
        {
            WirteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
            , "Update question for examinee " + item.examId);
            int index = examineeQuestions.FindIndex(x => x?.examineeQuestionId == item.examineeQuestionId);
            try
            {
                examineeQuestions.Remove(examineeQuestions[index]);
                examineeQuestions.Add(item);
            }
            catch (NotExistException e)
            {
                WirteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
                , $"Not found question for examinee {item.examId} to update");
                wirteToLog(e.Message);
                throw new NotExistException($"A question for examinee of Id: {item.examineeQuestionId} not exist", e);
            }

            WirteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name
            , "The question for examinee was successfully updated with ID: " + item.examId);

        }
    }
}
