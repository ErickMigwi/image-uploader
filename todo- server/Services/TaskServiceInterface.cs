using Microsoft.AspNetCore.Mvc;
using todo__server.DTO;

namespace todo__server.Services
{
    public interface TaskServiceInterface
    {
        Task<ServiceResponse<List<GetTaskDto>>> GetTasks();
        Task<ServiceResponse<List<GetTaskDto>>> AddTask(AddTaskDto data);
        Task<Models.ServiceResponse<List<GetImageDto>>> UploadFile([FromForm] ImageModel imageModel);
    }
}
