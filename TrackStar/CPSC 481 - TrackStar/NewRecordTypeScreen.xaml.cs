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
    /// Interaction logic for NewRecordTypeScreen.xaml
    /// </summary>
    public partial class NewRecordTypeScreen : Window
    {
        public static string recordType;
        public static double value;
        public static double goal;
        public string type = "null";
        public static double num;
        public Goals gw;

        public NewRecordTypeScreen(Goals gs)
        {
            InitializeComponent();
            
            curMin.Visibility = Visibility.Hidden;
            curSeconds.Visibility = Visibility.Hidden;

            goalSec.Visibility = Visibility.Hidden;
            goalMin.Visibility = Visibility.Hidden;
            colon1.Visibility = Visibility.Hidden;
            colon2.Visibility = Visibility.Hidden;
            colon3.Visibility = Visibility.Hidden;
            colon4.Visibility = Visibility.Hidden;

            format1.Visibility = Visibility.Hidden;
            format2.Visibility = Visibility.Hidden;
            goalVal.IsEnabled = false;
            curVal.IsEnabled = false;
            btnDialogOk.IsEnabled = false;
            this.gw = gs;

        }

        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            bool goalvalb = double.TryParse(goalVal.Text, out num);
            bool goalMinb = double.TryParse(goalMin.Text, out num);
            bool goalSecb = double.TryParse(goalSec.Text, out num);
            bool curvalb = double.TryParse(curVal.Text, out num);
            bool curMinb = double.TryParse(curMin.Text, out num);
            bool curSecb = double.TryParse(curSeconds.Text, out num);
            if (goalvalb && goalMinb && goalSecb && curvalb && curMinb && curSecb)
            {
                MainWindow.goalsWindow.Visibility = Visibility.Hidden;
                recordType = titleGoal.Text;
                double hoursCur = 0;
                if (type.Equals("Hr:Min:Seconds"))
                {
                    hoursCur = double.Parse(curVal.Text);
                    double minsCur = double.Parse(curMin.Text);
                    double secsCur = double.Parse(curSeconds.Text);

                    double hoursGoal = double.Parse(goalVal.Text);
                    double minsGoal = double.Parse(goalMin.Text);
                    double secsGoal = double.Parse(goalSec.Text);
                    if (hoursCur == 0)
                    {
                        value = minsCur + (secsCur / 60);
                        recordType = recordType + " (Mins)";

                        goal = minsGoal + (secsGoal / 60);

                    }
                    else
                    {
                        value = hoursCur + (minsCur / 60 + secsCur / 3600);
                        recordType = recordType + " (Hrs)";
                        goal = hoursGoal + (minsGoal / 60 + secsGoal / 3600);
                    }

                }
                else
                {
                    value = double.Parse(curVal.Text);
                    goal = double.Parse(goalVal.Text);
                }

                value = Math.Round(value, 2);
                goal = Math.Round(goal, 2);
                bool increasing;
                if (goal - value > 0)
                {
                    increasing = true;
                }
                else
                {
                    increasing = false;
                }

                List<String> Labels = new List<String>() { "Dec 14" };
                personalRecord newRecord = new personalRecord(recordType, goal, type, value, increasing, Labels);

                if (hoursCur == 0)
                {
                    newRecord.setHours(false);
                }
                else
                {
                    newRecord.setHours(true);
                }
                Goals.recordList.Insert(0, newRecord);
                Goals.tableList.Insert(0, newRecord);
                Goals goalScreen = new Goals();
                this.Visibility = Visibility.Hidden;
                gw.Visibility = Visibility.Hidden;
                goalScreen.Show();

                InfoWindow.selectedIndex++;

            }
            else
            {
               
                    if (goalvalb == false) goalVal.BorderBrush = Brushes.Red;
                    else goalVal.BorderBrush = Brushes.Teal;

                    if (goalMinb == false) goalMin.BorderBrush = Brushes.Red;
                    else goalMin.BorderBrush = Brushes.Teal;

                    if (goalSecb == false) goalSec.BorderBrush = Brushes.Red;
                    else goalSec.BorderBrush = Brushes.Teal;

                    if (curvalb == false) curVal.BorderBrush = Brushes.Red;
                    else curVal.BorderBrush = Brushes.Teal;

                    if (curMinb == false) curMin.BorderBrush = Brushes.Red;
                    else curMin.BorderBrush = Brushes.Teal;

                    if (curSecb == false) curSeconds.BorderBrush = Brushes.Red;
                    else curSeconds.BorderBrush = Brushes.Teal;

               
            }
        }

        private void Goaler_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(Goaler.SelectedItem == Time)
            {
                curMin.Visibility = Visibility.Visible;
                curSeconds.Visibility = Visibility.Visible;

                goalSec.Visibility = Visibility.Visible;
                goalMin.Visibility = Visibility.Visible;
                colon1.Visibility = Visibility.Visible;
                colon2.Visibility = Visibility.Visible;
                colon3.Visibility = Visibility.Visible;
                colon4.Visibility = Visibility.Visible;

                format1.Visibility = Visibility.Visible;
                format2.Visibility = Visibility.Visible;
                goalVal.IsEnabled = true;
                curVal.IsEnabled = true;
                curMin.IsEnabled = true;
                curSeconds.IsEnabled = true;
                goalSec.IsEnabled = true;
                goalMin.IsEnabled = true;
                btnDialogOk.IsEnabled = true;

                

                format3.Content = "";
                format4.Content = "";

                type = "Hr:Min:Seconds";

            }
            if(Goaler.SelectedItem == Weight)
            {
                curMin.Visibility = Visibility.Hidden;
                curSeconds.Visibility = Visibility.Hidden;

                goalSec.Visibility = Visibility.Hidden;
                goalMin.Visibility = Visibility.Hidden;
                colon1.Visibility = Visibility.Hidden;
                colon2.Visibility = Visibility.Hidden;
                colon3.Visibility = Visibility.Hidden;
                colon4.Visibility = Visibility.Hidden;
                format3.Content = "lbs";
                format4.Content = "lbs";
                format1.Visibility = Visibility.Hidden;
                format2.Visibility = Visibility.Hidden;
                type = "Lbs";
                goalVal.IsEnabled = true;
                curVal.IsEnabled = true;
                btnDialogOk.IsEnabled = true;
            }
            if (Goaler.SelectedItem == Distance)
            {
                curMin.Visibility = Visibility.Hidden;
                curSeconds.Visibility = Visibility.Hidden;

                goalSec.Visibility = Visibility.Hidden;
                goalMin.Visibility = Visibility.Hidden;
                colon1.Visibility = Visibility.Hidden;
                colon2.Visibility = Visibility.Hidden;
                colon3.Visibility = Visibility.Hidden;
                colon4.Visibility = Visibility.Hidden;

                format3.Content = "Km";
                format4.Content = "Km";

                format1.Visibility = Visibility.Hidden;
                format2.Visibility = Visibility.Hidden;
                type = "Kilometers";
                goalVal.IsEnabled = true;
                curVal.IsEnabled = true;
                btnDialogOk.IsEnabled = true;
            }
            if (Goaler.SelectedItem == Count)
            {
                curMin.Visibility = Visibility.Hidden;
                curSeconds.Visibility = Visibility.Hidden;

                goalSec.Visibility = Visibility.Hidden;
                goalMin.Visibility = Visibility.Hidden;
                colon1.Visibility = Visibility.Hidden;
                colon2.Visibility = Visibility.Hidden;
                colon3.Visibility = Visibility.Hidden;
                colon4.Visibility = Visibility.Hidden;
                format3.Content = "";
                format4.Content = "";

                format1.Visibility = Visibility.Hidden;
                format2.Visibility = Visibility.Hidden;
                type = "Number";
                goalVal.IsEnabled = true;
                curVal.IsEnabled = true;
                btnDialogOk.IsEnabled = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.goalsWindow.Visibility = Visibility.Hidden;
            Goals goalScreen = new Goals();
            this.Visibility = Visibility.Hidden;
            gw.Visibility = Visibility.Hidden;
            goalScreen.Show();
        }
        
    }
}
