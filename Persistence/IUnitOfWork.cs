using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGoalApp.Persistence
{
    public interface IUnitOfWork
    {
        Task Complete();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private ModelContext _context;

        public UnitOfWork(ModelContext context)
        {
            this._context = context;
        }
        public async Task Complete()
        {
            await _context.SaveChangesAsync();
        }
    }
}
