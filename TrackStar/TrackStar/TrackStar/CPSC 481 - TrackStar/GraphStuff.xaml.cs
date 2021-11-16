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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Reflection;

namespace CPSC_481___TrackStar
{
    /// <summary>
    /// Interaction logic for GraphStuff.xaml
    /// </summary>
    public partial class GraphStuff : Window
    {
        public GraphStuff()
        {
            InitializeComponent();
            List<Bar> _bar = new List<Bar>();
            _bar.Add(new Bar() { BarName = "Rajesh", Value = 80 });
            _bar.Add(new Bar() { BarName = "Suresh", Value = 60 });
            _bar.Add(new Bar() { BarName = "Dan", Value = 40 });
            _bar.Add(new Bar() { BarName = "Sevenx", Value = 67 });
            _bar.Add(new Bar() { BarName = "Patel", Value = 15 });
            _bar.Add(new Bar() { BarName = "Joe", Value = 70 });
            _bar.Add(new Bar() { BarName = "Bill", Value = 90 });
            _bar.Add(new Bar() { BarName = "Vlad", Value = 23 });
            _bar.Add(new Bar() { BarName = "Steve", Value = 12 });
            _bar.Add(new Bar() { BarName = "Pritam", Value = 100 });
            _bar.Add(new Bar() { BarName = "Genis", Value = 54 });
            _bar.Add(new Bar() { BarName = "Ponnan", Value = 84 });
            _bar.Add(new Bar() { BarName = "Mathew", Value = 43 });
            this.DataContext = new RecordCollection(_bar);


        }
    }

    class RecordCollection : ObservableCollection<Record>
    {

        public RecordCollection(List<Bar> barvalues)
        {
            Random rand = new Random();
            BrushCollection brushcoll = new BrushCollection();

            foreach (Bar barval in barvalues)
            {
                int num = rand.Next(brushcoll.Count / 3);
                Add(new Record(barval.Value, brushcoll[num], barval.BarName));
            }
        }

    }

    class BrushCollection : ObservableCollection<Brush>
    {
        public BrushCollection()
        {
            Type _brush = typeof(Brushes);
            PropertyInfo[] props = _brush.GetProperties();
            foreach (PropertyInfo prop in props)
            {
                Brush _color = (Brush)prop.GetValue(null, null);
                if (_color != Brushes.LightSteelBlue && _color != Brushes.White &&
                     _color != Brushes.WhiteSmoke && _color != Brushes.LightCyan &&
                     _color != Brushes.LightYellow && _color != Brushes.Linen)
                    Add(_color);
            }
        }
    }

    class Bar
    {

        public string BarName { set; get; }

        public int Value { set; get; }

    }

    class Record : INotifyPropertyChanged
    {
        public Brush Color { set; get; }

        public string Name { set; get; }

        private int _data;
        public int Data
        {
            set
            {
                if (_data != value)
                {
                    _data = value;

                }
            }
            get
            {
                return _data;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Record(int value, Brush color, string name)
        {
            Data = value;
            Color = color;
            Name = name;
        }

        protected void PropertyOnChange(string propname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propname));
            }
        }
    }

}
