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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public static Program program = User.currentProgram;
		public static Program cardio;
		public static Program strength;
		public static Program arms;
		public int currentDay = 0;
		public static bool todayCompleted = false;
       
        public Window1()
        {
			InitializeComponent();
			buildProgram();
			if (todayCompleted == true)
			{
				undoBtn.IsEnabled = true;
				completionLabel.Visibility = Visibility.Visible;
				completeBtn.IsEnabled = false;
			}
			else
			{
				undoBtn.IsEnabled = false;
				completionLabel.Visibility = Visibility.Hidden;
			}
			
			if(User.currentProgram == null)
            {
				programName.Content = "No Program Selected";	
            }
            else
            {
				Workout test = User.currentProgram.workouts[currentDay];
				lbTodoList.ItemsSource = test.ExerciseList;
				programDay.Content = "Day: " + test.Day + " (Today)";
				programName.Content = User.currentProgram.name;
				if (User.currentProgram.workouts.Count == 1)
				{
					btnNextDay.IsEnabled = false;
					btnToday.IsEnabled = false;
				}
			}

			


			btnToday.IsEnabled = false;
		}

		private void lbTodoList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			if (lbTodoList.SelectedItem != null)
				this.Title = (lbTodoList.SelectedItem as Exercise).Title;
		}


		private void btnSelectLast_Click(object sender, RoutedEventArgs e)
		{
			lbTodoList.SelectedIndex = lbTodoList.Items.Count - 1;
		}

		private void btnSelectNext_Click(object sender, RoutedEventArgs e)
		{
			int nextIndex = 0;
			if ((lbTodoList.SelectedIndex >= 0) && (lbTodoList.SelectedIndex < (lbTodoList.Items.Count - 1)))
				nextIndex = lbTodoList.SelectedIndex + 1;
			lbTodoList.SelectedIndex = nextIndex;
		}

		private void btnSelectCSharp_Click(object sender, RoutedEventArgs e)
		{
			foreach (object o in lbTodoList.Items)
			{
				if ((o is Exercise) && ((o as Exercise).Title.Contains("C#")))
				{
					lbTodoList.SelectedItem = o;
					break;
				}
			}
		}

		private void btnSelectAll_Click(object sender, RoutedEventArgs e)
		{
			foreach (object o in lbTodoList.Items)
				lbTodoList.SelectedItems.Add(o);
		}

		private void btnComplete_Click(object sender, RoutedEventArgs e)
		{
			User.currentProgramWorkoutsCompleted++;
			User.programDaysLeft = User.currentProgram.length - (User.currentProgramWorkoutsCompleted + User.currentProgramMissedWorkouts);
			if (User.programDaysLeft == 0)
			{
				MessageBox.Show("Congratulations! You have completed your program!");
				todayCompleted = false;
				MainWindow home = new MainWindow();
				this.Visibility = Visibility.Hidden;
				home.Show();

			}
			else
			{
				todayCompleted = true;
				completeBtn.IsEnabled = false;
				undoBtn.IsEnabled = true;
				completionLabel.Visibility = Visibility.Visible;
				completionLabel.Content = "Completion Saved!";
				btnNextDay_click(sender, e);
			}


		}

		private void btnNotComplete_Click(object sender, RoutedEventArgs e)
		{
			User.currentProgramMissedWorkouts++;
			User.programDaysLeft = User.currentProgram.length - (User.currentProgramWorkoutsCompleted + User.currentProgramMissedWorkouts);
			MessageBox.Show("That's ok. Next Time!");
		}

		private void btnNextDay_click(object sender, RoutedEventArgs e)
		{
			completionLabel.Visibility = Visibility.Hidden;
			if (currentDay + 1 < User.currentProgram.workouts.Count)
			{
				lbTodoList.ItemsSource = null;
				currentDay++;
				lbTodoList.ItemsSource = User.currentProgram.workouts[currentDay].ExerciseList;
				programDay.Content = "Day: " + User.currentProgram.workouts[currentDay].Day + " (" + currentDay + " days away)";
				btnToday.IsEnabled = true;
				if(currentDay+1 == User.currentProgram.workouts.Count)
                {
					btnNextDay.IsEnabled = false;
				}
				infoLabel.Text = "You are viewing workouts " + currentDay + " days ahead";
				infoLabel.Margin = new Thickness(35, 545, 0, 0);
				infoLabel.Width = 400;
			}
            else
            {
				btnNextDay.IsEnabled = false;
            }
			

			completeBtn.Visibility = Visibility.Hidden;
			undoBtn.Visibility = Visibility.Hidden;
			

		}


		private void btnToday_click(object sender, RoutedEventArgs e)
		{
			
			if (currentDay != 0)
			{
				lbTodoList.ItemsSource = null;
				currentDay--;
				lbTodoList.ItemsSource = User.currentProgram.workouts[currentDay].ExerciseList;
				programDay.Content = "Day: " + User.currentProgram.workouts[currentDay].Day + " (" + currentDay + " days away)";
				btnNextDay.IsEnabled = true;
				if (currentDay == 0)
				{

					if (todayCompleted == true)
					{
						undoBtn.IsEnabled = true;
						completeBtn.IsEnabled = false;
						completeBtn.Visibility = Visibility.Visible;
						completionLabel.Visibility = Visibility.Visible;
						undoBtn.Visibility = Visibility.Visible;
					}
					else
					{
						completeBtn.Visibility = Visibility.Visible;
						undoBtn.Visibility = Visibility.Visible;
						undoBtn.IsEnabled = false;
						completeBtn.IsEnabled = true;
						completionLabel.Visibility = Visibility.Hidden;
					}
					programDay.Content = "Day: " + User.currentProgram.workouts[currentDay].Day + " (Today)";
					btnToday.IsEnabled = false;
					
					infoLabel.Text = "Tap the checkmark icon to record completing \ntoday's workout and tap undo for accidental\nrecorded workouts";
					infoLabel.Margin = new Thickness(20, 545, 0, 0);
					infoLabel.Width = 365;
				}
			}
            else
            {
				btnToday.IsEnabled = false;

            }

		}


		public static void buildProgram()
		{
			List<Exercise> day1 = new List<Exercise>();
			day1.Add(new Exercise() { Title = "Bench Press", Amounts = "4 x 10" });
			day1.Add(new Exercise() { Title = "Squats", Amounts = "2 X 20" });
			day1.Add(new Exercise() { Title = "Shoulder Press", Amounts = "4 x 5" });
			day1.Add(new Exercise() { Title = "Inclined Walk", Amounts = "30 mins" });
			day1.Add(new Exercise() { Title = "Squats", Amounts = "4 x 20" });
			day1.Add(new Exercise() { Title = "Tricep Extension", Amounts = "3 x 10" });
			day1.Add(new Exercise() { Title = "Sit-ups", Amounts = "200" });

			List<Exercise> day2 = new List<Exercise>();
			day2.Add(new Exercise() { Title = "Stretch", Amounts = "5 mins" });
			day2.Add(new Exercise() { Title = "Bike", Amounts = "30 mins" });
			day2.Add(new Exercise() { Title = "Run", Amounts = "20 mins" });
			day2.Add(new Exercise() { Title = "Rowing Machine", Amounts = "30 mins" });
			day2.Add(new Exercise() { Title = "Sit-ups", Amounts = "200" });



			List<Exercise> day3 = new List<Exercise>();
			day3.Add(new Exercise() { Title = "Stretch", Amounts = "5 mins" });
			day3.Add(new Exercise() { Title = "Bike", Amounts = "30 mins" });
			day3.Add(new Exercise() { Title = "Bench Press", Amounts = "5 x 15" });
			day3.Add(new Exercise() { Title = "Pullups", Amounts = "30" });
			day3.Add(new Exercise() { Title = "Chest Flys", Amounts = "4 x 15" });
			day3.Add(new Exercise() { Title = "Tricep Extension", Amounts = "3 x 10" });

			List<Exercise> day12 = new List<Exercise>();
			day12.Add(new Exercise() { Title = "Bench Press", Amounts = "4 x 10" });
		


			Workout Day1 = new Workout(1, day1);
			Workout Day2 = new Workout(2, day2);
			Workout Day3 = new Workout(3, day3);


			Workout Day12 = new Workout(1, day12);

			List<Workout> workoutPlan = new List<Workout>();
			workoutPlan.Add(Day1);
			workoutPlan.Add(Day2);
			workoutPlan.Add(Day3);

			List<Workout> workoutPlan2 = new List<Workout>();
			workoutPlan2.Add(Day12);

			string desc = "Program designed for indiviudals looking to burn large amounts of calories and to increase overall cardio health. " +
				"For individuals looking to lose weight, this program will help in burning those extra couple of hundred calories a day. " +
				"Whilst also helping you get fitter \n \n Program for intermediate gym goers.";

			cardio = new Program("Cardio Training Program", workoutPlan, desc, "6 week program with 5 workouts to complete per week, allowing you to take 2 rest days.", "-Increase fitness levels \n -Become a better runner \n ;-Burn calories!",  "Low", 40);
			strength = new Program("Strength Building Program", workoutPlan2, "Strength", "Testlength", "TestGoals", "Medium", 1);
			arms = new Program("Arms Building Program", workoutPlan, "Strength", "Testlength", "TestGoals", "High", 60);

		}

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
			MainWindow objMainWindow = new MainWindow();
			this.Visibility = Visibility.Hidden;
			objMainWindow.Show();
		}

        private void undoBtn_Click(object sender, RoutedEventArgs e)
        {
			todayCompleted = false;
			completeBtn.IsEnabled = true;
			completionLabel.Content = "Completion Undone";
			User.currentProgramWorkoutsCompleted--;
			User.programDaysLeft = User.currentProgram.length - (User.currentProgramWorkoutsCompleted + User.currentProgramMissedWorkouts);
		}
    }



    public class Exercise
	{
		public string Title { get; set; }
		public string Amounts { get; set; }

	}

	public class Workout
	{
		public List<Exercise> ExerciseList { get; set; }
		public int Day { get; set; }

		public Workout(int d, List<Exercise> list)
		{
			this.Day = d;
			this.ExerciseList = list;
		}

	}
	public class Program
	{
		public string name { get; set; }
		public List<Workout> workouts { get; set; }
		public string description { get; set; }
		public string lengthDes { get; set; }
		public string goals { get; set; }
		public string intensity { get; set; }

		public int length { get; set; }

		public  Program(String n, List<Workout> list, String d, String ld, String go,  String inten, int length)
		{
			this.name = n;
			this.workouts = list;
			this.description = d;
			this.lengthDes = ld;
			this.goals = go;
			this.intensity = inten;
			this.length = length;
		}

		

	}

}
