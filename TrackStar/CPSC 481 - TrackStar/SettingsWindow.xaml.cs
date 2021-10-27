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
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if(off.IsChecked == true)
            {
                workoutReminders.SelectedItem = off1;
                mealReminders.SelectedItem = off2;
                newPrograms.SelectedItem = off3;               
                motivationalMessages.SelectedItem = off4;

                workoutReminders.IsEnabled = false;
                mealReminders.IsEnabled = false;
                newPrograms.IsEnabled = false;
                motivationalMessages.IsEnabled = false;
            }
            
        }

        private void on_Checked(object sender, RoutedEventArgs e)
        {
            if (on.IsChecked == true)
            {
                workoutReminders.IsEnabled = true;
                mealReminders.IsEnabled = true;
                newPrograms.IsEnabled = true;
                motivationalMessages.IsEnabled = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            InfoWindow infoWindow = new InfoWindow();
            this.Visibility = Visibility.Hidden;
            infoWindow.Show();
        }
    }
}
