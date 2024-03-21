namespace todo__server.DTO
{
    public class GetTaskDto
    {
      
        public string Task { get; set; } = string.Empty;

        public bool IsCompleted { get; set; } = false;
        public string CompletionDate { get; set; } = string.Empty;

        
    }
}
