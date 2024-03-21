namespace todo__server.Models
{
    public class TaskModel
    {
        public int Id { get; set; } = 1;
        public string Task { get; set; } = string.Empty;
        public bool IsCompleted { get; set; } = false;
        public string completionDate { get; set; } = string.Empty;
        public string dateCreated { get; set; } = string.Empty;
    }
}
