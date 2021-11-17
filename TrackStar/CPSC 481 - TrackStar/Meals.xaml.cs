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
    /// Interaction logic for Meals.xaml
    /// </summary>
    public partial class Meals : Window
    {
       
        public Meals()
        {
            InitializeComponent();
            lvDataBinding.ItemsSource = mps;
            if (User.currentMealPlan == null)
            {
                currentMealPlan.Content = "Currently No Meal Plan";
            }
            else
            {
                currentMealPlan.Content = User.currentMealPlan.Name;
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int count = 0;
            if (filter.SelectedItem == lowCalorie)
            {
                MealPlans[] auxArray = new MealPlans[30];
                int ii = 0;
                for (int i = 0; i < mps.Length; i++)
                {
                    if (mps[i].LowCalorie)
                    {
                        auxArray[ii] = mps[i];
                        ii++;
                        count++;
                    }
                    
                }
                MealPlans[] auxArray2 = new MealPlans[count];
                for(int i = 0; i < count; i++)
                {
                    auxArray2[i] = auxArray[i];
                }
                lvDataBinding.ItemsSource = auxArray2;
            }
            if (filter.SelectedItem == lowCarb)
            {
                MealPlans[] auxArray = new MealPlans[30];
                int ii = 0;
                for (int i = 0; i < mps.Length; i++)
                {
                    if (mps[i].LowCalorie == false)
                    {
                        auxArray[ii] = mps[i];
                        ii++;
                        count++;
                    }

                }
                MealPlans[] auxArray2 = new MealPlans[count];
                for (int i = 0; i < count; i++)
                {
                    auxArray2[i] = auxArray[i];
                }
                lvDataBinding.ItemsSource = auxArray2;
            }
            if (filter.SelectedItem == clear)
            {
                lvDataBinding.ItemsSource = mps;
            }
        }
    


    public MealPlans[] mps { get; } =
        new MealPlans[]

        {
        ("Ketogenic Diet", 
            "-Reduce Carb Intake \n -Burn Fat \n -Lose Weight",
          buildMealPlan(),
        "The ketogenic diet is a very low carb, high fat diet. It involves drastically reducing carbohydrate intake and replacing it with fat. This reduction in carbs puts your body into a metabolic state called ketosis. When this happens, your body becomes incredibly efficient at burning fat for energy.", "Calorie Intake: \t 2000 \nCarbs: \t\t 50g \nFat: \t\t 100g \nProtien: \t\t 80g" , true, buildAllMeal()),
        ("Healthy Weight-Gain", "", buildMealPlan(),
        "This meal plan will add excess calories, but will do so with largely healthy foods. The types of foods eaten aren’t that dissimilar to foods eaten when dieting, the main difference is the sheer amount.","" , true, buildAllMeal()),
        ("Vegan Diet", "", buildMealPlan(),
        "Good for you, you are saving the animals but killing trees. ","" , false, buildAllMeal()),
        ("Fast FOOD", "", buildMealPlan(),
        "Mcdonalds is the best fastfood but wendy's has the best burgers. Dairy queen burgers are also very underrated and better than their ice cream" ,"", false, buildAllMeal()),
        ("Meat only", "", buildMealPlan(),
        "Sorry to the animals it's not personal","" , false, buildAllMeal()),
        ("NUts only", "", buildMealPlan(),
        "Great for protein and fats underrated food group.","" , true, buildAllMeal())
        };

        public class MealPlans
        {
            public string Description { get; set; }
            public string Name { get; set; }
            public string Goals { get; set; }
            public List<List<Food>> Meals { get; set; }
            public String Targets { get; set; }
            public bool LowCalorie { get; set; }
            public List<Food> AllMeals { get; set; }

            public static implicit operator MealPlans((string Name, string Goals, List<List<Food>> Meals, string Description, String Targets, bool LowCalorie, List<Food> AllMeals) info)
            {
                return new MealPlans { Name = info.Name, Goals = info.Goals, Meals = info.Meals, Description = info.Description, Targets = info.Targets, LowCalorie = info.LowCalorie, AllMeals = info.AllMeals };
            }
        }

        private void Home_Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow home = new MainWindow();
            this.Visibility = Visibility.Hidden;
            home.Show();
        }

        private void Cate_Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().First();
            mainWindow.catWindow.Show();
            this.Visibility = Visibility.Hidden;

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

        private void Spec_Meal_Cick(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            MealPlans spec = button.DataContext as MealPlans;
            SpecMeal specWindow = new SpecMeal(spec);
            this.Visibility = Visibility.Hidden;
            specWindow.Show();
        }

        private void My_Meal_Cick(object sender, RoutedEventArgs e)
        {
            if (User.currentMealPlan == null)
            {
                MessageBox.Show("You have not chosen a meal plan. If you would like a meal plan, please choose from the list below");
            }
            else
            {
                SpecMeal specWindow = new SpecMeal(User.currentMealPlan);
                this.Visibility = Visibility.Hidden;
                specWindow.Show();
            }
        }

        private void Remove_Meal_Click(object sender, RoutedEventArgs e)
        {
            if (User.currentMealPlan == null)
            {
                MessageBox.Show("Nothing to remove!!");
            }
            else
            {
                User.currentMealPlan = null;
                Meals meals = new Meals();
                this.Visibility = Visibility.Hidden;
                meals.Show();
            }
        }

        public static List<List<Food>> buildMealPlan()
        {
           

            Food chocProShake = new Food("Chocolate Keto Protein Shake", 1000, 30, 30, 20);
            Food steakVeggies = new Food("Steak with Cauliflower and Brocolli", 1200, 3, 35, 40);
            Food ketoCereal = new Food("Keto Cereal", 1300, 40, 35, 20);
            Food brocSalad = new Food("Keto Broccoli Salad ", 500, 20, 30, 10);
            Food macCheese = new Food("Keto Mac & Cheese", 200, 5, 10, 0);
            Food avoToast = new Food("Avacado Toast", 700, 30, 15, 25);
            Food salmon = new Food("Broiled Salmon", 700, 30, 15, 25);
            Food ranchChicken = new Food("Cheesy Bacon Ranch Chicken ", 700, 30, 15, 25);
            Food porkChops = new Food("Garlic Rosemary Pork Chops", 1000, 2, 25, 25);

            List<Food> Breakfast = new List<Food> { chocProShake, avoToast, ketoCereal };
            List<Food> Lunch = new List<Food> { brocSalad, macCheese, steakVeggies };
            List<Food> Dinner = new List<Food> { salmon, ranchChicken, porkChops };

            List<List<Food>> MealPlan = new List<List<Food>> { Breakfast, Lunch, Dinner };

            return MealPlan; 

        }

        public static List<Food> buildAllMeal()
        {
            Food chocProShake = new Food("Chocolate Keto Protein Shake", 1000, 30, 30, 20);
            Food steakVeggies = new Food("Steak with Cauliflower and Brocolli", 1200, 3, 35, 40);
            Food ketoCereal = new Food("Keto Cereal", 1300, 40, 35, 20);
            Food brocSalad = new Food("Keto Broccoli Salad ", 500, 20, 30, 10);
            Food macCheese = new Food("Keto Mac & Cheese", 200, 5, 10, 0);
            Food avoToast = new Food("Avacado Toast", 700, 30, 15, 25);
            Food salmon = new Food("Broiled Salmon", 700, 30, 15, 25);
            Food ranchChicken = new Food("Cheesy Bacon Ranch Chicken ", 700, 30, 15, 25);
            Food porkChops = new Food("Garlic Rosemary Pork Chops", 1000, 2, 25, 25);

            List<Food> Meal = new List<Food> { chocProShake, avoToast, ketoCereal , brocSalad, macCheese, steakVeggies, salmon, ranchChicken, porkChops };


            return Meal;



        }
    }
}


