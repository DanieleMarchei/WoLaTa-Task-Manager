using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoLaTa_Task_Manager.Model;


namespace WoLaTa_Task_Manager.ViewModel
{
    public class LaneViewModel
    {
        public Lane Lane { get; set; }
        //public IList<TodoTask> TodoTasks { get; set; }
        //public string Label { get; set; }
        //public int Count { get; set; }

        public LaneViewModel(Lane lane)
        {
            this.Lane = lane;
        }

        internal void AddTask()
        {
            Lane.Add(new TodoTask("New Task"));
        }
    }
}
