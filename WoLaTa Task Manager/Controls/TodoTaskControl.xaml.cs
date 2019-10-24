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

namespace WoLaTa_Task_Manager.Controls
{
    /// <summary>
    /// Interaction logic for TodoTaskControl.xaml
    /// </summary>
    public partial class TodoTaskControl : UserControl
    {
        public TodoTask TodoTask { get; private set; }

        public TodoTaskControl(TodoTask todoTask)
        {
            InitializeComponent();
            this.TodoTask = todoTask;
        }
    }
}
