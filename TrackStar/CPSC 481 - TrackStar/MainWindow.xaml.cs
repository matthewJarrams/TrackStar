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
using System.Windows.Navigation;
using System.Windows.Shapes;


using LiveCharts;
using LiveCharts.Wpf;


namespace CPSC_481___TrackStar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static User superUser = new User();
        public static personalRecord pinnedRecord = Goals.weight;
       
        public LogNutrition nutWindow = new LogNutrition();
        public InfoWindow infoWindow = new InfoWindow();
        public static Goals goalsWindow = new Goals();
        public Meals mealsWindow = new Meals();
        public Window1 window1 = new Window1();
        public Catalogue catWindow = new Catalogue();
        //public ProgramScreen programScreen = new ProgramScreen();


        public MainWindow()
        {
            InitializeComponent();
            Window1.buildProgram();
            
            if (User.currentProgram != null)
            {
                completionBar.Maximum = User.currentProgram.length;
                if (User.currentProgramWorkoutsCompleted == User.currentProgram.length)
                {
                    completionBar.Visibility = Visibility.Hidden;
                    programCompletionLbl.Visibility = Visibility.Hidden;
                    programCompletionBlock.Text = "\t     Amazing job! \nYou completed your workout program!";
                    programCompletionBlock.Margin = new Thickness(55, 115, 0, 0);
                    programCompletionBlock.Width = 320;
                    programCompletionBlock.Height = 50;
                    //directions.Text = "Tap the catalogue icon on the menu bar to pick a new one!";
                    User.currentProgram = null;
                }
                else
                {
                    programCompletionBlock.Text = "Program Completion (" + User.programDaysLeft + " Days Left)";
                    completionBar.Value = User.currentProgramWorkoutsCompleted;
                    programCompletionLbl.Content = "Workout Progress: " + completionBar.Value + " / " + completionBar.Maximum;
                    directionsClick.Visibility = Visibility.Hidden;
                    programCompletionBlock.Margin = new Thickness(60, 106, 0, 0);
                }
            }
            else
            {
              
                completionBar.Visibility = Visibility.Hidden;
                programCompletionLbl.Visibility = Visibility.Hidden;
                programCompletionBlock.Text = "No Program Selected";
                programCompletionBlock.Margin = new Thickness(115, 130, 0, 0);

            }




            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Weight",
                    Fill = Brushes.Transparent,
                    Stroke = Brushes.Coral,
                    Opacity = 0.2,
                    Values  = pinnedRecord.recordHist
                }

            };


          

            //modifying the series collection will animate and update the chart


            //modifying any series values will also animate and update the chart


            DataContext = this;
        }

        public static SeriesCollection SeriesCollection { get; set; }
        public List<String> Labels { get; set; } = User.Labels;


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (User.currentProgram == null)
            {
                //MessageBoxResult catalogue = System.Windows.MessageBox.Show("You have not selected a workout program, would you like to view available programs?", "Catalogue", System.Windows.MessageBoxButton.YesNo);
                Poper.IsOpen = true;

               /* if (catalogue == MessageBoxResult.Yes)
                {
                    Catalogue catScreen = new Catalogue();
                    this.Visibility = Visibility.Hidden;
                    catScreen.Show();
                }*/
            }
            else
            {
                Window1 objWindow1 = new Window1();
                this.Visibility = Visibility.Hidden;
                objWindow1.Show();
            }
        }


        private void Button_Guide(object sender, RoutedEventArgs e)
        {



        }


        private void yesDelete_Click(object sender, RoutedEventArgs e)
        {
            Poper.IsOpen = false;
            Catalogue catScreen = new Catalogue();
            this.Visibility = Visibility.Hidden;
            catScreen.Show();
        }

        private void noDelete_Click(object sender, RoutedEventArgs e)
        {

            Poper.IsOpen = false;

        }


        private void Home_Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow objMainWindow = new MainWindow();
            this.Visibility = Visibility.Hidden;
            objMainWindow.Show();
        }

        private void Cat_Button_Click(object sender, RoutedEventArgs e)
        {
            
            this.Visibility = Visibility.Hidden;
            catWindow.Show();
        }

        private void Info_Button_Click(object sender, RoutedEventArgs e)
        {
            InfoWindow info = new InfoWindow();
            this.Visibility = Visibility.Hidden;
            info.Show();
        }

        private void Goals_Button_Click(object sender, RoutedEventArgs e)
        {

            this.Visibility = Visibility.Hidden;
            Goals goalsScreen = new Goals();
            goalsWindow = goalsScreen;
            goalsWindow.Show();
        }

        private void Meals_Button_Click(object sender, RoutedEventArgs e)
        {

            this.Visibility = Visibility.Hidden;
            mealsWindow.Show();
        }

        private void Nutrition_Button_Click(object sender, RoutedEventArgs e)
        {
            LogNutrition nutScreen = new LogNutrition();
            this.Visibility = Visibility.Hidden;
            nutScreen.Show();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            NewGoalDialog ngd = new NewGoalDialog(pinnedRecord);
            ngd.Show();
        }
    }
}
