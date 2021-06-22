using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGoalApp.Models
{
    [Table("Goals")]
    public class Goal
    {
        public Goal()
        {
            TaskList = new List<Task>();
        }
        public int Id { get; set; }
        [Required]
        [StringLength(2000)]
        public string Subject { get; set; }
        public string Description { get; set; }
        private bool _finished;
        [Required]
        public bool IsFinished
        {
            get
            {
                return _finished;
            }
            set
            {
                _finished = value;
            }
        }
        private int _percentage;
        [Required]
        public int Percentage
        {
            get
            {
                return _percentage;
            }
            set
            {
                _percentage = value;
            }
        }
        public ICollection<Task> TaskList { get; set; }

        public int FolderId { get; set; } //Foreign Key
        public Folder folder { get; set; } //reverse association
    }
}
