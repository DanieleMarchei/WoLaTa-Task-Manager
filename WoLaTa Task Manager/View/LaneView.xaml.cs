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
using WoLaTa_Task_Manager.ViewModel;



namespace WoLaTa_Task_Manager.View
{
    /// <summary>
    /// Interaction logic for LaneView.xaml
    /// </summary>
    public partial class LaneView : UserControl
    {

        private LaneViewModel LaneViewModel;

        public LaneView(LaneViewModel lvm)
        {
            InitializeComponent();
            LaneViewModel = lvm;
            UpdateTasks();
        }

        private void UpdateTasks()
        {
            TaskList.Children.Clear();
            foreach (var task in LaneViewModel.Lane)
            {
                TodoTaskView tv = new TodoTaskView(new TodoTaskViewModel(task), LaneViewModel);
                TaskList.Children.Add(tv);
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = LaneViewModel;
        }

        private void CreateNewTask(object sender, RoutedEventArgs e)
        {
            LaneViewModel.AddTask();
            UpdateTasks();
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            LaneEditDialog laneEdit = new LaneEditDialog();
            laneEdit.DataContext = LaneViewModel;
            laneEdit.Show();
        }
    }
}
