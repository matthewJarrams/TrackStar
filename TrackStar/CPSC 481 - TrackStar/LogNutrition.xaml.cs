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
    /// Interaction logic for LogNutrition.xaml
    /// </summary>
    public partial class LogNutrition : Window
    {
        public LogNutrition()
        {
            InitializeComponent();
            datePicker.SelectedDate = DateTime.Today;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            int calorieIntake = int.Parse(calsConsumed.Text);
            int caloriesBurned = int.Parse(calsBurned.Text);
            int calDifference = calorieIntake - caloriesBurned;
            calTarget.Content = calDifference;

            if (calDifference > 2000)
            {
                calorieChecker.Fill = new SolidColorBrush(Colors.Red);
                
            }
            else
            {
                calorieChecker.Fill = new SolidColorBrush(Colors.Green);
            }
        }

        private void DatePicker_CalendarClosed(object sender, RoutedEventArgs e)
        {
            calsConsumed.Text = "0";
            calsBurned.Text = "0";
        }
    }
}
