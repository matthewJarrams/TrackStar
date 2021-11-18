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
            setLabel.Visibility = Visibility.Hidden;
            Workout test = prog.workouts[currentDay];
            lbTodoList.ItemsSource = test.ExerciseList;
            progOnScreen = prog;
            programTitle.Content = progOnScreen.name;

            if(User.currentProgram == progOnScreen)
            {
                setProgButton.IsEnabled = false;
            }
            
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
            if(User.currentProgram != null)
            {
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

                }
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

      


    }
}
