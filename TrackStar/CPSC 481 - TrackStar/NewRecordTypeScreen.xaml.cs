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
        public static int value;
        public static int goal;
        public string type = "null";

        public NewRecordTypeScreen()
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

        }

        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.goalsWindow.Visibility = Visibility.Hidden;
            recordType = titleGoal.Text;
            if(type.Equals("Hr: Min:Seconds"))
            {
               
            }
            else
            {
                value = int.Parse(curVal.Text);
                goal = int.Parse(goalVal.Text);
            }
            
            personalRecord newRecord = new personalRecord(recordType, goal, type, value);
            Goals.recordList.Add(newRecord);
            Goals.tableList.Add(newRecord);
            Goals goalScreen = new Goals();
            this.Visibility = Visibility.Hidden;
            goalScreen.Show();
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
            goalScreen.Show();
        }
        
    }
}
