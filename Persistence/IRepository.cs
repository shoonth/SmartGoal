using SmartGoalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGoalApp.Persistence
{
    public interface IGoalRepository
    {
        Task<Goal> GetGoal(int id, bool includeRelated = true);
        void AddGoal(Goal goal);
        void RemoveGoal(Goal goal);
    }

    public interface IFolderRepository
    {
        Task<Folder> GetFolder(int id, bool includeRelated = true);
        Task<IList<Folder>> GetFolders(string userEmail, bool includeRelated = true);
        void AddFolder(Folder goal);
        void RemoveFolder(Folder goal);
    }

    public interface ITaskRepository
    {
        Task<Models.Task> GetTask(int id, bool includeRelated = true);
        Task<IList<Models.Task>> GetTasks(string userEmail, bool includeRelated = true);
        void AddTask(Models.Task goal);
        void RemoveTask(Models.Task goal);
    }
}
