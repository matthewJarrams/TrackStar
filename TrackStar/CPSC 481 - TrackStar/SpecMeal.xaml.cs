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
        public SpecMeal(Meals.MealPlans spec)
        {
            InitializeComponent();
            mealTitle.Content = spec.Name;
            descripBox.Text = spec.Description;
            mealOnScreen = spec;
            lbTodoList.ItemsSource = spec.AllMeals;
            TargetList.Visibility = Visibility.Hidden;
            TargetList.ItemsSource = spec.Targets[1].TargetList;
            Titl.Content = "Description";



        }


        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            //MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().First();
            //mainWindow.mealsWindow.Show();
            Meals meals = new Meals();
            this.Visibility = Visibility.Hidden;
            meals.Show();

        }

        private void setMealPlan_Click(object sender, RoutedEventArgs e)
        {
            // Button button = sender as Button;
            // Meals.MealPlans spec = button.DataContext as Meals.MealPlans;
            User.currentMealPlan = mealOnScreen;
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            // Button button = sender as Button;
            // Meals.MealPlans spec = button.DataContext as Meals.MealPlans;
            if (Titl.Content.Equals("Description"))
            {
                Titl.Content = "Targets";
                descripBox.Visibility = Visibility.Hidden;
                TargetList.Visibility = Visibility.Visible;

            }
            else if (Titl.Content.Equals("Targets"))
            {
                Titl.Content = "Goals";
                descripBox.Visibility = Visibility.Visible;
                TargetList.Visibility = Visibility.Hidden;
                descripBox.Text = mealOnScreen.Goals;
                descripBox.FontSize = 14;
                descripBox.SetValue(TextBlock.FontWeightProperty, FontWeights.Bold);

            }
            else if (Titl.Content.Equals("Goals"))
            {
                Titl.Content = "Description";
                descripBox.Text = mealOnScreen.Description;
                descripBox.FontSize = 12;
                descripBox.SetValue(TextBlock.FontWeightProperty, FontWeights.Normal);

            }
        }

        private void Prev_Click(object sender, RoutedEventArgs e)
        {
            // Button button = sender as Button;
            // Meals.MealPlans spec = button.DataContext as Meals.MealPlans;
            if (Titl.Content.Equals("Targets"))
            {
                Titl.Content = "Description";
                descripBox.Visibility = Visibility.Visible;
                TargetList.Visibility = Visibility.Hidden;
                descripBox.Text = mealOnScreen.Description;
                descripBox.FontSize = 12;
                descripBox.SetValue(TextBlock.FontWeightProperty, FontWeights.Normal);

            }
            else if (Titl.Content.Equals("Goals"))
            {
                Titl.Content = "Targets";
                descripBox.Visibility = Visibility.Hidden;
                TargetList.Visibility = Visibility.Visible;

            }
            else if (Titl.Content.Equals("Description"))
            {
                Titl.Content = "Goals";
                descripBox.Visibility = Visibility.Visible;
                TargetList.Visibility = Visibility.Hidden;
                descripBox.Text = mealOnScreen.Goals;
                descripBox.FontSize = 14;
                descripBox.SetValue(TextBlock.FontWeightProperty, FontWeights.Bold);

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

        private void ComboBox_SelectionChangedGoal(object sender, SelectionChangedEventArgs e)
        {
            if (mealOnScreen != null)
            {
                if (Goaler.SelectedItem == lowCarb) TargetList.ItemsSource = mealOnScreen.Targets[1].TargetList;
            }
            if (Goaler.SelectedItem == lowCalorie) TargetList.ItemsSource = mealOnScreen.Targets[2].TargetList;
            if (Goaler.SelectedItem == gainWeight) TargetList.ItemsSource = mealOnScreen.Targets[0].TargetList;



        }
    }
}