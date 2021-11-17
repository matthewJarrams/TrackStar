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
    }
}
