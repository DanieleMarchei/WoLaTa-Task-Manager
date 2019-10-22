using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoLaTa_Task_Manager.Model;

namespace WoLaTa_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string savePath = @"C:\Users\Daniele\Desktop\workspace.json";
            Workspace w = WorkspaceManager.CreateWorkspace("workspaceTest", savePath);

            TodoTask t1 = new TodoTask("Task 1");
            t1.Description = "This is a description of the first Task.";

            TodoTask t2 = new TodoTask("Task 2");
            t2.Description = "Yet another task.";
            
            w[0].Label = "First Lane";
            w[0].Add(t1);
            w[0].Add(t2);

            w.Add(new Lane("Second Lane"));
            TodoTask t3 = new TodoTask("Task 3");
            t3.Description = "This task is in another Lane.";

            w[1].Add(t3);
            WorkspaceManager.SaveWorkspace(w, savePath);

            Workspace w_new = WorkspaceManager.LoadWorkspace(savePath);
        }
    }
}
