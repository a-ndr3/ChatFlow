using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatFlow
{
    internal class ClassesGPT
    {
        internal class AnswerGPT
        {
            public string Question { get; set; }
            public string[] Answers { get; set; }
            public string DateInUTC { get; set; }
            public AnswerGPT(string question, string[] answers, string dateTimeInUtc = null)
            {
                Question = question;
                Answers = answers;

                if (dateTimeInUtc != null)
                {
                    DateInUTC = dateTimeInUtc;
                }
                else
                {
                    DateInUTC = DateTime.UtcNow.ToString();
                }
            }

        }     
    }
}
