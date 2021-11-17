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
        public static String newProgram;
        public static int currentDay = 0;
        public Program progOnScreen;
        public ProgramScreen(Program prog)
        {
            InitializeComponent();
            //Window1.buildProgram();
            Workout test = prog.workouts[currentDay];
            lbTodoList.ItemsSource = test.ExerciseList;
            progOnScreen = prog;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lbTodoList.ItemsSource = null;
           
            lbTodoList.ItemsSource = progOnScreen.workouts[++currentDay].ExerciseList;
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            lbTodoList.ItemsSource = null;

            lbTodoList.ItemsSource = progOnScreen.workouts[--currentDay].ExerciseList;
        }

        private void back_Btn(object sender, RoutedEventArgs e)
        {
            Catalogue catWindow = new Catalogue();
            this.Visibility = Visibility.Hidden;
            catWindow.Show();
        }

        private void setProgramBtn(object sender, RoutedEventArgs e)
        {
            User.programDaysLeft = progOnScreen.length;
            User.currentProgramWorkoutsCompleted = 0;
            Button button = sender as Button;
            Program spec = button.DataContext as Program;
            User.currentProgram = progOnScreen;
        }

      


    }
}
