using System;
using System.Collections.Generic;
using System.Text;

namespace Personal_Pomodoro
{
    public class ToDo
    {
        //List<Tuple<string, int>> ts { get; set; }

        public List<string> Task = new List<string>();
        public List<int> Amount = new List<int>();
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
            string currentTask = "";
            try
            {
                
                if (Task[a] == Task[Task.Count - 1])
                {

                    a = 0;
                    NumberForTask();
                    currentTask = Task[a];


                }
                else
                {
                    a = 0;
                    currentTask = Task[a];
                    NumberForTask();
                   // a++;

                }
                if (Amount[a] == 0)
                {
                    currentTask = Task[a];
                    Amount.Remove(Amount[a]);
                    Task.Remove(Task[a]);
                    a = 0;



                }

                return currentTask;

            }
            catch (Exception)
            {
                return currentTask = " ";
               
            }


        }

        public int NumberForTask()
        {

            try
            {
                Amount[a] = Amount[a] - 1;
                if (Amount[a] == 0)
                {
                    Amount.Remove(Amount[a]);
                    Task.Remove(Task[a]);
                    a = 0;
                }
            
                return Amount[a];

            }
            catch (Exception)
            {

                return 0;
            }
           
        }

        public void addToList(string task, int nr)
        {
            Task.Add(task);
            Amount.Add(nr);
            return;
        }
    }
}
