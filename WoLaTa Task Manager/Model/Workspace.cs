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
    public class Workspace : IList<Lane>
    {

        public string Label = "";
        public Color Color = Colors.AntiqueWhite;
        private List<Lane> Lanes = new List<Lane>();

        public Lane this[int index] { get => Lanes[index]; set => Lanes[index] = value; }

        public int Count => Lanes.Count;

        public bool IsReadOnly => false;

        public Workspace(string label)
        {
            Label = label;
            Lanes.Add(new Lane("Lane"));
        }

        public void MoveLane(Lane lane, HorizontalDirection direction)
        {
            int index = IndexOf(lane);
            int newPosition = MyMath.Constrain(0, index + (int)direction, Count);
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
