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
using WoLaTa_Task_Manager.Model;

namespace WoLaTa_Task_Manager.Windows
{
    /// <summary>
    /// Interaction logic for WorkspaceWindow.xaml
    /// </summary>
    public partial class WorkspaceWindow : Window
    {
        public Workspace Workspace { get; private set; }
        public WorkspaceWindow(Workspace workspace)
        {
            InitializeComponent();

            this.Workspace = workspace;
        }


    }
}
