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
using WoLaTa_Task_Manager.ViewModel;
using Xceed.Wpf.Toolkit;

namespace WoLaTa_Task_Manager.View
{
    /// <summary>
    /// Interaction logic for WorkspaceWindow.xaml
    /// </summary>
    public partial class WorkspaceWindow : Window
    {
        private WorkspaceViewModel wvm;
        public WorkspaceWindow(string path)
        {

            InitializeComponent();

            wvm = new WorkspaceViewModel(path);

            for (int i = 0; i < wvm.Workspace.Count; i++)
            {
                LaneView lv = new LaneView(new LaneViewModel(wvm.Workspace[i]));
                LanesContainer.Children.Add(lv);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            wvm.SaveWorkspace();
        }

        private void ContainerGrid_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = wvm;
        }
    }
}
