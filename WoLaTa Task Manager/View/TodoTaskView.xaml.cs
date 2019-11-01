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
    /// Interaction logic for TodoTaskView.xaml
    /// </summary>
    public partial class TodoTaskView : UserControl
    {
        public TodoTaskViewModel TodoTaskViewModel { get; set; }
        private LaneViewModel LaneViewModel;

        public TodoTaskView(TodoTaskViewModel todoTaskViewModel, LaneViewModel laneViewModel)
        {
            InitializeComponent();
            TodoTaskViewModel = todoTaskViewModel;
            DataContext = TodoTaskViewModel;
            LaneViewModel = laneViewModel;
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TodoTaskEditDialog editTask = new TodoTaskEditDialog();
            editTask.DataContext = TodoTaskViewModel;
            editTask.ShowDialog();
        }

        private void MoveDownBtn_Click(object sender, RoutedEventArgs e)
        {
            LaneViewModel.MoveDown(TodoTaskViewModel);

        }
    }
}
