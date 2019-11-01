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


        public LaneViewModel(Lane lane)
        {
            this.Lane = lane;
        }

        internal void AddTask()
        {
            Lane.Add(new TodoTask("New Task"));
        }

        public void SortTasksByPriority()
        {
            Lane.OrderBy(t => t.Priority);
        }

        public void SortTasksByTitle()
        {
            Lane.OrderBy(t => t.Title);
        }

        internal void MoveDown(TodoTaskViewModel todoTaskViewModel)
        {
            Lane.MoveTask(todoTaskViewModel.TodoTask, VerticalDirection.DOWN);
        }

        internal void MoveUp(TodoTaskViewModel todoTaskViewModel)
        {
            Lane.MoveTask(todoTaskViewModel.TodoTask, VerticalDirection.UP);
        }
    }
}
