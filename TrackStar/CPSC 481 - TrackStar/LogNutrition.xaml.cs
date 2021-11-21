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
                carbTarg.Content = "Target: " + User.currentMealPlan.Targets[0].TargetList[2].Amounts;
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

                if (targetsMet == 5)
                {
                    macroTargets.Fill = new SolidColorBrush(Colors.Green);
                }
                else
                {
                    macroTargets.Fill = new SolidColorBrush(Colors.Red);
                }

                targetsMetLbl.Content = targetsMet + " / 5";

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

            mealListBox.ItemsSource = null;
            mealListBox.ItemsSource = User.currentMealPlan.AllMeals;

            calTarget.Content = 0;
            calorieChecker.Fill = new SolidColorBrush(Colors.White);
            macroTargets.Fill = new SolidColorBrush(Colors.White);
            targetsMetLbl.Content =  0 + " / 5";



        }

        



        private void Home_Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().First();
            mainWindow.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
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
