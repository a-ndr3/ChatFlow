using Microsoft.Maui.ApplicationModel.Communication;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatFlow
{
    internal class HistoryCollection : IEnumerable<ClassesGPT.AnswerGPT>
    {
        private ObservableCollection<ClassesGPT.AnswerGPT> answers;

        public HistoryCollection()
        {
            answers = new ObservableCollection<ClassesGPT.AnswerGPT>();
        }

        //TODO check datetime of chat, probably will be different depends on answers, now I use NOW date
        public HistoryCollection(Dictionary<string, string[]> data)
        {
            foreach (var item in data)
            {
                answers.Add(new ClassesGPT.AnswerGPT(item.Key, item.Value));
            }
        }
        public void Add(ClassesGPT.AnswerGPT answer)
        {
            answers.Add(answer);
        }
        public void Remove(ClassesGPT.AnswerGPT answer)
        {
            answers.Remove(answer);
        }
        public void Clear()
        {
            answers.Clear();
        }
        public ObservableCollection<ClassesGPT.AnswerGPT> GetAnswers()
        {
            return answers;
        }

        public IEnumerator<ClassesGPT.AnswerGPT> GetEnumerator()
        {
            return answers.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
