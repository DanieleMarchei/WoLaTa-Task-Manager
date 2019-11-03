using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoLaTa_Task_Manager.Model;

namespace WoLaTa_Task_Manager.ViewModel
{
    public class TodoTaskViewModel
    {
        public TodoTask TodoTask { get; set; }

        public TodoTaskViewModel(TodoTask task)
        {
            TodoTask = task;
        }
    }
}
