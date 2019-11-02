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
        public LaneView(Lane lane)
        {
            InitializeComponent();
            foreach (TodoTask task in lane)
            {
                TodoTaskView lv = new TodoTaskView(new TodoTaskViewModel(task));
                TaskList.Children.Add(lv);
            }
            DataContext = new LaneViewModel(lane);
        }

        private void CreateNewTask(object sender, RoutedEventArgs e)
        {
            LaneViewModel lvm = DataContext as LaneViewModel;
            lvm.AddTask();
            TodoTaskView task = new TodoTaskView(new TodoTaskViewModel(lvm.Lane.Last()));
            TaskList.Children.Add(task);
        }
    }
}
