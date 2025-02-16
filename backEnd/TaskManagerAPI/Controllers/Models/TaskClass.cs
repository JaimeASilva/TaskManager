namespace TaskManagerAPI.Controllers.Models {
    public class TaskClass {
        public long Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool? IsComplete { get; set; }
    }
}
