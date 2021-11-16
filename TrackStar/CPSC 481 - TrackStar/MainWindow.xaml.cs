﻿using System;
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
            programCompletionBlock.Text = "Program Completion (" + User.programDaysLeft + " Days Left)";
            completionBar.Maximum = 30;
            completionBar.Value = User.currentProgramWorkoutsCompleted; //completionBar.Value = Window1.completedWorkouts;
            programCompletionLbl.Content = "Workout Progress: " + completionBar.Value + " / " + completionBar.Maximum;



            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Weight",
                    Fill = Brushes.Transparent,
                    Stroke = Brushes.Coral,
                    Opacity = 0.2,
                    Values  = User.weightHist
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
            Window1 objWindow1 = new Window1();
            this.Visibility = Visibility.Hidden;
            objWindow1.Show();
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

            this.Visibility = Visibility.Hidden;
            infoWindow.Show();
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
            
            this.Visibility = Visibility.Hidden;
            nutWindow.Show();
        }


    }
}
