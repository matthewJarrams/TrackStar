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
    /// Interaction logic for InfoWindow.xaml
    /// </summary>
    public partial class InfoWindow : Window
    {
        public static  List<PersonalInfo> userInfoList = new List<PersonalInfo>();
        public InfoWindow()
        {
            InitializeComponent();
            PersonalInfo weight = new PersonalInfo("Weight (lbs)", User.weight);
            PersonalInfo height = new PersonalInfo("Height (meters)", User.height);
            PersonalInfo age = new PersonalInfo("Age", User.age);
            PersonalInfo gender = new PersonalInfo("Gender", User.gender);

            if (userInfoList.Count == 0)
            {
                userInfoList.Add(weight);
                userInfoList.Add(height);
                userInfoList.Add(age);
                userInfoList.Add(gender);
            }

            nameLbl.Content = User.name;

            lbTodoList.ItemsSource = userInfoList;

            goalsComp.Content = User.goalsCompleted;
            progComp.Content = User.progCompleted;
            mealPlansComp.Content = User.mealCompleted;
            workoutsComp.Content = User.workCompleted;
            nutTargets.Content = User.targetCompleted;

            
                

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

        private void Goals_Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().First();
            MainWindow.goalsWindow.Show();
            this.Visibility = Visibility.Hidden;

        }

        private void Meals_Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().First();
            mainWindow.mealsWindow.Show();
            this.Visibility = Visibility.Hidden;

        }

        public class PersonalInfo
        {
            public string attribute { get; set; }
            public string value { get; set; }

            public PersonalInfo(String attribute, String value)
            {
                this.attribute = attribute;
                this.value = value;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow setWindow = new SettingsWindow();
            this.Visibility = Visibility.Hidden;
            setWindow.Show();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            User.weightHist.Add(200);
            User.Labels.Add("July 1st");
        }
    }
}
