using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoLaTa_Task_Manager.Model;

namespace WoLaTa_Task_Manager.ViewModel
{
    public class WorkspaceViewModel
    {
        public Workspace Workspace { get; set; }
     
        public void LoadWorkspace(string path)
        {
            Workspace = WorkspaceManager.LoadWorkspace(path);
        }

        public void SaveWorkspace(string path)
        {
            WorkspaceManager.SaveWorkspace(Workspace, path);
        }

        public void CreateWorkspace(string label, string path)
        {
            Workspace = WorkspaceManager.CreateWorkspace(label, path);
        }
    }
}
