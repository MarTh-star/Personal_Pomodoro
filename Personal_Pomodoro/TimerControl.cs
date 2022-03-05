using System;
using System.Collections.Generic;
using System.Text;

namespace Personal_Pomodoro
{
    class TimerControl
    {
        int count = 0;
        public int breaks { get; set; }

        public TimerControl()
        {

        }

        public int TimeDecider()
        {
            int tme = 0;

           
            if(count%2 == 0)
            {
                //Pomodoro
                tme = 1;
                BreakCounter();
              
            }
             else if (count == 4)
            {
                //Long break
                tme = 1;

            } else
            {
                //Short break
                tme = 1;
               
            }

            count++;
            return tme;
        }

        public int BreakCounter()
        {
           return breaks++;
        }
    }
}
