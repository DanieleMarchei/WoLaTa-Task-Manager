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
        public TodoTaskView(TodoTaskViewModel todoTaskViewModel)
        {
            InitializeComponent();
            TodoTaskViewModel = todoTaskViewModel;
            DataContext = TodoTaskViewModel;
        }
    }
}
