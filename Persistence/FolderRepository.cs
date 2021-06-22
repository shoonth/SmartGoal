using Microsoft.EntityFrameworkCore;
using SmartGoalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGoalApp.Persistence
{
    public class FolderRepository : IFolderRepository
    {
        private ModelContext context;
        public FolderRepository(ModelContext context)
        {
            this.context = context;
        }
        public void AddFolder(Folder folder)
        {
            context.Folders.Add(folder);
        }

        public async Task<Folder> GetFolder(int id, bool includeRelated)
        {
            if (includeRelated)
                return await context.Folders
                        .Include(f => f.GoalList)
                        .ThenInclude(g => g.TaskList)
                        .SingleOrDefaultAsync(f => f.Id == id);

            return await context.Folders.FindAsync(id);
        }

        public async Task<IList<Folder>> GetFolders(string userEmail, bool includeRelated)
        {
            if (includeRelated)
                return await context.Folders
                        .Include(f => f.GoalList)
                        .ThenInclude(g => g.TaskList)
                        .Where(f => f.UserEmail == userEmail).ToListAsync();
            return await context.Folders.Where(f => f.UserEmail == userEmail).ToListAsync();
        }

        public void RemoveFolder(Folder folder)
        {
            context.Remove(folder);
        }
    }
}
