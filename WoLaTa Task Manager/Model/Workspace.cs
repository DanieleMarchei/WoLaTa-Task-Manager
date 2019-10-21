// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

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
    public class Workspace : IList<Lane>
    {
        public Guid Id { get; private set; }
        public string Label { get; set; }
        public Color Color { get; set; }

        private List<Lane> Lanes = new List<Lane>();

        public Lane this[int index] { get => Lanes[index]; set => Lanes[index] = value; }

        public int Count => Lanes.Count;

        public bool IsReadOnly => false;

        public Workspace(string label)
        {
            Id = Guid.NewGuid();
            Label = label;
            Color = Colors.AntiqueWhite;
            Lanes.Add(new Lane("Lane"));
        }

        public void MoveLane(Lane lane, HorizontalDirection direction)
        {
            int index = IndexOf(lane);
            int newPosition = MyMath.Constrain(0, index, Count) + (int)direction;
            Remove(lane);
            Insert(newPosition, lane);
        }

        public void MoveTask(TodoTask task, VerticalDirection direction)
        {
            Lane lane = null;
            foreach (Lane l in this){
                if (lane.Contains(task))
                {
                    lane = l;
                    break;
                }
            }

            lane.MoveTask(task, direction);
        }

        public void Add(Lane item)
        {
            Lanes.Add(item);
        }

        public void Clear()
        {
            Lanes.Clear();
        }

        public bool Contains(Lane item)
        {
            return Lanes.Contains(item);
        }

        public void CopyTo(Lane[] array, int arrayIndex)
        {
            Lanes.CopyTo(array, arrayIndex);
        }

        public IEnumerator<Lane> GetEnumerator()
        {
            return Lanes.GetEnumerator();
        }

        public int IndexOf(Lane item)
        {
            return Lanes.IndexOf(item);
        }

        public void Insert(int index, Lane item)
        {
            Lanes.Insert(index, item);
        }

        public bool Remove(Lane item)
        {
            return Lanes.Remove(item);
        }

        public void RemoveAt(int index)
        {
            Lanes.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
