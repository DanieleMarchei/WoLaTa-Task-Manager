using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WoLaTa_Task_Manager.Extensions;
using WoLaTa_Task_Manager.Utils;


namespace WoLaTa_Task_Manager.Model
{
    /// <summary>
    /// Class that represents a Lane
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class Lane : IList<TodoTask>, INotifyPropertyChanged
    {

        [JsonProperty]
        private string _label;
        
        [JsonProperty]
        private Color _color;
        
        [JsonProperty]
        private List<TodoTask> TodoTasks = new List<TodoTask>();

        public event PropertyChangedEventHandler PropertyChanged;

        public string Label
        {
            get => _label;
            set
            {
                _label = value;
                OnPropertyRaised("Label");
            }
        }
        public Color Color
        {
            get => _color;
            set
            {
                _color = value;
                OnPropertyRaised("Color");
            }
        }

        public int Count => TodoTasks.Count;

        public bool IsReadOnly => false;

        public TodoTask this[int index] 
        { 
            get => TodoTasks[index];
            set
            {
                EditTask(TodoTasks[index], value);
                OnPropertyRaised("TodoTasks");
            }
            
        }

        public Lane(string label)
        {
            Label = label;
            Color = Colors.AliceBlue;
        }
        private void OnPropertyRaised(string propertyName)
        {
            if (PropertyChanged == null) return;

            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Replaces a Todo Task with an edited Todo Task
        /// </summary>
        /// <param name="task">The Todo Task to be replaced</param>
        /// <param name="editedTask">The Todo Task that will replace the old one</param>
        public void EditTask(TodoTask task, TodoTask editedTask)
        {
            int index = IndexOf(task);
            TodoTasks[index] = editedTask;
        }

        /// <summary>
        /// Moves the task up or down the Lane
        /// </summary>
        /// <param name="task">The Todo Task to be moved</param>
        /// <param name="direction">The direction of the movement</param>
        public void MoveTask(TodoTask task, VerticalDirection direction)
        {
            int index = IndexOf(task);
            int newPosition = MathUtilities.Constrain(0, index + (int)direction, Count - 1);
            TodoTasks.Swap(index, newPosition);
        }

        public IEnumerator<TodoTask> GetEnumerator()
        {
            return TodoTasks.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Get the position of the Todo Task in the Lane
        /// </summary>
        /// <param name="item">The Todo Task to get the index of</param>
        /// <returns>The index of the TodoTask</returns>
        public int IndexOf(TodoTask item)
        {
            return TodoTasks.IndexOf(item);
        }

        /// <summary>
        /// Inserts a Todo Task in a specific index
        /// </summary>
        /// <param name="index">The index where the Todo Task will be placed in</param>
        /// <param name="item">The Todo Task to be inserted</param>
        public void Insert(int index, TodoTask item)
        {
            TodoTasks.Insert(index, item);

        }

        /// <summary>
        /// Removes a Todo task in a given position
        /// </summary>
        /// <param name="index">The index to remove the Todo Task at</param>
        public void RemoveAt(int index)
        {
            TodoTasks.RemoveAt(index);
        }

        /// <summary>
        /// Adds a new Todo Task at the end of the Lane
        /// </summary>
        /// <param name="item">The Todo Task to be added</param>
        public void Add(TodoTask item)
        {
            TodoTasks.Add(item);
        }

        /// <summary>
        /// Removes all the Todo Tasks from the Lane
        /// </summary>
        public void Clear()
        {
            TodoTasks.Clear();
        }

        /// <summary>
        /// Determins if a TodoTask is contained in the Lane
        /// </summary>
        /// <param name="item">The Todo Task to be searched</param>
        /// <returns>True or False if the Todo Task is present or not</returns>
        public bool Contains(TodoTask item)
        {
            return TodoTasks.Contains(item);
        }

        /// <summary>
        /// Copies the Lane content in a TodoTask array starting from a given index
        /// </summary>
        /// <param name="array">The TodoTask array</param>
        /// <param name="arrayIndex">The index to start from</param>
        public void CopyTo(TodoTask[] array, int arrayIndex)
        {
            TodoTasks.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Removes a given TodoTask from the Lane, if present
        /// </summary>
        /// <param name="item">The TodoTask to be removed</param>
        /// <returns>True or False if the Todo Task has been removed or not</returns>
        public bool Remove(TodoTask item)
        {
            return TodoTasks.Remove(item);
        }
    }
}
