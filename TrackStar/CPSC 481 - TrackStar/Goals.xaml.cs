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

using LiveCharts;
using LiveCharts.Wpf;



namespace CPSC_481___TrackStar
{
    /// <summary>
    /// Interaction logic for Goals.xaml
    /// </summary>
    /// 

    public partial class Goals : Window
    {
        public static List<Target> targetList = new List<Target>();
        Target loseWeight = new Target("Lose 2lbs a week");
        Target run = new Target("Run 10km");

        public static List<personalRecord> recordList = new List<personalRecord>();
        personalRecord bench = new personalRecord("Bench Press (lbs)", 150);
        personalRecord fiveK = new personalRecord("5km record (mins)", 22);


        public Goals()
        {
           
            InitializeComponent();

           

            if (targetList.Count == 0)
            {   
                targetList.Add(loseWeight);
                targetList.Add(run);
            }
            if (recordList.Count == 0)
            {           
                recordList.Add(bench);
                recordList.Add(fiveK);
            }

            goalListBox.ItemsSource = targetList;
            recordsListBox.ItemsSource = recordList;

            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Weight",
                    Fill = Brushes.Transparent,
                    Stroke = Brushes.Coral,
                    Values = new ChartValues<double> { 160, 165, 170, 150 ,140 }
                }

            };

            Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May" };
           

            //modifying the series collection will animate and update the chart


            //modifying any series values will also animate and update the chart


            DataContext = this;
        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        


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
            MessageBox.Show("You rock!!");
            p.SetComplete(true);
           
            goalListBox.ItemsSource = null;
            goalListBox.ItemsSource = targetList;
         
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewGoalDialog addGoalScreen = new NewGoalDialog();
            addGoalScreen.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NewRecordTypeScreen addRecordScreen = new NewRecordTypeScreen();
            addRecordScreen.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //progressVisuals.Source = new BitmapImage(new Uri(@"C:\Users\User\source\repos\TrackStar\CPSC 481 - TrackStar\977451.png"));

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
            this.message = "Goal Completed!";
        }
        


    }

    public class personalRecord
    {
        public string type { get; set; }
        public int value { get; set; }


        public personalRecord(string type, int value)
        {
            this.type = type;
            this.value = value; 
        }


        public void SetNewValue(int newValue)
        {
            value = newValue;
            
        }



    }

  


}


