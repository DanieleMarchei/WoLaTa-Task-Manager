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
using WoLaTa_Task_Manager.ViewModel;

namespace WoLaTa_Task_Manager.View
{
    /// <summary>
    /// Interaction logic for TodoTaskView.xaml
    /// </summary>
    public partial class TodoTaskView : UserControl
    {
        #region Properties
        public TodoTaskViewModel TodoTaskViewModel { get; set; }
        #endregion Properties

        public TodoTaskView(TodoTaskViewModel todoTaskViewModel)
        {
            InitializeComponent();
            TodoTaskViewModel = todoTaskViewModel;
            DataContext = TodoTaskViewModel;
        }

        #region Events
        // Declare events
        public static readonly RoutedEvent MoveRightEvent = EventManager.RegisterRoutedEvent(
            "MoveRight", // Event name 
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), // The event type
            typeof(TodoTaskView)); // Event owner

        public static readonly RoutedEvent MoveLeftEvent = EventManager.RegisterRoutedEvent(
            "MoveLeft", // Event name 
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), // The event type
            typeof(TodoTaskView)); // Event owner

        public static readonly RoutedEvent MoveUpEvent = EventManager.RegisterRoutedEvent(
            "MoveUp", // Event name 
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), // The event type
            typeof(TodoTaskView)); // Event owner

        public static readonly RoutedEvent MoveDownEvent = EventManager.RegisterRoutedEvent(
            "MoveDown", // Event name 
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), // The event type
            typeof(TodoTaskView)); // Event owner

        // Expose our events
        public event RoutedEventHandler MoveRight
        {
            add { AddHandler(MoveRightEvent, value); }
            remove { RemoveHandler(MoveRightEvent, value); }
        }

        public event RoutedEventHandler MoveLeft
        {
            add { AddHandler(MoveLeftEvent, value); }
            remove { RemoveHandler(MoveLeftEvent, value); }
        }

        public event RoutedEventHandler MoveUp
        {
            add { AddHandler(MoveUpEvent, value); }
            remove { RemoveHandler(MoveUpEvent, value); }
        }

        public event RoutedEventHandler MoveDown
        {
            add { AddHandler(MoveDownEvent, value); }
            remove { RemoveHandler(MoveDownEvent, value); }
        }
        #endregion Events

        #region Private UI event handlers
        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TodoTaskEditDialog editTask = new TodoTaskEditDialog();
            editTask.DataContext = TodoTaskViewModel;
            editTask.ShowDialog();
        }

        private void MoveRightBtn_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(MoveRightEvent, TodoTaskViewModel.TodoTask));
        }

        private void MoveLeftBtn_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(MoveLeftEvent, TodoTaskViewModel.TodoTask));
        }

        private void MoveUpBtn_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(MoveUpEvent, TodoTaskViewModel.TodoTask));
        }

        private void MoveDownBtn_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(MoveDownEvent, TodoTaskViewModel.TodoTask));
        }
        #endregion Private UI event handlers
    }
}
