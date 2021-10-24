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
    /// Interaction logic for NewRecordTypeScreen.xaml
    /// </summary>
    public partial class NewRecordTypeScreen : Window
    {
        public static string recordType;
        public static int value;

        public NewRecordTypeScreen()
        {
            InitializeComponent();
        }

        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            recordType = txtAnswer.Text;
            value = int.Parse(txtValue.Text);
            personalRecord newRecord = new personalRecord(recordType, value);
            Goals.recordList.Add(newRecord);
            Goals goalScreen = new Goals();
            this.Visibility = Visibility.Hidden;
            goalScreen.Show();
        }
    }
}
