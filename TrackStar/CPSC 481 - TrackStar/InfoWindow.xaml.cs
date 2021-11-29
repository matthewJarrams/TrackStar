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
        public static PersonalInfo mainTarget;
        public static int selectedIndex = 0;
        
        public PersonalInfo weight = new PersonalInfo("Weight (lbs)", Goals.weight.value.ToString());
        public  PersonalInfo height = new PersonalInfo("Height (ft'in)", User.height);
        public PersonalInfo age = new PersonalInfo("Age", ((User.age.Year.ToString()) + "/" + (User.age.Month.ToString()) + "/" + (User.age.Day.ToString())));
        public PersonalInfo gender = new PersonalInfo("Gender", User.gender);
        public InfoWindow()
        {
            InitializeComponent();
            combo.ItemsSource = Goals.recordList;
            combo.SelectedIndex = selectedIndex;

            

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

            Poper3.IsOpen = true;
            cover.Visibility = Visibility.Visible;
            key.Visibility = Visibility.Visible;
            heighter.Text = User.height;
            weighter.Text = Goals.weight.value.ToString();
            dob.SelectedDate = new DateTime(1999,06,24);
            if (User.gender == "Male")
            {
                male.IsChecked = true;
                female.IsChecked = false;
                other.IsChecked = false;
            }
            else if (User.gender == "Female")
            {
                male.IsChecked = false;
                female.IsChecked = true;
                other.IsChecked = false;
            }
            else
            {
                male.IsChecked = false;
                female.IsChecked = false;
                other.IsChecked = true;
            }

        }

        private void updater_Click(object sender, RoutedEventArgs e)
        {
            // NewGoalDialog ngd = new NewGoalDialog(pinnedRecord, null);
            //ngd.Show();

            //DateTime newDate = new DateTime(dob.SelectedDate);
            userInfoList[2].value = dob.SelectedDate.Value.ToShortDateString();

            Goals.weight.SetNewValue(double.Parse(weighter.Text));
            Goals.weight.SetNewGoal(Goals.weight.goal);

            userInfoList[0].value = weighter.Text;

            userInfoList[1].value = heighter.Text;

            if(male.IsChecked == true)
            {
                User.gender = "Male";
            }
            if (female.IsChecked == true)
            {
                User.gender = "Female";
            }
            if (other.IsChecked == true)
            {
                User.gender = "Other";
            }
            userInfoList[3].value = User.gender;

            Poper3.IsOpen = false;
            cover.Visibility = Visibility.Hidden;
            key.Visibility = Visibility.Hidden;
            lbTodoList.ItemsSource = null;
            lbTodoList.ItemsSource = userInfoList;
            InfoWindow info = new InfoWindow();
            this.Visibility = Visibility.Hidden;
            info.Show();
            
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            // NewGoalDialog ngd = new NewGoalDialog(pinnedRecord, null);
            //ngd.Show();
            Poper3.IsOpen = false;
            cover.Visibility = Visibility.Hidden;
            key.Visibility = Visibility.Hidden;

        }

        private void combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            MainWindow.pinnedRecord = Goals.recordList[combo.SelectedIndex];
            selectedIndex = combo.SelectedIndex;
        }
    }
}
