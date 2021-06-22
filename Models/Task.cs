using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SmartGoalApp.Models
{
    public enum MeasureMethods { Progress, Step, Onetime }

    [Table("Tasks")]
    public class Task
    {
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
        private float _percentage;
        [Required]
        public float Percentage
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
        [Required]
        public int GoalId { get; set; } //Foreign Key
        public Goal Goal { get; set; } //reverse association
        [Required]
        public MeasureMethods MeasureMethod { get; set; }
        public int StepCount { get; set; }
        public int ImpactLevel {get; set;}
        public int EffortLevel { get; set; }
        public int ImportanceLevel { get; set; }
        public DateTime DueDateTime { get; set; }
        [Required]
        [StringLength(255)]
        public string Email { get; set; }
    }
}
