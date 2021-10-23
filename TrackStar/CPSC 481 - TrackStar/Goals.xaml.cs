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
    /// Interaction logic for Goals.xaml
    /// </summary>
    /// 

    public partial class Goals : Window
    {
        public static List<Target> targetList = new List<Target>();

        public Goals()
        {
            InitializeComponent();
            Target loseWeight = new Target("Lose 2lbs a week");
            Target run = new Target("Run 10km");
            targetList.Add(loseWeight);
            targetList.Add(run);

            lbTodoList.ItemsSource = targetList;
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

        private void Meals_Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().First();
            mainWindow.mealsWindow.Show();
            this.Visibility = Visibility.Hidden;

        }
        
           
   
        private void CompBtn_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            Target p = (Target)b.Tag;
            MessageBox.Show(p.target);
            p.SetComplete(true);
           
            lbTodoList.ItemsSource = null;
            lbTodoList.ItemsSource = targetList;
         
        }


    }
    public class Target
    {
        public string target { get; set; }
        public bool complete = false;
        public string message { get; set; }


        public Target(string target)
        {
            this.target = target;
            this.message = "Not Complete";
        }


        public void SetComplete(bool isComplete)
        {
            complete = isComplete;
            this.message = "Awesome! Goal Completed!";
        }
        


    }
}


