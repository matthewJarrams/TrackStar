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
    /// Interaction logic for NewGoalDialog.xaml
    /// </summary>
    public partial class NewGoalDialog : Window
    {
        public static String response;
        public NewGoalDialog()
        {
            InitializeComponent();
            
        }

        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            response = txtAnswer.Text;
            Target newGoal = new Target(response);
            MainWindow.goalsWindow.Visibility = Visibility.Hidden;
            Goals.targetList.Add(newGoal);
            Goals goalScreenNew = new Goals();
            this.Visibility = Visibility.Hidden;
            goalScreenNew.Show();
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            txtAnswer.SelectAll();
            txtAnswer.Focus();
        }

        public string Answer
        {
            get { return txtAnswer.Text; }
        }
    }
}
