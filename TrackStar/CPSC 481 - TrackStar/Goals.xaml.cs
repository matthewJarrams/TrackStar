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
        public  int currentRecIndex = 0;
        public static List<Target> targetList = new List<Target>();
        Target loseWeight = new Target("Lose 2lbs a week");
        Target run = new Target("Run 10km");

        public static List<personalRecord> recordList = new List<personalRecord>();
        public static List<personalRecord> tableList = new List<personalRecord>();
        public static personalRecord weight = new personalRecord("Weight Loss", 210, "(Lbs)", 170);
        

        personalRecord bench = new personalRecord("Bench Press (lbs)",300, "(Lbs)", 150);
        
        personalRecord fiveK = new personalRecord("5km record (mins)", 10, "Hr:Min:Seconds", 22);


        public Goals()
        {
           
            InitializeComponent();
            PrevBtn.IsEnabled = false;


            if (targetList.Count == 0)
            {   
                targetList.Add(loseWeight);
                targetList.Add(run);
            }
            if (recordList.Count == 0)
            {
                recordList.Add(weight);
                recordList.Add(bench);
                recordList.Add(fiveK);
                

                
                tableList.Add(bench);
                tableList.Add(fiveK);

                bench.recordHist.Add(155);
                bench.recordHist.Add(165);
                bench.recordHist.Add(175);
                bench.recordHist.Add(185);
                bench.goalHist.Add(300);
                bench.goalHist.Add(300);
                bench.goalHist.Add(300);
                bench.goalHist.Add(300);

                





                weight.recordHist.Add(160);
                weight.recordHist.Add(165);
                weight.recordHist.Add(155);
                weight.recordHist.Add(165);
                weight.goalHist.Add(210);
                weight.goalHist.Add(210);
                weight.goalHist.Add(210);
                weight.goalHist.Add(210);
            }

            if(tableList.Count == 0)
            {
                NextBtn.IsEnabled = false;
            }



            //goalListBox.ItemsSource = targetList;
           
            recordsListBox.ItemsSource = tableList;


           

            progVisuals.Series = recordList[currentRecIndex].SeriesCollection;
            Yaxis.Title = recordList[currentRecIndex].acttype;
            goalTitle.Content = recordList[currentRecIndex].type;
            

          



            //modifying the series collection will animate and update the chart


            //modifying any series values will also animate and update the chart




            DataContext = this;
           

        }


        public List<String> Labels { get; set; } = User.Labels;
        


        private void Home_Button_Click(object sender, RoutedEventArgs e)
        {
            /*MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().First();
            mainWindow.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;*/
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
           
           // goalListBox.ItemsSource = null;
            //goalListBox.ItemsSource = targetList;
         
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            personalRecord p = (personalRecord)b.Tag;
           
            NewGoalDialog specWindow = new NewGoalDialog(p, this);
            specWindow.Show();
            //MessageBox.Show("Updated!!");
            //p.SetNewValue(25);

            recordsListBox.ItemsSource = null;
            recordsListBox.ItemsSource = tableList;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //NewGoalDialog addGoalScreen = new NewGoalDialog();
            //addGoalScreen.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NewRecordTypeScreen addRecordScreen = new NewRecordTypeScreen();
            addRecordScreen.Show();

        }

        private void next_Vis_Click(object sender, RoutedEventArgs e)
        {
            
            if (currentRecIndex+1 < recordList.Count) // Check if it's safe to +1
            {
                progVisuals.Series = recordList[++currentRecIndex].SeriesCollection;
                Yaxis.Title = recordList[currentRecIndex].acttype;
                goalTitle.Content = recordList[currentRecIndex].type;
            }
            
            
            PrevBtn.IsEnabled = true;
            if(currentRecIndex+1 == recordList.Count) NextBtn.IsEnabled = false;
            //goalTitle.Content = recordList[currentRecIndex].type;






        }

        private void prev_Vis_Click(object sender, RoutedEventArgs e)
        {

            if (currentRecIndex-1 >= 0) // Check if safe to -1
            {
                progVisuals.Series = recordList[--currentRecIndex].SeriesCollection;
                Yaxis.Title = recordList[currentRecIndex].acttype;
                goalTitle.Content = recordList[currentRecIndex].type;
            }
            
            
            NextBtn.IsEnabled = true;
            if (currentRecIndex == 0) PrevBtn.IsEnabled = false;
            //goalTitle.Content = recordList[currentRecIndex].type;


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

 

  


}


