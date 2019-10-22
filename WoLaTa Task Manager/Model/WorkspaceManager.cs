using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoLaTa_Task_Manager.Model
{
    public static class WorkspaceManager
    {
        public static Workspace LoadWorkspace(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<Workspace>(json);
            }
        }

        public static Workspace CreateWorkspace(string label, string path)
        {
            Workspace w = new Workspace(label);
            SaveWorkspace(w, path);
            return w;
        }

        public static void SaveWorkspace(Workspace w, string path)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                string json = JsonConvert.SerializeObject(w, Formatting.Indented);
                writer.Write(json);
            }
        }
    }
}
