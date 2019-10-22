// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WoLaTa_Task_Manager.Extensions;

namespace WoLaTa_Task_Manager.Model
{
    [JsonObject(MemberSerialization.Fields)]
    public class Lane : IList<TodoTask>
    {
        public string Label;
        public Color Color = Colors.AliceBlue;

        private List<TodoTask> TodoTasks = new List<TodoTask>();
        public int Count => TodoTasks.Count;

        public bool IsReadOnly => false;

        public TodoTask this[int index] { get => TodoTasks[index]; set => EditTask(TodoTasks[index]); }

        public Lane(string label)
        {
            Label = label;
        }

        public void EditTask(TodoTask task)
        {
            throw new NotImplementedException();
        }

        public void MoveTask(TodoTask task, VerticalDirection direction)
        {
            int index = IndexOf(task);
            int newPosition = MyMath.Constrain(0, index, Count) + (int)direction;
            Remove(task);
            Insert(newPosition, task);
        }

        public IEnumerator<TodoTask> GetEnumerator()
        {
            return TodoTasks.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        public int IndexOf(TodoTask item)
        {
            return TodoTasks.IndexOf(item);
        }

        public void Insert(int index, TodoTask item)
        {
            TodoTasks.Insert(index, item);

        }

        public void RemoveAt(int index)
        {
            TodoTasks.RemoveAt(index);
        }

        public void Add(TodoTask item)
        {
            TodoTasks.Add(item);
        }

        public void Clear()
        {
            TodoTasks.Clear();
        }

        public bool Contains(TodoTask item)
        {
            return TodoTasks.Contains(item);
        }

        public void CopyTo(TodoTask[] array, int arrayIndex)
        {
            TodoTasks.CopyTo(array, arrayIndex);
        }

        public bool Remove(TodoTask item)
        {
            return TodoTasks.Remove(item);
        }
    }
}
