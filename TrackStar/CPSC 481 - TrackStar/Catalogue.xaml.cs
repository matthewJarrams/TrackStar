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

        public List<String> listofFilters = new List<String>();

        public Catalogue()
        {


            InitializeComponent();

            filters.ItemsSource = listofFilters;

            if (User.currentProgram == null)
            {
                currentProgramLbl.Content = "Currently No Program Selected";
                //removeProgramBtn.IsEnabled = false;
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
                progList.Add(Window1.yoga);
                progList.Add(Window1.hiit);
                progList.Add(Window1.balancedHealthy);
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
           // MessageBoxResult cancel = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            Poper.IsOpen = true;

          /*  if (cancel == MessageBoxResult.Yes)
            {
                currentProgramLbl.Content = "No Program Currently Selected";
                User.currentProgram = null;
                User.programDaysLeft = 0;
                
            }
          */

        }

        private void yesDelete_Click(object sender, RoutedEventArgs e)
        {
            Poper.IsOpen = false;
            currentProgramLbl.Content = "No Program Currently Selected";
            User.currentProgram = null;
            User.programDaysLeft = 0;
            //removeProgramBtn.IsEnabled = false;
        }

        private void noDelete_Click(object sender, RoutedEventArgs e)
        {

            Poper.IsOpen = false;

        }

        private void Spec_Prog_Cick(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Program spec = button.DataContext as Program;
            ProgramScreen specWindow = new ProgramScreen(spec);
            this.Visibility = Visibility.Hidden;
            specWindow.Show();
        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            Poper1.IsOpen = false;
            key.Visibility = Visibility.Hidden;
            cover.Visibility = Visibility.Hidden;
        }


        private void viewProgramBtn_Click(object sender, RoutedEventArgs e)
        {
            /*MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().First();
            mainWindow.programScreen.Show();
            this.Visibility = Visibility.Hidden;*/
            if (User.currentProgram == null)
            {
                // MessageBox.Show("You have not chosen a program. If you would like a program, please choose from the list below");
                Poper1.IsOpen = true;
                cover.Visibility = Visibility.Visible;
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

        /*private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
        }*/

        private void filter_BtnClick(object sender, RoutedEventArgs e)
        {
            PoperFilter.IsOpen = true;
            cover.Visibility = Visibility.Visible;
            Vegetarian.Content = "<= 14 days";
            Dairy.Content = " <= 30 days";
            Gluten.Content = "> 30 days";
        }

        private void CancelBtnClick(object sender, RoutedEventArgs e)
        {
            PoperFilter.IsOpen = false;
            key.Visibility = Visibility.Hidden;
            cover.Visibility = Visibility.Hidden;
            if (currentFilterList.Count == 0)
            {
                lvDataBinding.ItemsSource = progList;
            }
            else
            {
                lvDataBinding.ItemsSource = currentFilterList;
            }

        }

        private void clearAllClick(object sender, RoutedEventArgs e)
        {
            Dairy.IsChecked = false;
            Vegetarian.IsChecked = false;
            Gluten.IsChecked = false;

            highPro.IsChecked = false;
            LowCarb.IsChecked = false;
            LowFat.IsChecked = false;

            ManWeight.IsChecked = false;
            LoseWeight.IsChecked = false;
            GainWeight.IsChecked = false;

            listofFilters.Clear();
            filters.ItemsSource = null;
            filters.ItemsSource = listofFilters;

            //lvDataBinding.ItemsSource = mps;

        }
        public static List<Program> currentFilterList = new List<Program>();

        private void ApplyFilterClick(object sender, RoutedEventArgs e)
        {
            List<Program> filteredList = new List<Program>();
            listofFilters.Clear();


            for (int i = 0; i < progList.Count; i++)
            {
                if (progList[i].intensity.Equals("High") && LowCarb.IsChecked == true)
                {
                    filteredList.Add(progList[i]);
                    continue;

                }
                if (progList[i].intensity.Equals("Medium") && LowFat.IsChecked == true)
                {
                    filteredList.Add(progList[i]);
                    continue;
                }
                if (progList[i].intensity.Equals("Low") && highPro.IsChecked == true)
                {
                    filteredList.Add(progList[i]);
                    continue;

                }
                if (progList[i].length <= 14 && Vegetarian.IsChecked == true)
                {
                    filteredList.Add(progList[i]);
                    continue;

                }
                if (progList[i].length <= 30 && Dairy.IsChecked == true)
                {
                    filteredList.Add(progList[i]);
                    continue;

                }
                if (progList[i].length > 30 && Gluten.IsChecked == true)
                {
                    filteredList.Add(progList[i]);
                    continue;

                }
                if (progList[i].gainMuscle && GainWeight.IsChecked == true)
                {
                    filteredList.Add(progList[i]);
                    continue;

                }
                if (progList[i].loesWeight && LoseWeight.IsChecked == true)
                {
                    filteredList.Add(progList[i]);
                    continue;

                }
                if (progList[i].balanced && ManWeight.IsChecked == true)
                {
                    filteredList.Add(progList[i]);
                    continue;

                }


                if (LowCarb.IsChecked == true)
                {

                    if (listofFilters.Contains("High Intensity") == false)
                    {
                        listofFilters.Add("High Intensity");
                    }

                }
                if (LowFat.IsChecked == true)
                {

                    if (listofFilters.Contains("Medium Intensity") == false)
                    {
                        listofFilters.Add("Medium Intensity");
                    }
                }
                if (highPro.IsChecked == true)
                {
                    if (listofFilters.Contains("Low Intensity") == false)
                    {
                        listofFilters.Add("Low Intensity");

                    }


                }
                if (Vegetarian.IsChecked == true)
                {

                    if (listofFilters.Contains("<= 14 days") == false)
                    {
                        listofFilters.Add("<= 14 days");
                    }


                }
                if (Dairy.IsChecked == true)
                {

                    if (listofFilters.Contains("<= 30 Days") == false)
                    {
                        listofFilters.Add("<= 30 Days");
                    }
                }
                if (Gluten.IsChecked == true)
                {
                    if (listofFilters.Contains("> 30 Days") == false)
                    {
                        listofFilters.Add("> 30 Days");
                    }


                }
                if (GainWeight.IsChecked == true)
                {
                    if (listofFilters.Contains("Gain Muscle") == false)
                    {
                        listofFilters.Add("Gain Muscle");
                    }

                }
                if (LoseWeight.IsChecked == true)
                {
                    if (listofFilters.Contains("Lose Weight") == false)
                    {
                        listofFilters.Add("Lose Weight");
                    }

                }
                if (ManWeight.IsChecked == true)
                {
                    if (listofFilters.Contains("Cardio/Strength Mix") == false)
                    {
                        listofFilters.Add("Cardio/Strength Mix");
                    }


                }
            }

            if (LowCarb.IsChecked == false && LowFat.IsChecked == false && highPro.IsChecked == false && Vegetarian.IsChecked == false && Dairy.IsChecked == false && Gluten.IsChecked == false && GainWeight.IsChecked == false && ManWeight.IsChecked == false && LoseWeight.IsChecked == false)
            {
                lvDataBinding.ItemsSource = progList;
                currentFilterList = progList;

                listofFilters.Clear();
                filters.ItemsSource = null;
                filters.ItemsSource = listofFilters;

            }
            else
            {
                lvDataBinding.ItemsSource = null;
                lvDataBinding.ItemsSource = filteredList;
                currentFilterList = filteredList;

                filters.ItemsSource = null;
                filters.ItemsSource = listofFilters;
            }

            PoperFilter.IsOpen = false;
          
            cover.Visibility = Visibility.Hidden;

        }
    }
}
