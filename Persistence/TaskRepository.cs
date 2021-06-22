using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGoalApp.Persistence
{
    public class TaskRepository : ITaskRepository
    {

        private ModelContext context;
        public TaskRepository(ModelContext context)
        {
            this.context = context;
        }

        public async Task<Models.Task> GetTask(int id, bool includeRelated = true)
        {
            return await context.Tasks.FindAsync(id);
        }

        public async Task<IList<Models.Task>> GetTasks(string userEmail, bool includeRelated=true)
        {
            if (includeRelated)
                return await context.Tasks
                        .Where(f => f.Email == userEmail).ToListAsync();
            return await context.Tasks.Where(f => f.Email == userEmail).ToListAsync();
        }

        public void AddTask(Models.Task task)
        {
            context.Tasks.Add(task);
        }

        public void RemoveTask(Models.Task task)
        {
            context.Remove(task);
        }
    }
}
