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
    /// Interaction logic for SpecMeal.xaml
    /// </summary>
    public partial class SpecMeal : Window
    {
        public Meals.MealPlans mealOnScreen;
        public int counter = 0;
        public SpecMeal(Meals.MealPlans spec)
        {
            InitializeComponent();
            mealTitle.Content = spec.Name;
            descripBox.Text = spec.Description;
            mealOnScreen = spec;
            lbTodoList.ItemsSource = spec.AllMeals;
            TargetList.Visibility = Visibility.Hidden;
            TargetList.ItemsSource = spec.Targets[0].TargetList;
            Titl.Content = "Description";
            setLabel.Visibility = Visibility.Hidden;
            

            if(User.currentMealPlan != null && User.currentMealPlan.Name == spec.Name)
            {
                mealPlanBtn.Visibility = Visibility.Hidden;
                RemoveBtn.Visibility = Visibility.Visible;
               // mealPlanBtn.Click -= Remove_Meal_Click;
               // mealPlanBtn.BorderBrush = Brushes.Red;
               // mealPlanBtn.Content = "Remove";
               // mealPlanBtn.IsEnabled = true;
            }




        }


        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            //MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().First();
            //mainWindow.mealsWindow.Show();
            Meals meals = new Meals();
            this.Visibility = Visibility.Hidden;

            meals.Show();

        }

        private void yesDelete_Click(object sender, RoutedEventArgs e)
        {
            User.currentMealPlan = mealOnScreen;
            Poper.IsOpen = false;
            cover.Visibility = Visibility.Hidden;
            setLabel.Visibility = Visibility.Visible;
            mealPlanBtn.IsEnabled = false;

        }

        private void noDelete_Click(object sender, RoutedEventArgs e)
        {

            Poper.IsOpen = false;
            cover.Visibility = Visibility.Hidden;

        }


        private void setMealPlan_Click(object sender, RoutedEventArgs e)
        {
            
            if (User.currentMealPlan != null)
            {
                Poper.IsOpen = true;
                cover.Visibility = Visibility.Visible;

            }
            else
            {
                User.currentMealPlan = mealOnScreen;
                setLabel.Visibility = Visibility.Visible;
                mealPlanBtn.IsEnabled = false;

            }
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            // Button button = sender as Button;
            // Meals.MealPlans spec = button.DataContext as Meals.MealPlans;
            if (counter == 0)
            {
                Titl.SetValue(TextBlock.FontWeightProperty, FontWeights.Light);
                targer.SetValue(TextBlock.FontWeightProperty, FontWeights.Bold);
                descripBox.Visibility = Visibility.Hidden;
                TargetList.Visibility = Visibility.Visible;
                counter++;

            }
            else if (counter == 1)
            {
                //Titl.Content = "Goals";
                goalser.SetValue(TextBlock.FontWeightProperty, FontWeights.Bold);
                targer.SetValue(TextBlock.FontWeightProperty, FontWeights.Light);
                descripBox.Visibility = Visibility.Visible;
                TargetList.Visibility = Visibility.Hidden;
                descripBox.Text = mealOnScreen.Goals;
                descripBox.FontSize = 14;
                descripBox.SetValue(TextBlock.FontWeightProperty, FontWeights.Bold);
                counter++;

            }
            else if (counter == 2)
            {
                //Titl.Content = "Description";
                goalser.SetValue(TextBlock.FontWeightProperty, FontWeights.Light);
                Titl.SetValue(TextBlock.FontWeightProperty, FontWeights.Bold);
                descripBox.Text = mealOnScreen.Description;
                descripBox.FontSize = 12;
                descripBox.SetValue(TextBlock.FontWeightProperty, FontWeights.Normal);
                counter = 0;

            }
        }

        private void Prev_Click(object sender, RoutedEventArgs e)
        {
            // Button button = sender as Button;
            // Meals.MealPlans spec = button.DataContext as Meals.MealPlans;
            if (counter == 1)
            {
                //Titl.Content = "Description";
                Titl.SetValue(TextBlock.FontWeightProperty, FontWeights.Bold);
                targer.SetValue(TextBlock.FontWeightProperty, FontWeights.Light);
                descripBox.Visibility = Visibility.Visible;
                TargetList.Visibility = Visibility.Hidden;
                descripBox.Text = mealOnScreen.Description;
                descripBox.FontSize = 12;
                descripBox.SetValue(TextBlock.FontWeightProperty, FontWeights.Normal);
                counter--;

            }
            else if (counter == 2)
            {
                //Titl.Content = "Targets";
                goalser.SetValue(TextBlock.FontWeightProperty, FontWeights.Light);
                targer.SetValue(TextBlock.FontWeightProperty, FontWeights.Bold);
                descripBox.Visibility = Visibility.Hidden;
                TargetList.Visibility = Visibility.Visible;
                counter--;

            }
            else if (counter == 0)
            {
                //Titl.Content = "Goals";
                goalser.SetValue(TextBlock.FontWeightProperty, FontWeights.Bold);
                Titl.SetValue(TextBlock.FontWeightProperty, FontWeights.Light);
                descripBox.Visibility = Visibility.Visible;
                TargetList.Visibility = Visibility.Hidden;
                descripBox.Text = mealOnScreen.Goals;
                descripBox.FontSize = 14;
                descripBox.SetValue(TextBlock.FontWeightProperty, FontWeights.Bold);
                counter = 2;

            }

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (mealOnScreen != null)
            {
                if (MealSel.SelectedItem == All) lbTodoList.ItemsSource = mealOnScreen.AllMeals;
            }
            if (MealSel.SelectedItem == Breakfast) lbTodoList.ItemsSource = mealOnScreen.Meals[0];
            if (MealSel.SelectedItem == Lunch) lbTodoList.ItemsSource = mealOnScreen.Meals[1];
            if (MealSel.SelectedItem == Dinner) lbTodoList.ItemsSource = mealOnScreen.Meals[2];


        }

        /*private void ComboBox_SelectionChangedGoal(object sender, SelectionChangedEventArgs e)
        {
            if (mealOnScreen != null)
            {
                if (Goaler.SelectedItem == lowCarb) TargetList.ItemsSource = mealOnScreen.Targets[1].TargetList;
            }
            if (Goaler.SelectedItem == lowCalorie) TargetList.ItemsSource = mealOnScreen.Targets[2].TargetList;
            if (Goaler.SelectedItem == gainWeight) TargetList.ItemsSource = mealOnScreen.Targets[0].TargetList;



        }*/

        private void Remove_Meal_Click(object sender, RoutedEventArgs e)
        {
           
            
                Poper1.IsOpen = true;
                cover.Visibility = Visibility.Visible;
            
        }

        private void yesRemove_Click(object sender, RoutedEventArgs e)
        {
            Poper1.IsOpen = false;
            cover.Visibility = Visibility.Hidden;
            User.currentMealPlan = null;
            SpecMeal meals = new SpecMeal(mealOnScreen);
            this.Visibility = Visibility.Hidden;
            meals.Show();
        }

        private void noRemove_Click(object sender, RoutedEventArgs e)
        {

            Poper1.IsOpen = false;
            cover.Visibility = Visibility.Hidden;

        }

    }
}