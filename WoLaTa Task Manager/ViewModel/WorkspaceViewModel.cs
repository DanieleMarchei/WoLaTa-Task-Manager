using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WoLaTa_Task_Manager.Model;

namespace WoLaTa_Task_Manager.ViewModel
{
    public class WorkspaceViewModel//: Workspace
    {
        public Workspace Workspace { get; set; }
        public string Path { get; set; }
        public WorkspaceViewModel(string path)
        {
            this.Workspace = WorkspaceManager.LoadWorkspace(path);
            Path = path;
        }

        public void SaveWorkspace()
        {
            WorkspaceManager.SaveWorkspace(new Workspace(Workspace), Path);
        }
    }
}
