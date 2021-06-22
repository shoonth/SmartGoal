using System;

namespace SmartGoalApp.Controllers.Resources
{
    public class TaskResource
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public bool IsFinished { get; set; }
        public float Percentage { get; set; }
        public int GoalId { get; set; }
        public int MeasureMethod { get; set;}
        public int StepCount { get; set; }
        public int ImpactLevel { get; set; }
        public int EffortLevel { get; set; }
        public int ImportanceLevel { get; set; }
        public DateTime DueDateTime { get; set; }
        public string Email { get; set; }
    }
}
