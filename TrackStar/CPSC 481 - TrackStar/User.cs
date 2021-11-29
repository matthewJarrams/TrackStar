using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
    public class User
    {
        public static String name = "Micheal Truman";
        public static Program currentProgram;
        public static Meals.MealPlans currentMealPlan;
        public static String weight = "700";
        public static String height = "5'11";
        public static DateTime age = new DateTime(1999,06,24);
        public static String gender = "Male";
        public static int goalsCompleted = 5;
        public static int progCompleted = 10;
        public static int mealCompleted = 11;
        public static int workCompleted = 12;
        public static int targetCompleted = 16;
        public static int programDaysLeft = 0;
        public static int currentProgramWorkoutsCompleted = 0;
        public static int currentProgramMissedWorkouts = 0;


        public static LiveCharts.ChartValues<double> weightHist = new LiveCharts.ChartValues<double>() {
        150, 155, 160, 165, 170, 155};

        public static LiveCharts.ChartValues<double> benchHist = new LiveCharts.ChartValues<double>() {
        200, 255, 260, 265, 270, 255};

        public static List<String> Labels = new List<String>() { "Jan 23", "Feb 12", "Mar 13", "Apr 20", "May 12", "Jun 24" };

        public static SeriesCollection weightCollection { get; set; }




    }

    public class personalRecord
    {
        public string type { get; set; }
        public double value { get; set; }
        public string acttype { get; set; }
        public double goal { get; set; }
        public Boolean hours {get;set;}
        public bool increasing { get; set; }
        public  List<String> Labels { get; set; }

        public LiveCharts.ChartValues<double> recordHist = new LiveCharts.ChartValues<double>();
        public LiveCharts.ChartValues<double> goalHist = new LiveCharts.ChartValues<double>();
        public SeriesCollection SeriesCollection { get; set; }



        public personalRecord(string type, double goal, string acttype, double value,bool increasing, List<String> Labels)
        {
            this.type = type;
            this.value = value;
            this.acttype = acttype;
            this.goal = goal;
            this.Labels = Labels;
            goalHist.Add(goal);
            recordHist.Add(value);
            hours = false;
            this.increasing = increasing;

            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = type,
                    Fill = Brushes.Transparent,
                    Stroke = Brushes.Coral,
                    Values = recordHist
                },

                new LineSeries
                {
                    Title = "Target",
                    Fill = Brushes.Transparent,
                    Values = goalHist
                }

            };
        }

        public void SetNewValue(double newValue)
        {
            value = newValue;
            recordHist.Add(newValue);
            Labels.Add("Nov 29th");
        }
        public void SetNewGoal(double newValue)
        {
            goal = newValue;
            goalHist.Add(newValue);
        }
        public void setHours(bool set)
        {
            this.hours = set;
        }
        
    }
}
