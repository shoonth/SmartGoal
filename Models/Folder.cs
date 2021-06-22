using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGoalApp.Models
{
    [Table("Folders")]
    public class Folder
    {
        public Folder()
        {
            GoalList = new List<Goal>();
        }
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string UserEmail { get; set; }

        public ICollection<Goal> GoalList { get; set; }
    }
}
