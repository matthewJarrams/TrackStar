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
        public NewGoalDialog(personalRecord pr)
        {
            InitializeComponent();
            prOnScreen = pr;
            newVal.Text = pr.value.ToString();
            titleGoal.Text = pr.goal.ToString();
            goldlbl.Content = pr.type;
            
        }

        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            
            
            
            if (int.Parse(titleGoal.Text) != prOnScreen.goal)
            {
                
                prOnScreen.SetNewGoal(int.Parse(titleGoal.Text));
                prOnScreen.SetNewValue(int.Parse(newVal.Text));

            }
            else if (int.Parse(newVal.Text) != prOnScreen.value)
            {
                prOnScreen.SetNewValue(int.Parse(newVal.Text));
                prOnScreen.SetNewGoal(int.Parse(titleGoal.Text));
            }

            MainWindow.goalsWindow.Visibility = Visibility.Hidden;
            //goalWindow.Visibility = Visibility.Hidden;
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
            this.Visibility = Visibility.Hidden;

        }
    }
}
