﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WoLaTa_Task_Manager.Model;

namespace WoLaTa_Task_Manager.ViewModel
{
    public class WorkspaceViewModel
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
            WorkspaceManager.SaveWorkspace(Workspace, Path);
        }

        public void AddLane()
        {
            Workspace.Add(new Lane("New Lane"));
        }

        public void MoveTask(TodoTask todoTask, VerticalDirection direction)
        {
            Workspace.MoveTask(todoTask, direction);
        }

        public void MoveTask(TodoTask todoTask, HorizontalDirection direction)
        {
            Workspace.MoveTask(todoTask, direction);
        }

        internal void DeleteTask(TodoTask originalSource)
        {
            foreach (Lane l in Workspace)
                if (l.Contains(originalSource))
                    l.Remove(originalSource);
        }
    }
}
