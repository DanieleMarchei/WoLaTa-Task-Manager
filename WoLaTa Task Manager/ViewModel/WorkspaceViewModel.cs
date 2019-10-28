using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WoLaTa_Task_Manager.Model;

namespace WoLaTa_Task_Manager.ViewModel
{
    public class WorkspaceViewModel : Workspace
    {
        public string Path { get; set; }
        public SolidColorBrush Background { get; set; }
        public WorkspaceViewModel(string path) : base(WorkspaceManager.LoadWorkspace(path))
        {
            Path = path;
            Background = new SolidColorBrush(Color);
        }

        public void SaveWorkspace()
        {
            WorkspaceManager.SaveWorkspace(new Workspace(this), Path);
        }
    }
}
