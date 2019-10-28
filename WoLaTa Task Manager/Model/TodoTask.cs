using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WoLaTa_Task_Manager.Model
{
    /// <summary>
    /// Class that represents a Todo Task
    /// </summary>
    [JsonObject(MemberSerialization.Fields)]
    public class TodoTask : INotifyPropertyChanged
    {
        private string _title;
        private string _description;
        private DateTime _date;
        private Color _color;
        private int _priority;

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyRaised("Title");
            }
        }
        public string Description 
        { 
            get => _description; 
            set 
            { 
                _description = value; 
                OnPropertyRaised("Description"); 
            } 
        }
        public DateTime Date 
        { 
            get => _date; 
            set 
            { 
                _date = value; 
                OnPropertyRaised("Date"); 
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
        public int Priority 
        { 
            get => _priority; 
            set 
            { 
                _priority = value; 
                OnPropertyRaised("Priority"); 
            } 
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public TodoTask(string title)
        {
            Title = title;
            Description = "";
            Date = DateTime.Now;
            Color = Colors.LightGray;
            Priority = 0;
        }

        private void OnPropertyRaised(string propertyName)
        {
            if (PropertyChanged == null) return;

            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
