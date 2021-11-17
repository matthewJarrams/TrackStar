﻿using System;
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
        public static String age = "22";
        public static String gender = "Male";
        public static int goalsCompleted = 5;
        public static int progCompleted = 10;
        public static int mealCompleted = 11;
        public static int workCompleted = 12;
        public static int targetCompleted = 16;
        public static int programDaysLeft = 20;
        public static int currentProgramWorkoutsCompleted = 10;

        public static LiveCharts.ChartValues<int> weightHist = new LiveCharts.ChartValues<int>() {
        150, 155, 160, 165, 170, 155};

        public static LiveCharts.ChartValues<int> benchHist = new LiveCharts.ChartValues<int>() {
        200, 255, 260, 265, 270, 255};

        public static List<String> Labels = new List<String>() { "Jan 23", "Feb 12", "Mar 13", "Apr 20", "May 12", "Jun 24" };

        public static SeriesCollection weightCollection { get; set; }




    }

    public class personalRecord
    {
        public string type { get; set; }
        public int value { get; set; }

        public LiveCharts.ChartValues<int> recordHist = new LiveCharts.ChartValues<int>();
        public SeriesCollection SeriesCollection { get; set; }



        public personalRecord(string type, int value)
        {
            this.type = type;
            this.value = value;
            recordHist.Add(value);


            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = type,
                    Fill = Brushes.Transparent,
                    Stroke = Brushes.Coral,
                    Values = recordHist
                }

            };
        }

        public void SetNewValue(int newValue)
        {
            value = newValue;
            recordHist.Add(newValue);
        }
    }
}