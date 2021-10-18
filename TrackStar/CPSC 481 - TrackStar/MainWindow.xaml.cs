﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CPSC_481___TrackStar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            completionBar.Maximum = 30;
            completionBar.Value = Window1.completedWorkouts;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window1 objWindow1 = new Window1();
            this.Visibility = Visibility.Hidden;
            objWindow1.Show();
        }


        private void Home_Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow objMainWindow = new MainWindow();
            this.Visibility = Visibility.Hidden;
            objMainWindow.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}