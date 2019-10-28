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
        /// <summary>
        /// Loads a Workspace from file
        /// </summary>
        /// <param name="path">The path of the Workspace file</param>
        /// <returns>The Workspace loaded</returns>
        public static Workspace LoadWorkspace(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadToEnd();
                Workspace w = JsonConvert.DeserializeObject<Workspace>(json);
                return w;
            }
        }

        /// <summary>
        /// Creates a new Workspace and saves it into a file
        /// </summary>
        /// <param name="label">The label of the Workspace</param>
        /// <param name="path">The path where the Workspace will be saved</param>
        /// <returns>The Workspace created</returns>
        public static Workspace CreateWorkspace(string label, string path)
        {
            Workspace w = new Workspace(label);
            SaveWorkspace(w, path);
            return w;
        }

        /// <summary>
        /// Saves a Workspace into a file
        /// </summary>
        /// <param name="w">The Workspace to be saved</param>
        /// <param name="path">The path where the Workspace will be saved</param>
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
