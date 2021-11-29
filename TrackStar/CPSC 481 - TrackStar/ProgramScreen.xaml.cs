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
        public int counter = 0;
        public ProgramScreen(Program prog)
        {
            currentDay = 0;
            InitializeComponent();
            setLabel.Visibility = Visibility.Hidden;
            Workout test = prog.workouts[currentDay];
            lbTodoList.ItemsSource = test.ExerciseList;
            progOnScreen = prog;
            programTitle.Content = progOnScreen.name;
            descripBox.Text = progOnScreen.description;
            Titl.Content = "Description";
            WorkLbl.Content = "Day " + progOnScreen.workouts[currentDay].Day;
            Prev.Visibility = Visibility.Hidden;

            if (User.currentProgram == progOnScreen)
            {
                setProgButton.Visibility = Visibility.Hidden;
                RemoveButton.Visibility = Visibility.Visible;
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lbTodoList.ItemsSource = null;
           
            lbTodoList.ItemsSource = progOnScreen.workouts[++currentDay].ExerciseList;
            WorkLbl.Content = "Day " + progOnScreen.workouts[currentDay].Day;
            Prev.Visibility = Visibility.Visible;
            if (currentDay + 1 == progOnScreen.workouts.Count)
            {
                Next.Visibility = Visibility.Hidden;
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            lbTodoList.ItemsSource = null;

            lbTodoList.ItemsSource = progOnScreen.workouts[--currentDay].ExerciseList;
            WorkLbl.Content = "Day " + progOnScreen.workouts[currentDay].Day;
            Next.Visibility = Visibility.Visible;
            if(currentDay == 0)
            {
                Prev.Visibility = Visibility.Hidden;
            }
        }

        private void back_Btn(object sender, RoutedEventArgs e)
        {
            Catalogue catWindow = new Catalogue();
            this.Visibility = Visibility.Hidden;
            catWindow.Show();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            // Button button = sender as Button;
            // Meals.MealPlans spec = button.DataContext as Meals.MealPlans;
            if (counter == 0)
            {
                // Titl.Content = "Goals";
                Titl.SetValue(TextBlock.FontWeightProperty, FontWeights.Light);
                lenghter.SetValue(TextBlock.FontWeightProperty, FontWeights.Bold);
                descripBox.Text = progOnScreen.lengthDes;
                counter++;


            }
            else if (counter == 1)
            {
                goalser.SetValue(TextBlock.FontWeightProperty, FontWeights.Bold);
                lenghter.SetValue(TextBlock.FontWeightProperty, FontWeights.Light);
                descripBox.Text = progOnScreen.goals;
                counter++;

            }
            else if (counter == 2)
            {
                goalser.SetValue(TextBlock.FontWeightProperty, FontWeights.Light);
                Titl.SetValue(TextBlock.FontWeightProperty, FontWeights.Bold);
                descripBox.Text = progOnScreen.description;
                counter = 0;


            }
        }

        private void Prev_Click(object sender, RoutedEventArgs e)
        {
            // Button button = sender as Button;
            // Meals.MealPlans spec = button.DataContext as Meals.MealPlans;
            if (counter == 0)
            {
                goalser.SetValue(TextBlock.FontWeightProperty, FontWeights.Bold);
                Titl.SetValue(TextBlock.FontWeightProperty, FontWeights.Light);
                descripBox.Text = progOnScreen.goals;
                counter = 2;


            }
            else if (counter == 1)
            {
                Titl.SetValue(TextBlock.FontWeightProperty, FontWeights.Bold);
                lenghter.SetValue(TextBlock.FontWeightProperty, FontWeights.Light);
                descripBox.Text = progOnScreen.description;
                counter--;

            }
            else if (counter == 2)
            {
                goalser.SetValue(TextBlock.FontWeightProperty, FontWeights.Light);
                lenghter.SetValue(TextBlock.FontWeightProperty, FontWeights.Bold);
                descripBox.Text = progOnScreen.lengthDes;
                counter--;


            }

        }

        private void yesDelete_Click(object sender, RoutedEventArgs e)
        {
            Poper.IsOpen = false;
            User.programDaysLeft = progOnScreen.length;
            User.currentProgramWorkoutsCompleted = 0;
            Button button = sender as Button;
            Program spec = button.DataContext as Program;
            User.currentProgram = progOnScreen;
            setLabel.Visibility = Visibility.Visible;
            setProgButton.IsEnabled = false;
            cover.Visibility = Visibility.Hidden;
        }

        private void noDelete_Click(object sender, RoutedEventArgs e)
        {

            Poper.IsOpen = false;
            cover.Visibility = Visibility.Hidden;

        }


        private void setProgramBtn(object sender, RoutedEventArgs e)
        {
            if(User.currentProgram != null)
            {
                Poper.IsOpen = true;
                cover.Visibility = Visibility.Visible;
                /*
                MessageBoxResult switchPrograms = System.Windows.MessageBox.Show("Are you sure you want to replace your current program with this one?", "Switch Program Confirmation", System.Windows.MessageBoxButton.YesNo);

                if (switchPrograms == MessageBoxResult.Yes)
                {
                    User.programDaysLeft = progOnScreen.length;
                    User.currentProgramWorkoutsCompleted = 0;
                    Button button = sender as Button;
                    Program spec = button.DataContext as Program;
                    User.currentProgram = progOnScreen;
                    setLabel.Visibility = Visibility.Visible;
                    setProgButton.IsEnabled = false;

                }*/


            }
            else
            {
                User.programDaysLeft = progOnScreen.length;
                User.currentProgramWorkoutsCompleted = 0;
                Button button = sender as Button;
                Program spec = button.DataContext as Program;
                User.currentProgram = progOnScreen;
                setLabel.Visibility = Visibility.Visible;
                setProgButton.IsEnabled = false;
            }
          
        }

        private void Remove_Prog_Click(object sender, RoutedEventArgs e)
        {


            Poper1.IsOpen = true;
            cover.Visibility = Visibility.Visible;

        }

        private void yesRemove_Click(object sender, RoutedEventArgs e)
        {
            Poper1.IsOpen = false;
            User.currentProgram = null;
            User.programDaysLeft = 0;
            ProgramScreen meals = new ProgramScreen(progOnScreen);
            this.Visibility = Visibility.Hidden;
            cover.Visibility = Visibility.Hidden;
            meals.Show();
        }

        private void noRemove_Click(object sender, RoutedEventArgs e)
        {

            Poper1.IsOpen = false;
            cover.Visibility = Visibility.Hidden;

        }




    }
}
