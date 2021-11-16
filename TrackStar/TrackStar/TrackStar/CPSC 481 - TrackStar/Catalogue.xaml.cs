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
    /// Interaction logic for Catalogue.xaml
    /// </summary>
    public partial class Catalogue : Window
    {
        public Catalogue()
        {
            InitializeComponent();
        }

        private void Home_Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().First();
            mainWindow.Visibility = Visibility.Visible;
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
            MainWindow.goalsWindow.Show();
            this.Visibility = Visibility.Hidden;

        }
        private void Meals_Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().First();
            mainWindow.mealsWindow.Show();
            this.Visibility = Visibility.Hidden;

        }

        private void removeProgramBtn_Click(object sender, RoutedEventArgs e)
        {
            currentProgram.Content = "No Program Currently Selected";
        }

        private void viewProgramBtn_Click(object sender, RoutedEventArgs e)
        {
            /*MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().First();
            mainWindow.programScreen.Show();
            this.Visibility = Visibility.Hidden;*/
            ProgramScreen progScreen = new ProgramScreen(1);
            this.Visibility = Visibility.Hidden;
            progScreen.Show();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("The" + catalogueStack.Children.Count);
            catalogueStack.Children.Remove(cardioGrid);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            /*MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().First();
            mainWindow.programScreen.Show();
            this.Visibility = Visibility.Hidden;*/
            ProgramScreen progScreen = new ProgramScreen(2);
            this.Visibility = Visibility.Hidden;
            progScreen.Show();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (filter.SelectedItem == high)
            {
                if (catalogueStack.Children.Contains(strengthGrid) == false)
                {
                    catalogueStack.Children.Add(strengthGrid);
                }
                

                catalogueStack.Children.Remove(cardioGrid);
                catalogueStack.Children.Remove(fullBodyGrid);
            }
            if(filter.SelectedItem == medium)
            {
                if (catalogueStack.Children.Contains(cardioGrid) == false)
                {
                    catalogueStack.Children.Insert(0, cardioGrid);
                    catalogueStack.Children.Insert(1, fullBodyGrid);
                }
                catalogueStack.Children.Remove(strengthGrid);
            }
            if(filter.SelectedItem == low)
            {
                catalogueStack.Children.RemoveRange(0, 3);
            }
        }
    }
}
