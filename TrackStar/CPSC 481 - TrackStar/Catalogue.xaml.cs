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
    /// Interaction logic for Catalogue.xaml
    /// </summary>


    public partial class Catalogue : Window
    {
        public static String currentProgram = "Currently No Program Selected";
        public static List<Program> progList = new List<Program>();
        
       
        public Catalogue()
        {


            InitializeComponent();
            if (User.currentProgram == null)
            {
                currentProgramLbl.Content = "Currently No Program Selected";
            }
            else
            {
                currentProgramLbl.Content = User.currentProgram.name;
            }

            if (progList.Count == 0)
            {
                progList.Add(Window1.cardio);
                progList.Add(Window1.strength);
                progList.Add(Window1.arms);
            }


            lvDataBinding.ItemsSource = progList;

        }


        


        private void Home_Button_Click(object sender, RoutedEventArgs e)
        {
            //MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().First();
            //mainWindow.Visibility = Visibility.Visible;
            MainWindow home = new MainWindow();
            this.Visibility = Visibility.Hidden;
            home.Show();
        }

        private void Info_Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().First();
            mainWindow.infoWindow.Show();
            this.Visibility = Visibility.Hidden;

        }
        private void Goals_Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().First();
            MainWindow.goalsWindow.Show();
            this.Visibility = Visibility.Hidden;

        }
        private void Meals_Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().First();
            mainWindow.mealsWindow.Show();
            this.Visibility = Visibility.Hidden;

        }

        private void removeProgramBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult cancel = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);

            if (cancel == MessageBoxResult.Yes)
            {
                currentProgramLbl.Content = "No Program Currently Selected";
                User.currentProgram = null;
            }


        }

        private void Spec_Prog_Cick(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Program spec = button.DataContext as Program;
            ProgramScreen specWindow = new ProgramScreen(spec);
            this.Visibility = Visibility.Hidden;
            specWindow.Show();
        }


        private void viewProgramBtn_Click(object sender, RoutedEventArgs e)
        {
            /*MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().First();
            mainWindow.programScreen.Show();
            this.Visibility = Visibility.Hidden;*/
            if (User.currentProgram == null)
            {
                MessageBox.Show("You have not chosen a program. If you would like a program, please choose from the list below");
            }
            else
            {
                ProgramScreen progScreen = new ProgramScreen(User.currentProgram);
                this.Visibility = Visibility.Hidden;
                progScreen.Show();
            }
         

        }

        /*private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("The" + catalogueStack.Children.Count);
            catalogueStack.Children.Remove(cardioGrid);
        }*/

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            /*MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().First();
            mainWindow.programScreen.Show();
            this.Visibility = Visibility.Hidden;*/
            ProgramScreen progScreen = new ProgramScreen(null);
            this.Visibility = Visibility.Hidden;
            progScreen.Show();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (filter.SelectedItem == high)
            {
                List<Program> highList = new List<Program>();
                for (int i = 0; i < progList.Count; i++)
                {
                    if (progList[i].intensity.Equals("High"))
                    {
                        highList.Add(progList[i]);


                    }
                }
                lvDataBinding.ItemsSource = highList;

            }
            if (filter.SelectedItem == medium)
            {
                List<Program> mediumList = new List<Program>();
                for (int i = 0; i < progList.Count; i++)
                {
                    if (progList[i].intensity.Equals("Medium"))
                    {
                        mediumList.Add(progList[i]);


                    }
                }
                lvDataBinding.ItemsSource = mediumList;
            }
            if(filter.SelectedItem == low)
            {
                List<Program> lowList = new List<Program>();
                for (int i = 0; i < progList.Count; i++)
                {
                    if (progList[i].intensity.Equals("Low"))
                    {
                        lowList.Add(progList[i]);


                    }
                }
                lvDataBinding.ItemsSource = lowList;
            }
            if(filter.SelectedItem == clear)
            {
                lvDataBinding.ItemsSource = progList;
            }
        }
    }
}
