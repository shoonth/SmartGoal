using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGoalApp.Controllers.Resources
{
    public class GoalResource
    {
        public GoalResource()
        {
            TaskList = new List<TaskResource>();
        }
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public bool IsFinished { get; set; }
        public int Percentage { get; set; }
        public ICollection<TaskResource> TaskList { get; set; }

        public int FolderId { get; set; } //Foreign Key
    }
}
