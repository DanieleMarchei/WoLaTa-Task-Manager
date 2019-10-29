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
    /// Class that represents a Workspace
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class Workspace : IList<Lane>, INotifyPropertyChanged
    {
        [JsonProperty]
        private string _label;

        [JsonProperty]
        private Color _color;
        
        [JsonProperty]
        private List<Lane> Lanes = new List<Lane>();

        public event PropertyChangedEventHandler PropertyChanged;

        public string Label {
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


        public Lane this[int index] 
        { 
            get => Lanes[index]; 
            set { 
                Lanes[index] = value;
                OnPropertyRaised("Lanes");
            } 
        }

        public int Count => Lanes.Count;

        public bool IsReadOnly => false;

        [JsonConstructor]
        public Workspace(string label)
        {
            Label = label;
            Color = Colors.AntiqueWhite;
            Lanes.Add(new Lane("Lane"));
        }

        public Workspace(Workspace w)
        {
            Label = w.Label;
            Color = w.Color;
            Lanes.AddRange(w);
        }

        /// <summary>
        /// Moves a Lane left or right
        /// </summary>
        /// <param name="lane">The Lane to be moved</param>
        /// <param name="direction">The direction of the movement</param>
        public void MoveLane(Lane lane, HorizontalDirection direction)
        {
            int index = IndexOf(lane);
            int newPosition = MathUtilities.Constrain(0, index + (int)direction, Count - 1);
            Lanes.Swap(index, newPosition);
        }

        private void OnPropertyRaised(string propertyName)
        {
            if (propertyName == null || PropertyChanged == null) return;

            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Moves the task up or down the Lane
        /// </summary>
        /// <param name="task">The Todo Task to be moved</param>
        /// <param name="direction">The direction of the movement</param>
        public void MoveTask(TodoTask task, VerticalDirection direction)
        {
            Lane lane = null;
            foreach (Lane l in this){
                if (l.Contains(task))
                {
                    lane = l;
                    break;
                }
            }

            lane.MoveTask(task, direction);
        }

        /// <summary>
        /// Adds a new Lane at the end of the Workspace
        /// </summary>
        /// <param name="item">The Lane to be added</param>
        public void Add(Lane item)
        {
            Lanes.Add(item);
        }

        /// <summary>
        /// Removes all the Lanes from the Workspace
        /// </summary>
        public void Clear()
        {
            Lanes.Clear();
        }

        /// <summary>
        /// Determins if a Lane is contained in the Workspace
        /// </summary>
        /// <param name="item">The lane to be searched</param>
        /// <returns>True or False if the Lane is present or not</returns>
        public bool Contains(Lane item)
        {
            return Lanes.Contains(item);
        }

        /// <summary>
        /// Copies the Workspace content in a Lane array starting from a given index
        /// </summary>
        /// <param name="array">The Lane array</param>
        /// <param name="arrayIndex">The index to start from</param>
        public void CopyTo(Lane[] array, int arrayIndex)
        {
            Lanes.CopyTo(array, arrayIndex);
        }

        public IEnumerator<Lane> GetEnumerator()
        {
            return Lanes.GetEnumerator();
        }

        /// <summary>
        /// Get the position of the Lane in the Workspace
        /// </summary>
        /// <param name="item">The Lane to get the index of</param>
        /// <returns>The index of the Lane</returns>
        public int IndexOf(Lane item)
        {
            return Lanes.IndexOf(item);
        }

        /// <summary>
        /// Inserts a Lane in a specific index
        /// </summary>
        /// <param name="index">The index where the Lane will be placed in</param>
        /// <param name="item">The Lane to be inserted</param>
        public void Insert(int index, Lane item)
        {
            Lanes.Insert(index, item);
        }

        /// <summary>
        /// Removes a given lane from the Workspace, if present
        /// </summary>
        /// <param name="item">The Lane to be removed</param>
        /// <returns>True or False if the Lane has been removed or not</returns>
        public bool Remove(Lane item)
        {
            if (Count == 1)
            {
                Lanes[0] = new Lane("Lane");
                return false;
            }
            return Lanes.Remove(item);
        }

        /// <summary>
        /// Removes a Lane in a given position
        /// </summary>
        /// <param name="index">The index to remove the Lane at</param>
        public void RemoveAt(int index)
        {
            if (Count == 1)
            {
                Lanes[0] = new Lane("Lane");
                return;
            }
            Lanes.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
