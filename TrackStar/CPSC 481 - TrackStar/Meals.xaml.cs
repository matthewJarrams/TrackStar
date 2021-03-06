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
        public List<String> listofFilters = new List<String>();

        public Meals()
        {
            InitializeComponent();
            lvDataBinding.ItemsSource = mps;

            filters.ItemsSource = listofFilters;

            if (User.currentMealPlan == null)
            {
                currentMealPlan.Content = "Currently No Meal Plan";
               // removeProgramBtn.IsEnabled = false;
            }
            else
            {
                currentMealPlan.Content = User.currentMealPlan.Name;
            }
        }





        public MealPlans[] mps { get; } =
            new MealPlans[]

            {
        ("Ketogenic Diet",
            "- Reduce Carb Intake \n - Burn Fat \n - Eat Healthier",
          buildMealPlan(),
        "The ketogenic diet is a low carb, high fat diet. It involves drastically reducing carbohydrate intake and replacing it with fat. This reduction in carbs puts your body into a metabolic state called ketosis. When this happens, your body becomes incredibly efficient at burning fat for energy.", "Lose weight with this unique diet that aims to get you eating lower amounts of carbs and higher amounts of fats and proteins", true, false, true,false,false,true,false,true,false,buildAllMeal(), buildTargets()),
        ("Healthy Weight Gain", "", buildMealPlan(),
        "This meal plan will add excess calories, but will do so with primarily healthy foods. The types of foods eaten aren’t that dissimilar to foods eaten when dieting, the main difference is the sheer amount.","Diet to help gain weight! Ideal for athletes or younger individuals looking to gain weight to aid in their workouts", true, false, true,false,false,false,false,false,true,buildAllMeal(), buildTargets()),
        ("Vegetarian Diet", "", buildMealPlan(),
        "Good for you, you are saving the animals but killing trees. " , "Vegatarian diet, lots of fruits and vegetables, lower amounts of protein.",false, true, false,true,true,false,true,true,false, buildAllMeal(), buildTargets()),
        ("High Protein Diet", "", buildMealPlan(),
        "Eggs, chicken, and more eggs. You'll feel like you're living on a farm.", "This plan is designed primarily for those with prior dietary experience, as this plan is not designed for the average body and does not ensure all nutritional needs are met.", false, false, true,false,false,false,false,false,true,buildAllMeal(), buildTargets()),
        ("Clean Bulk", "", buildMealPlan(),
        "Sorry to the animals, it's not personal" ,"High protein and fat, lower amounts of carbs. Great for extreme muscle builders.", false, false, true,false,true,true,false,false,true,buildAllMeal(), buildTargets()),
        ("Paleo Diet", "", buildMealPlan(),
        "Great for protein and fats." ,"Interesting new trendy diet that bases large amounts of its meals on nuts.", true,false, true,true,true,true,true,false,true, buildAllMeal(), buildTargets())
            };

        public class MealPlans
        {
            public string Description { get; set; }
            public string shortDescript { get; set; }
            public string Name { get; set; }
            public string Goals { get; set; }
            public List<List<Food>> Meals { get; set; }
            //public String Targets { get; set; }
            public bool LowCarb { get; set; }
            public bool LowFat { get; set; }
            public bool HighPro { get; set; }
            public bool Veg { get; set; }
            public bool Lac { get; set; }
            public bool Gluten { get; set; }
            public bool Gain { get; set; }
            public bool Lose { get; set; }
            public bool Maintain { get; set; }

            public List<Food> AllMeals { get; set; }
            public List<Targets> Targets { get; set; }

            public static implicit operator MealPlans((string Name, string Goals, List<List<Food>> Meals, string Description, String shortDescrip, bool LowCarb, bool LowFat, bool HighPro, bool Veg, bool Lac, bool Gluten, bool Maintain, bool Lose, bool Gain, List<Food> AllMeals, List<Targets> Targets) info)
            {
                return new MealPlans { Name = info.Name, Goals = info.Goals, Meals = info.Meals, Description = info.Description, shortDescript = info.shortDescrip, LowCarb = info.LowCarb, LowFat = info.LowFat, HighPro = info.HighPro, Veg = info.Veg, Lac = info.Lac, Gluten = info.Gluten, Maintain = info.Maintain, Lose = info.Lose, Gain = info.Gain, AllMeals = info.AllMeals, Targets = info.Targets };
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
            //MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().First();
            //mainWindow.catWindow.Show();
            Catalogue cate = new Catalogue();
            cate.Show();
            this.Visibility = Visibility.Hidden;

        }

        private void Info_Button_Click(object sender, RoutedEventArgs e)
        {
            // MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().First();
            // mainWindow.infoWindow.Show();
            InfoWindow info = new InfoWindow();
            info.Show();
            this.Visibility = Visibility.Hidden;

        }

        private void Goals_Button_Click(object sender, RoutedEventArgs e)
        {
            // MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().First();
            // MainWindow.goalsWindow.Show();
            Goals goal = new Goals();
            goal.Show();
            this.Visibility = Visibility.Hidden;

        }

        private void Spec_Meal_Cick(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Meals.MealPlans spec = button.DataContext as Meals.MealPlans;
            SpecMeal specWindow = new SpecMeal(spec);
            this.Visibility = Visibility.Hidden;
            specWindow.Show();
        }

        private void My_Meal_Cick(object sender, RoutedEventArgs e)
        {
            if (User.currentMealPlan == null)
            {
                // MessageBox.Show("You have not chosen a meal plan. If you would like a meal plan, please choose from the list below");
                Poper1.IsOpen = true;
                cover.Visibility = Visibility.Visible;
            }
            else
            {
                SpecMeal specWindow = new SpecMeal(User.currentMealPlan);
                this.Visibility = Visibility.Hidden;
                specWindow.Show();
            }
        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            Poper1.IsOpen = false;
            cover.Visibility = Visibility.Hidden;
        }


        private void Remove_Meal_Click(object sender, RoutedEventArgs e)
        {
            if (User.currentMealPlan == null)
            {
                MessageBox.Show("Nothing to remove!!");
            }
            else
            {
                Poper.IsOpen = true;
            }
        }

        private void yesDelete_Click(object sender, RoutedEventArgs e)
        {
            Poper.IsOpen = false;
            User.currentMealPlan = null;
            Meals meals = new Meals();
            this.Visibility = Visibility.Hidden;
            meals.Show();
        }

        private void noDelete_Click(object sender, RoutedEventArgs e)
        {

            Poper.IsOpen = false;

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

            List<Food> Meal = new List<Food> { chocProShake, avoToast, ketoCereal, brocSalad, macCheese, steakVeggies, salmon, ranchChicken, porkChops };


            return Meal;

        }

        public static List<Targets> buildTargets()
        {
            Target GainWeightCalorie = new Target("Calories", 2000);
            Target GainWeightFat = new Target("Fat", 100);
            Target GainWeightCarbs = new Target("Carbs", 75);
            Target GainWeightProtein = new Target("Protein", 100);
            Target LoseWeightCalorie = new Target("Calories", 2000);
            Target LoseWeightFat = new Target("Fat", 100);
            Target LoseWeightCarbs = new Target("Carbs", 75);
            Target LoseWeightProtein = new Target("Protein", 100);
            Target MaintainWeightCalorie = new Target("Calories", 2000);
            Target MaintainWeightFat = new Target("Fat", 100);
            Target MaintainWeightCarbs = new Target("Carbs", 75);
            Target MaintainWeightProtein = new Target("Protein", 100);





            List<Target> Target = new List<Target> { GainWeightCalorie, GainWeightFat, GainWeightCarbs, GainWeightProtein };
            List<Target> Target1 = new List<Target> { LoseWeightCalorie, LoseWeightFat, LoseWeightCarbs, LoseWeightProtein };
            List<Target> Target2 = new List<Target> { MaintainWeightCalorie, MaintainWeightFat, MaintainWeightCarbs, MaintainWeightProtein };

            Targets gainWeight = new Targets("Gain Weight", Target);
            Targets loseWeight = new Targets("Lose Weight", Target1);
            Targets MaintainWeight = new Targets("Gain Weight", Target2);

            List<Targets> finish = new List<Targets> { gainWeight, loseWeight, MaintainWeight };

            return finish;
        }



        public class Target
        {
            public string Title { get; set; }
            public int Amounts { get; set; }

            public Target(string d, int a)
            {
                this.Title = d;
                this.Amounts = a;
            }

        }

        public class Targets
        {
            public List<Target> TargetList { get; set; }
            public string Goal { get; set; }

            public Targets(string d, List<Target> list)
            {
                this.Goal = d;
                this.TargetList = list;
            }

        }

        private void filter_BtnClick(object sender, RoutedEventArgs e)
        {
            PoperFilter.IsOpen = true;
            cover.Visibility = Visibility.Visible;
        }

        private void CancelBtnClick(object sender, RoutedEventArgs e)
        {
            PoperFilter.IsOpen = false;
            cover.Visibility = Visibility.Hidden;
            if (currentFilterList.Count == 0)
            {
                lvDataBinding.ItemsSource = mps.ToList();
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
        public static List<MealPlans> currentFilterList = new List<MealPlans>();

        private void ApplyFilterClick(object sender, RoutedEventArgs e)
        {
            List<MealPlans> filteredList = new List<MealPlans>();
            listofFilters.Clear();
            for (int i = 0; i < mps.Length; i++)
            {
                if (mps[i].LowCarb && LowCarb.IsChecked == true)
                {
                    filteredList.Add(mps[i]);
                    continue;

                }
                if (mps[i].LowFat && LowFat.IsChecked == true)
                {
                    filteredList.Add(mps[i]);
                    continue;

                }
                if (mps[i].HighPro && highPro.IsChecked == true)
                {
                    filteredList.Add(mps[i]);
                    continue;


                }
                if (mps[i].Veg && Vegetarian.IsChecked == true)
                {
                    filteredList.Add(mps[i]);
                    continue;


                }
                if (mps[i].Lac && Dairy.IsChecked == true)
                {
                    filteredList.Add(mps[i]);
                    continue;


                }
                if (mps[i].Gluten && Gluten.IsChecked == true)
                {
                    filteredList.Add(mps[i]);
                    continue;

                }
                if (mps[i].Gain && GainWeight.IsChecked == true)
                {
                    filteredList.Add(mps[i]);
                    continue;


                }
                if (mps[i].Lose && LoseWeight.IsChecked == true)
                {
                    filteredList.Add(mps[i]);
                    continue;

                }
                if (mps[i].Maintain && ManWeight.IsChecked == true)
                {
                    filteredList.Add(mps[i]);
                    continue;


                }

                if (LowCarb.IsChecked == true)
                {

                    if (listofFilters.Contains("Low Carb") == false)
                    {
                        listofFilters.Add("Low Carb");
                    }

                }
                if (LowFat.IsChecked == true)
                {

                    if (listofFilters.Contains("Low Fat") == false)
                    {
                        listofFilters.Add("Low Fat");
                    }
                }
                if (highPro.IsChecked == true)
                {
                    if (listofFilters.Contains("High Protein") == false)
                    {
                        listofFilters.Add("High Protein");

                    }


                }
                if (Vegetarian.IsChecked == true)
                {

                    if (listofFilters.Contains("Vegetarian") == false)
                    {
                        listofFilters.Add("Vegetarian");
                    }


                }
                if (Dairy.IsChecked == true)
                {

                    if (listofFilters.Contains("Dairy-Free") == false)
                    {
                        listofFilters.Add("Dairy-Free");
                    }
                }
                if (Gluten.IsChecked == true)
                {
                    if (listofFilters.Contains("Gluten-Free") == false)
                    {
                        listofFilters.Add("Gluten-Free");
                    }


                }
                if (GainWeight.IsChecked == true)
                {
                    if (listofFilters.Contains("Gain Weight") == false)
                    {
                        listofFilters.Add("Gain Weight");
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
                    if (listofFilters.Contains("Maintain Weight") == false)
                    {
                        listofFilters.Add("Maintain Weight");
                    }


                }
            }

            if (LowCarb.IsChecked == false && LowFat.IsChecked == false && highPro.IsChecked == false && Vegetarian.IsChecked == false && Dairy.IsChecked == false && Gluten.IsChecked == false && GainWeight.IsChecked == false && ManWeight.IsChecked == false && LoseWeight.IsChecked == false)
            {
                lvDataBinding.ItemsSource = mps;
                listofFilters.Clear();
                filters.ItemsSource = null;
                filters.ItemsSource = listofFilters;
                currentFilterList = mps.ToList();

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

