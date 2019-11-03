using Microsoft.Win32;
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
            CreateWorkspaceFile open = new CreateWorkspaceFile();
            if (open.ShowDialog() == true)
            {
                string label = open.Label;
                string path = open.Path;
                try
                {
                    WorkspaceManager.CreateWorkspace(label, path);

                }
                catch (Exception)
                {
                    MessageBox.Show($"Permission denied for path '{open.Path}'", "Permission Denied", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                WorkspaceWindow workspaceWindow = new WorkspaceWindow(open.Path);
                workspaceWindow.Show();

                this.Close();
            }
        }

        private void LoadBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter += ".json | *.json";
            if (open.ShowDialog() == true)
            {
                WorkspaceWindow workspaceWindow = new WorkspaceWindow(open.FileName);
                workspaceWindow.Show();

                this.Close();
            }
        }
    }
}
