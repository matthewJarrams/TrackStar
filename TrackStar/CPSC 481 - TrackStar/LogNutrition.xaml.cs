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
using LiveCharts;
using LiveCharts.Wpf;

namespace CPSC_481___TrackStar
{
    /// <summary>
    /// Interaction logic for LogNutrition.xaml
    /// </summary>
    public partial class LogNutrition : Window
    {
        public static List<Food> foodList = new List<Food>();
        Food chocProShake = new Food("Chocolate Keto Protein Shake", 1000, 30, 30,20);
        Food steakVeggies = new Food("Steak with Cauliflower and Brocolli", 1200, 3, 35, 40);
        Food ketoCereal = new Food("Keto Cereal", 1300, 40, 35, 20);
        Food brocSalad = new Food("Keto Broccoli Salad ", 500, 20, 30, 10);
        Food macCheese = new Food("Keto Mac & Cheese", 200, 5, 10, 0);
        Food avoToast = new Food("Avacado Toast", 700, 30, 15, 25);
        Food salmon = new Food("Broiled Salmon", 700, 30, 15, 25);
        Food ranchChicken = new Food("Cheesy Bacon Ranch Chicken ", 700, 30, 15, 25);
        Food porkChops = new Food("Garlic Rosemary Pork Chops", 1000, 2, 25, 25);




        public static int cumCals = 0;
        public static int cumCarbs = 0;
        public static int cumFat = 0;
        public static int cumProtien = 0;


        public LogNutrition()
        {
            InitializeComponent();

            datePicker.SelectedDate = DateTime.Today;
            foodList.Add(chocProShake);
            foodList.Add(steakVeggies);
            foodList.Add(ketoCereal);
            foodList.Add(brocSalad);
            foodList.Add(macCheese);
            foodList.Add(avoToast);
            foodList.Add(salmon);
            foodList.Add(ranchChicken);
            foodList.Add(porkChops);

            

           

            /*
             * finish this later
             */
            if (User.currentMealPlan != null)
            {
                calConTarg.Content = "Target: " + User.currentMealPlan.Targets[0].TargetList[0].Amounts;
                calBTarg.Content = "Target: 500";
                carbTarg.Content = "Target: " + User.currentMealPlan.Targets[0].TargetList[2].Amounts;
                fatTarg.Content = "Target: " + User.currentMealPlan.Targets[0].TargetList[1].Amounts;
                proTarg.Content = "Target: " + User.currentMealPlan.Targets[0].TargetList[3].Amounts;
                mealListBox.ItemsSource = User.currentMealPlan.AllMeals;
            }

            DataContext = this;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            bool f = int.TryParse(fatBox.Text, out _);
            bool c = int.TryParse(carbBox.Text, out _);
            bool p = int.TryParse(proBox.Text, out _);
            bool cc = int.TryParse(calsConsumed.Text, out _);
            bool cb = int.TryParse(calsBurned.Text, out _);

            if (f && c && p && cc && cb)
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

                int targetsMet = 0;


                var fatvals = new ChartValues<int> { int.Parse(fatBox.Text) };
                fatter.Values = fatvals;
                var carbvals = new ChartValues<int> { int.Parse(carbBox.Text) };
                carber.Values = carbvals;
                var provals = new ChartValues<int> { int.Parse(proBox.Text) };
                proter.Values = provals;



                if (int.Parse(carbBox.Text) == 125)
                {
                    targetsMet++;
                }
                if (int.Parse(fatBox.Text) == 50)
                {

                    targetsMet++;
                }
                if (int.Parse(proBox.Text) == 75)
                {
                    targetsMet++;
                }
                if (caloriesBurned == 500)
                {
                    targetsMet++;
                }
                if (calorieIntake == 2500)
                {
                    targetsMet++;
                }

                

            }
        }

        private void DatePicker_CalendarClosed(object sender, RoutedEventArgs e)
        {
            calsConsumed.Text = "0";
            calsBurned.Text = "0";
            proBox.Text = "0";
            carbBox.Text = "0";
            fatBox.Text = "0";


            cumCals = 0;
            cumCarbs = 0;
            cumFat = 0;
            cumProtien = 0;

            if  (User.currentMealPlan != null)
            {
                mealListBox.ItemsSource = null;
                mealListBox.ItemsSource = User.currentMealPlan.AllMeals;
            }

            calTarget.Content = 0;
            calorieChecker.Fill = new SolidColorBrush(Colors.White);
           


        }

        



        private void Home_Button_Click(object sender, RoutedEventArgs e)
        {
            //MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().First();
            //mainWindow.Visibility = Visibility.Visible;
            MainWindow main = new MainWindow();
            this.Visibility = Visibility.Hidden;
            main.Show();
        }


        
        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            CheckBox b = (CheckBox)sender;
            Food p = (Food)b.Tag;
            if (b.IsChecked == true)
            {
                cumCals += p.calories;
                cumCarbs += p.carbs;
                cumFat += p.fat;
                cumProtien += p.protien;

                calsConsumed.Text = cumCals.ToString();
                carbBox.Text = cumCarbs.ToString();
                fatBox.Text = cumFat.ToString();
                proBox.Text = cumProtien.ToString();
            }
            if(b.IsChecked == false)
            {
                cumCals -= p.calories;
                cumCarbs -= p.carbs;
                cumFat -= p.fat;
                cumProtien -= p.protien;

                calsConsumed.Text = cumCals.ToString();
                carbBox.Text = cumCarbs.ToString();
                fatBox.Text = cumFat.ToString();
                proBox.Text = cumProtien.ToString();
            }

            bool f = int.TryParse(fatBox.Text, out _);
            bool c = int.TryParse(carbBox.Text, out _);
            bool pro = int.TryParse(proBox.Text, out _);
            bool cc = int.TryParse(calsConsumed.Text, out _);
            bool cb = int.TryParse(calsBurned.Text, out _);

            if (f && c && pro && cc && cb)
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

                int targetsMet = 0;

                double total = double.Parse(fatBox.Text) + double.Parse(carbBox.Text) + double.Parse(proBox.Text);
                double fatPer = double.Parse(fatBox.Text) / total * 100;
                double carbPer = double.Parse(carbBox.Text) / total * 100;
                double proPer = double.Parse(proBox.Text) / total * 100;

                fatPer = Math.Round(fatPer, 1);
                carbPer = Math.Round(carbPer, 1);
                proPer = Math.Round(proPer, 1);

                var fatvals = new ChartValues<double> { fatPer };
                fatter.Values = fatvals;
                var carbvals = new ChartValues<double> { carbPer };
                carber.Values = carbvals;
                var provals = new ChartValues<double> { proPer };
                proter.Values = provals;



                if (int.Parse(carbBox.Text) == 125)
                {
                    targetsMet++;
                }
                if (int.Parse(fatBox.Text) == 50)
                {

                    targetsMet++;
                }
                if (int.Parse(proBox.Text) == 75)
                {
                    targetsMet++;
                }
                if (caloriesBurned == 500)
                {
                    targetsMet++;
                }
                if (calorieIntake == 2500)
                {
                    targetsMet++;
                }

            }



        }
        public static int MouseDoubleClick = 0;

        private void proBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MouseDoubleClick++;
            if(MouseDoubleClick == 1)
            {
            }
            if(MouseDoubleClick == 2)
            {
                int editedPro = int.Parse(proBox.Text);
                editedPro = editedPro - cumProtien;

                cumProtien += editedPro;


                double total = double.Parse(fatBox.Text) + double.Parse(carbBox.Text) + double.Parse(proBox.Text);
                double fatPer = double.Parse(fatBox.Text) / total * 100;
                double carbPer = double.Parse(carbBox.Text) / total * 100;
                double proPer = double.Parse(proBox.Text) / total * 100;

                fatPer = Math.Round(fatPer, 1);
                carbPer = Math.Round(carbPer, 1);
                proPer = Math.Round(proPer, 1);

                var fatvals = new ChartValues<double> { fatPer };
                fatter.Values = fatvals;
                var carbvals = new ChartValues<double> { carbPer };
                carber.Values = carbvals;
                var provals = new ChartValues<double> { proPer };
                proter.Values = provals;
                MouseDoubleClick = 0;
            }
        }
        public static int editedFat = 0;
        private void fatBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MouseDoubleClick++;
            if (MouseDoubleClick == 1)
            {
            }
            if (MouseDoubleClick == 2)
            {
                editedFat = int.Parse(fatBox.Text);
                editedFat = editedFat - cumFat;

                cumFat += editedFat;

                double total = double.Parse(fatBox.Text) + double.Parse(carbBox.Text) + double.Parse(proBox.Text);
                double fatPer = double.Parse(fatBox.Text) / total * 100;
                double carbPer = double.Parse(carbBox.Text) / total * 100;
                double proPer = double.Parse(proBox.Text) / total * 100;

                fatPer = Math.Round(fatPer, 1);
                carbPer = Math.Round(carbPer, 1);
                proPer = Math.Round(proPer, 1);

                var fatvals = new ChartValues<double> { fatPer };
                fatter.Values = fatvals;
                var carbvals = new ChartValues<double> { carbPer };
                carber.Values = carbvals;
                var provals = new ChartValues<double> { proPer };
                proter.Values = provals;
                MouseDoubleClick = 0;
            }
        }

        private void carbBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MouseDoubleClick++;
            if (MouseDoubleClick == 1)
            {
            }
            if (MouseDoubleClick == 2)
            {

                int editedCarbs = int.Parse(carbBox.Text);
                editedCarbs = editedCarbs - cumCarbs;

                cumCarbs += editedCarbs;


                double total = double.Parse(fatBox.Text) + double.Parse(carbBox.Text) + double.Parse(proBox.Text);
                double fatPer = double.Parse(fatBox.Text) / total * 100;
                double carbPer = double.Parse(carbBox.Text) / total * 100;
                double proPer = double.Parse(proBox.Text) / total * 100;

                fatPer = Math.Round(fatPer, 1);
                carbPer = Math.Round(carbPer, 1);
                proPer = Math.Round(proPer, 1);

                var fatvals = new ChartValues<double> { fatPer };
                fatter.Values = fatvals;
                var carbvals = new ChartValues<double> { carbPer };
                carber.Values = carbvals;
                var provals = new ChartValues<double> { proPer };
                proter.Values = provals;
                MouseDoubleClick = 0;
            }
        }
    }
    public class Food
    {
        public string meal { get; set; }
        public bool eaten = false;
        public int calories = 0;
        public int carbs = 0;
        public int fat = 0;
        public int protien = 0;
      


        public Food(string meal, int calories, int carbs, int fat, int protein)
        {
            this.meal = meal;
            this.calories = calories;
            this.carbs = carbs;
            this.fat = fat;
            this.protien = protein;
        }


        



    }
}
