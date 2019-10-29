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
using WoLaTa_Task_Manager.View;
using WoLaTa_Task_Manager.ViewModel;

namespace WoLaTa_Task_Manager.View
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            //var workspace = WorkspaceManager.CreateWorkspace("Test Workspacejjj", @"C:\tmp\testworkspace.json");
            WorkspaceWindow workspaceWindow = new WorkspaceWindow(@"C:\tmp\testworkspace.json");
            workspaceWindow.Show();

            this.Close();
        }

        private void LoadBtn_Click(object sender, RoutedEventArgs e)
        {
        //    var workspace = WorkspaceManager.LoadWorkspace(@"C:\tmp\testworkspace.json");
        //    WorkspaceWindow workspaceWindow = new WorkspaceWindow(workspace);
        //    workspaceWindow.Show();
        //    this.Close();
        }

        //private void ChooseFolder_Click(object sender, RoutedEventArgs e)
        //{
        //}
    }
}
