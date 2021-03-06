using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Personal_Pomodoro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ToDo w = new ToDo();
        TimerControl y = new TimerControl();
        int time = 0;
        int count = 0;


        private DispatcherTimer Timer;
        //int breaks = 0;
        public MainWindow()
        {
            InitializeComponent();
            //time = y.TimeDecider();

    }

    void Timer_Tick(object sender, EventArgs e)
        {
            
                if (time > 0)
                {
                    if (time <= 10)
                    {
                        if (time % 2 == 0)
                        {
                            CountDown.Foreground = Brushes.BlueViolet;
                        }
                        else
                        {
                            CountDown.Foreground = Brushes.Black;
                        }
                        time--;
                        CountDown.Text = string.Format("{0:00}:{1:00}:{2:00}", time / 3600, (time / 60) % 60, time % 60);
                    }
                    else
                    {
                        time--;
                        CountDown.Text = string.Format("{0:00}:{1:00}:{2:00}", time / 3600, (time / 60) % 60, time % 60);
                    }
                }
                else
                {
                    Timer.Stop();
                    currentTask.Text = "Time for a break";
                    count = 0;
                    finishedPoms.Text = "You have finished " + y.breaks + " Pomodoro(s) today!";
                if (w.Task.Count == 0)
                    {
                        CountDown.Text = "00:00:00";
                        MessageBox.Show("There are no more tasks in list. Good work today!");
                    }
                }
            
            
        }

        private void Start_Button_Click(object sender, RoutedEventArgs e)
        {
            if (count == 0)
            {
                Timer = new DispatcherTimer();
                Timer.Interval = new TimeSpan(0, 0, 1);
                Timer.Tick += Timer_Tick;
                Timer.Start();
                currentTask.Text = w.CurrentTask();
                listOfToDo.ItemsSource = null;
                nrOfTimesToDo.ItemsSource = null;
                listOfToDo.ItemsSource = w.taskList();
                nrOfTimesToDo.ItemsSource = w.numberList();
                time = y.TimeDecider();
                count++;
            }
            
            
            else
            {
                Timer.Start();

            }
         

        }


        private void Stop_Button_Click(object sender, RoutedEventArgs e)
        {
            Timer.Stop();
        }
        //added the ability to add new things to the list of items currently in the listbox
        private void addTaskButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                w.addToList(addTask.Text, Int32.Parse(nrOfTask.Text));
            }
            catch (Exception)
            {

                MessageBox.Show("Please make sure you enter a valid number into number box.");
            }
            listOfToDo.ItemsSource = null;
            nrOfTimesToDo.ItemsSource = null;
            listOfToDo.ItemsSource = w.taskList();
            nrOfTimesToDo.ItemsSource = w.numberList();
        }

        private void Reset_Button_Click(object sender, RoutedEventArgs e)
        {
            Timer.Start();
            time = y.TimeDecider();
            
        }
    }
}
