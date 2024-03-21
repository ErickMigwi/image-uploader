namespace todo__server.Models
{
    public class ImageModel
    {
        public int Id { get; set; } = 1;
        public required IFormFile formFile { get; set; }
    }
}
