using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
    public class TodoTask
    {
        public string Title;
        public string Description = "";
        public DateTime Date = DateTime.Now;
        public Color Color = Colors.LightGray;
        public int Priority = 0;

        public TodoTask(string title)
        {
            Title = title;
        }
    }
}
