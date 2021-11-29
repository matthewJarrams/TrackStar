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
using System.Windows.Shapes;

namespace CPSC_481___TrackStar
{
    /// <summary>
    /// Interaction logic for NewGoalDialog.xaml
    /// </summary>
    public partial class NewGoalDialog : Window
    {
        public static String response;
        public Goals goalWindow = Application.Current.Windows.OfType<Goals>().First();
        public static personalRecord prOnScreen;
        public Goals gw;
        public static bool goalcompleted = false;
        public NewGoalDialog(personalRecord pr, Goals gs)
        {
            InitializeComponent();
            prOnScreen = pr;
            
            //newVal.Text = pr.value.ToString();
            //goalVal.Text = pr.goal.ToString();
            goldlbl.Content = pr.type;

            goalMin.Visibility = Visibility.Hidden;
            goalSec.Visibility = Visibility.Hidden;
            colon1.Visibility = Visibility.Hidden;
            colon2.Visibility = Visibility.Hidden;
            colon3.Visibility = Visibility.Hidden;
            colon4.Visibility = Visibility.Hidden;
            format.Visibility = Visibility.Hidden;
            newValMin.Visibility = Visibility.Hidden;
            newValSec.Visibility = Visibility.Hidden;
            this.gw = gs;

            if (pr.acttype.Equals("Hr:Min:Seconds"))
            {
                goalMin.Visibility = Visibility.Visible;
                goalSec.Visibility = Visibility.Visible;
                colon1.Visibility = Visibility.Visible;
                colon2.Visibility = Visibility.Visible;
                colon3.Visibility = Visibility.Visible;
                colon4.Visibility = Visibility.Visible;
                format.Visibility = Visibility.Visible;
                newValMin.Visibility = Visibility.Visible;
                newValSec.Visibility = Visibility.Visible;

                if (pr.hours == false)
                {
                    double seconds = pr.value * 60;
                    double goalSecs = pr.goal * 60;

                    newVal.Text = "0";
                    goalVal.Text = "0";

                    int minutes = (int)seconds / 60;
                    int goalMinutes = (int)goalSecs / 60;

                    goalSecs = goalSecs % 60;
                    seconds = seconds % 60;

                    goalMin.Text = goalMinutes.ToString();
                    newValMin.Text = minutes.ToString();

                    seconds = Math.Round(seconds);
                    goalSecs = Math.Round(goalSecs);

                    newValSec.Text = seconds.ToString();
                    goalSec.Text = goalSecs.ToString();
                }
                else
                {
                    double seconds = pr.value * 3600;
                    double goalSecs = pr.goal * 3600;

                    int hours = (int)seconds / 3600;
                    int hoursgoal = (int)goalSecs / 3600;

                    seconds = seconds % 3600;
                    goalSecs = goalSecs % 3600;

                    int minutes = (int)seconds / 60;
                    int goalMinutes = (int)goalSecs / 60;

                    goalSecs = goalSecs % 60;
                    seconds = seconds % 60;

                    goalMin.Text = goalMinutes.ToString();
                    newValMin.Text = minutes.ToString();

                    seconds = Math.Round(seconds);
                    goalSecs = Math.Round(goalSecs);

                    newValSec.Text = seconds.ToString();
                    goalSec.Text = goalSecs.ToString();

                    newVal.Text = hours.ToString();
                    goalVal.Text = hoursgoal.ToString();
                }
            }
            else
            {
                newVal.Text = pr.value.ToString();
                goalVal.Text = pr.goal.ToString();
            }


        }
        
        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {


            
             if (double.Parse(goalVal.Text) != prOnScreen.goal)
             {
                 if (prOnScreen.acttype.Equals("Hr:Min:Seconds"))
                 {
                     double goal2;
                     double value2;

                     double hoursGoal = double.Parse(goalVal.Text);
                     double minsGoal= double.Parse(goalMin.Text);
                     double secsGoal = double.Parse(goalSec.Text);

                     double hoursCur = double.Parse(newVal.Text);
                     double minsCur = double.Parse(newValMin.Text);
                     double secsCur = double.Parse(newValSec.Text);


                     if (hoursGoal == 0)
                     {

                         goal2 = minsGoal + (secsGoal / 60);
                         goal2 = Math.Round(goal2, 2);
                         prOnScreen.SetNewGoal(goal2);

                         value2 = minsCur + (secsCur / 60);
                         value2 = Math.Round(value2, 2);
                         prOnScreen.SetNewValue(value2);
                         prOnScreen.setHours(false);
                    }
                     else
                     {

                         goal2 = hoursGoal + (minsGoal / 60 + secsGoal / 3600);
                         goal2 = Math.Round(goal2, 2);
                         prOnScreen.SetNewGoal(goal2);

                         value2 = hoursCur + (minsCur / 60 + secsCur / 3600);
                         value2 = Math.Round(value2, 2);
                         prOnScreen.SetNewValue(value2);
                        prOnScreen.setHours(true);
                    }
                 }
                 else
                 {
                     prOnScreen.SetNewGoal(double.Parse(goalVal.Text));
                     prOnScreen.SetNewValue(double.Parse(newVal.Text));
                 }

             }
             else if (double.Parse(newVal.Text) != prOnScreen.value)
             {

                 if(prOnScreen.acttype.Equals("Hr:Min:Seconds"))
                 {
                     double goal3;
                     double value3;

                     double hoursCur = double.Parse(newVal.Text);
                     double minsCur = double.Parse(newValMin.Text);
                     double secsCur = double.Parse(newValSec.Text);

                     double hoursGoal = double.Parse(goalVal.Text);
                     double minsGoal = double.Parse(goalMin.Text);
                     double secsGoal = double.Parse(goalSec.Text);


                     if (hoursCur == 0)
                     {


                        value3 = minsCur + (secsCur / 60);
                        value3 = Math.Round(value3, 2);
                        prOnScreen.SetNewValue(value3);

                        goal3 = minsGoal + (secsGoal / 60);
                        goal3 = Math.Round(goal3, 2);
                        prOnScreen.SetNewGoal(goal3);
                        prOnScreen.setHours(false);

                     }
                     else
                     {

                         value3 = hoursCur + (minsCur / 60 + secsCur / 3600);
                         value3 = Math.Round(value3, 2);
                         prOnScreen.SetNewValue(value3);

                         goal3 = hoursGoal + (minsGoal / 60 + secsGoal / 3600);
                         goal3 = Math.Round(goal3, 2);
                         prOnScreen.SetNewGoal(goal3);
                         prOnScreen.setHours(true);

                    }
                }
                 else
                 {
                     prOnScreen.SetNewValue(double.Parse(newVal.Text));
                     prOnScreen.SetNewGoal(double.Parse(goalVal.Text));
                 }
             }
            if(prOnScreen.increasing == true)
            {
                if(prOnScreen.value >= prOnScreen.goal)
                {
                    Poper1.IsOpen = true;
                    goalcompleted = true;
                }
              
            }
            if(prOnScreen.increasing == false)
            {
                if(prOnScreen.value <= prOnScreen.goal)
                {
                    Poper1.IsOpen = true;
                    goalcompleted = true;
                }
            }


            //MainWindow.goalsWindow.Visibility = Visibility.Hidden;
            //goalWindow.Visibility = Visibility.Hidden;
            gw.Visibility = Visibility.Hidden;
            Goals goalScreenNew = new Goals();
            this.Visibility = Visibility.Hidden;
            goalScreenNew.Show();

        }


        private void btnDialogDelete_Click(object sender, RoutedEventArgs e)
        {
            
            Poper.IsOpen = true;

           // MainWindow.goalsWindow.Visibility = Visibility.Hidden;
            //goalWindow.Visibility = Visibility.Hidden;
            //Goals goalScreenNew = new Goals();
            //this.Visibility = Visibility.Hidden;
            //goalScreenNew.Show();

        }

        private void yesDelete_Click(object sender, RoutedEventArgs e)
        {
            Goals.recordList.Remove(prOnScreen);
            Goals.tableList.Remove(prOnScreen);
            Poper.IsOpen = false;
            MainWindow.goalsWindow.Visibility = Visibility.Hidden;
            goalWindow.Visibility = Visibility.Hidden;
            Goals goalScreenNew = new Goals();
            this.Visibility = Visibility.Hidden;
            goalScreenNew.Show();
        }

        private void noDelete_Click(object sender, RoutedEventArgs e)
        {
            
            Poper.IsOpen = false;
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            goalWindow.Visibility = Visibility.Hidden;
            Goals goalScreenNew = new Goals();
            this.Visibility = Visibility.Hidden;
            goalScreenNew.Show();

        }

        private void yesDelete_Click1(object sender, RoutedEventArgs e)
        {
            Goals.recordList.Remove(prOnScreen);
            Goals.tableList.Remove(prOnScreen);
            Poper1.IsOpen = false;
            goalcompleted = false;
            MainWindow.goalsWindow.Visibility = Visibility.Hidden;
            goalWindow.Visibility = Visibility.Hidden;
            Goals goalScreenNew = new Goals();
            this.Visibility = Visibility.Hidden;
            goalScreenNew.Show();
        }

        private void noDelete_Click1(object sender, RoutedEventArgs e)
        {
            MainWindow.goalsWindow.Visibility = Visibility.Hidden;
            
            Poper1.IsOpen = false;
            goalcompleted = false;
            goalWindow.Visibility = Visibility.Hidden;
            Goals goalScreenNew = new Goals();
            this.Visibility = Visibility.Hidden;
            goalScreenNew.Show();
        }
    }
}
