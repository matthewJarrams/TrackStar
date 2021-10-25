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
        public SpecMeal(Meals.MealPlans spec)
        {
            InitializeComponent();
            Meals.MealPlans[] thisMeal = new Meals.MealPlans[] {spec};
            lvDataBinding.ItemsSource = thisMeal;
        }


        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().First();
            mainWindow.mealsWindow.Show();
            this.Visibility = Visibility.Hidden;

        }
    }
}
