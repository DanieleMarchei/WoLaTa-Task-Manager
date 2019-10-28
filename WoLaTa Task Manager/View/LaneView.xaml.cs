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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WoLaTa_Task_Manager.Model;
using WoLaTa_Task_Manager.ViewModel;

namespace WoLaTa_Task_Manager.View
{
    /// <summary>
    /// Interaction logic for LaneView.xaml
    /// </summary>
    public partial class LaneView : UserControl
    {
        public static readonly DependencyProperty LaneProperty =
            DependencyProperty.Register("Lane", typeof(Lane), typeof(LaneView));
                                        //new PropertyMetadata((string)""));

        public Lane Lane
        {
            get { return (Lane)GetValue(LaneProperty); }
            set { SetValue(LaneProperty, value); }
        }

        //public LaneViewModel LaneViewModel { get; private set; }

        public LaneView()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            LaneViewModel LaneViewModel = new LaneViewModel(Lane);
            DataContext = LaneViewModel;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
