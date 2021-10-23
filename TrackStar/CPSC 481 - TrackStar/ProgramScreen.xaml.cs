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
    /// Interaction logic for ProgramScreen.xaml
    /// </summary>
    public partial class ProgramScreen : Window
    {
        public ProgramScreen(int source)
        {
            InitializeComponent();
            Window1.buildProgram();
            Workout test = Window1.cardio.workouts[0];
            lbTodoList.ItemsSource = test.ExerciseList;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lbTodoList.ItemsSource = null;
           
            lbTodoList.ItemsSource = Window1.cardio.workouts[1].ExerciseList;
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            lbTodoList.ItemsSource = null;

            lbTodoList.ItemsSource = Window1.cardio.workouts[0].ExerciseList;
        }

        private void back_Btn(object sender, RoutedEventArgs e)
        {
            Catalogue catWindow = new Catalogue();
            this.Visibility = Visibility.Hidden;
            catWindow.Show();
        }
    }
}
