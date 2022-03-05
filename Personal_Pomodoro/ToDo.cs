using System;
using System.Collections.Generic;
using System.Text;

namespace Personal_Pomodoro
{
    public class ToDo
    {
        //List<Tuple<string, int>> ts { get; set; }

        List<string> Task = new List<string>();
        List<int> Amount = new List<int>();
        int a = 0;
        public ToDo()
        {

        }

        public List<string> taskList()
        {
            return Task;
        }

        public List<int> numberList()
        {
            return Amount;
        }
        public string CurrentTask()
        {
            string currentTask = Task[a];
            if(Task[a +1] == null)
            {
                a = 0;
            } else
            {
                a++;

            }

            NumberForTask();

            return currentTask;
        }

        public int NumberForTask()
        {
            Amount[a]--;
            return Amount[a];
        }

        public void addToList(string task, int nr)
        {
            Task.Add(task);
            Amount.Add(nr);
            return;
        }
    }
}
