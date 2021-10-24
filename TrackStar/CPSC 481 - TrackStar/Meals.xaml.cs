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
        }

            public MealPlans[] mps { get; } =
            new MealPlans[]


            {
            ("Keto", "","",
            "This is a keto diet great for feeling like you're losing weight." ),
            ("Weight gain", "","",
            "This is the best way to get SWOLEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" ),
            ("veggie", "","",
            "Good for you, you are saving the animals but killing trees. " ),
            ("Fast FOOD", "","",
            "Mcdonalds is the best fastfood but wendy's has the best burgers. Dairy queen burgers are also very underrated and better than their ice cream" ),
            ("Meat only", "","",
            "Sorry to the animals it's not personal" ),
            ("NUts only", "","",
            "Great for protein and fats underrated food group." )
            };

            public class MealPlans
            {
                public string Description { get; set; }
                public string Name { get; set; }
                public string Title { get; set; }
                public string Length { get; set; }

                public static implicit operator MealPlans((string Name, string Title, string Length, string Description) info)
                {
                    return new MealPlans { Name = info.Name, Title = info.Title, Length = info.Length, Description = info.Description };
                }
            }

            private void Home_Button_Click(object sender, RoutedEventArgs e)
            {
                MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().First();
                mainWindow.Visibility = Visibility.Visible;
                this.Visibility = Visibility.Hidden;
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
                mainWindow.goalsWindow.Show();
                this.Visibility = Visibility.Hidden;

            }
        }
    }


