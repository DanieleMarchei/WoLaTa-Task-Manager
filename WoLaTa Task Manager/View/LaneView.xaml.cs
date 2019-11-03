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
using WoLaTa_Task_Manager.Model;



namespace WoLaTa_Task_Manager.View
{
    /// <summary>
    /// Interaction logic for LaneView.xaml
    /// </summary>
    public partial class LaneView : UserControl
    {
        private readonly LaneViewModel laneViewModel;

        public LaneView(Lane lane)
        {
            InitializeComponent();
            laneViewModel = new LaneViewModel(lane);
            UpdateTasks();
            DataContext = laneViewModel;
        }

        private void UpdateTasks()
        {
            TaskList.Children.Clear();
            foreach (var task in laneViewModel.Lane)
            {
                TodoTaskView tv = new TodoTaskView(new TodoTaskViewModel(task));
                TaskList.Children.Add(tv);
            }
        }

        private void CreateNewTask(object sender, RoutedEventArgs e)
        {
            laneViewModel.AddTask();
            UpdateTasks();
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            LaneEditDialog laneEdit = new LaneEditDialog
            {
                DataContext = laneViewModel
            };
            laneEdit.Show();
        }
    }
}
