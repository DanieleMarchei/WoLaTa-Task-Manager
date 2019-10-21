using System;
using WoLaTa_Task_Manager.Model;

namespace WoLaTa_Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("test");
            WorkspaceManager.CreateWorkspace("workspaceTest", @"C:\Users\Daniele\Desktop\workspace.json");
        }
    }
}
