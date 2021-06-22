using SmartGoalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGoalApp.Controllers.Resources
{
    public class FolderResource
    {
        public FolderResource()
        {
            GoalList = new List<GoalResource>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public IList<GoalResource> GoalList { get; set; }
    }
}
