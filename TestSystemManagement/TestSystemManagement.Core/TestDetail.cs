using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestSystemManagement.Core
{
    public class TestDetail
    {
        public int Id { get; set; }

        public string Question { get; set; }

        public string AnswerA { get; set; }

        public string AnswerB { get; set; }

        public string AnswerC { get; set; }

        public string AnswerD { get; set; }

        public string CorrectAnswer { get; set; }

        public int TypeOfQuestion { get; set; }

        public double Point { get; set; }

        public TestChildSubject TestChildSubject { get; set; }
        public Users User { get; set; }
        public ICollection<Result> Result { get; set; }
    }
}