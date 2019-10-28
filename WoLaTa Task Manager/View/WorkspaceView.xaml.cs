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
    /// Interaction logic for WorkspaceView.xaml
    /// </summary>
    public partial class WorkspaceView : UserControl
    {
        public WorkspaceView()
        {
            InitializeComponent();
        }

        private void WorkspaceLabel_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                LanesContainer.Focus();
        }

        private void ContainerGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ContainerGrid.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((WorkspaceViewModel)DataContext).SaveWorkspace();
        }
    }
}
