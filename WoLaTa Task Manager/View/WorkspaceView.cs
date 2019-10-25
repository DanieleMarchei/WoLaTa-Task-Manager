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
using WoLaTa_Task_Manager.ViewModel;


namespace WoLaTa_Task_Manager.View
{
    /// <summary>
    /// Interaction logic for WorkspaceWindow.xaml
    /// </summary>
    public partial class WorkspaceView : Window
    {
        private String path;
        private WorkspaceViewModel workspaceViewModel;

        public WorkspaceView(String path)
        {
            this.path = path;
            workspaceViewModel = new WorkspaceViewModel();
            workspaceViewModel.LoadWorkspace(path);

            InitializeComponent();
        }

        private void DockPanel_Loaded(object sender, RoutedEventArgs e)
        {
            this.Workspace.DataContext = workspaceViewModel;
        }
    }
}
