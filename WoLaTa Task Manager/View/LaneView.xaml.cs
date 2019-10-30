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

        private LaneViewModel LaneViewModel;

        public LaneView(LaneViewModel lvm)
        {
            LaneViewModel = lvm;
            InitializeComponent();
            
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = LaneViewModel;
        }

        private void CreateNewTask(object sender, RoutedEventArgs e)
        {
            LaneViewModel.Lane.Add(new TodoTask("New Task"));
            
            DockPanel NewTask = new DockPanel();

            Button DownButton = new Button();
            DownButton.Content = "v";
            Button UpButton = new Button();
            UpButton.Content = "^";
            Button LeftButton = new Button();
            LeftButton.Content = "<";
            Button RightButton = new Button();
            RightButton.Content = ">";
            TextBox TaskText = new TextBox();
            TaskText.Text = "Test";

            NewTask.Children.Add(DownButton);
            NewTask.Children.Add(UpButton);
            NewTask.Children.Add(LeftButton);
            NewTask.Children.Add(RightButton);
            NewTask.Children.Add(TaskText);

            DockPanel.SetDock(DownButton, Dock.Bottom);
            DockPanel.SetDock(UpButton, Dock.Top);
            DockPanel.SetDock(LeftButton, Dock.Left);
            DockPanel.SetDock(RightButton, Dock.Right);

            NextTask.Children.Add(NewTask);
        }
    }
}
