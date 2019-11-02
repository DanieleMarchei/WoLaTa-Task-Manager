using System;
using System.Collections.Generic;
using System.Drawing;
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
using WoLaTa_Task_Manager.Model;
using WoLaTa_Task_Manager.ViewModel;
using Xceed.Wpf.Toolkit;

namespace WoLaTa_Task_Manager.View
{
    /// <summary>
    /// Interaction logic for WorkspaceWindow.xaml
    /// </summary>
    public partial class WorkspaceWindow : Window
    {
        private readonly WorkspaceViewModel wvm;

        public WorkspaceWindow(string path)
        {
            InitializeComponent();
            wvm = new WorkspaceViewModel(path);
            DataContext = wvm;
            UpdateLanes();
        }

        private void UpdateLanes()
        {
            LanesContainer.Children.Clear();
            foreach (var lane in wvm.Workspace)
            {
                LaneView lv = new LaneView(lane);
                LanesContainer.Children.Add(lv);
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            wvm.SaveWorkspace();
        }

        private void NewLaneButton_Click(object sender, RoutedEventArgs e)
        {
            wvm.AddLane();
            LaneView lv = new LaneView(wvm.Workspace.Last());
            LanesContainer.Children.Add(lv);
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void HandleMoveRightEvent(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            wvm.MoveTask((TodoTask)e.OriginalSource, HorizontalDirection.RIGHT);
            UpdateLanes();
        }

        private void HandleMoveLeftEvent(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            wvm.MoveTask((TodoTask)e.OriginalSource, HorizontalDirection.LEFT);
            UpdateLanes();
        }

        private void HandleMoveUpEvent(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            wvm.MoveTask((TodoTask)e.OriginalSource, VerticalDirection.UP);
            UpdateLanes();
        }

        private void HandleMoveDownEvent(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            wvm.MoveTask((TodoTask)e.OriginalSource, VerticalDirection.DOWN);
            UpdateLanes();
        }
    }
}
