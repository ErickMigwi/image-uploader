using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;
using todo__server.DTO;
using todo__server.Models;
using todo__server.Services;

namespace todo__server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly TaskServiceInterface _taskServiceInterface;
      
        public TaskController(TaskServiceInterface taskServiceInterface, IWebHostEnvironment webHostEnvironment)
        {
            _taskServiceInterface = taskServiceInterface;
           
        }
        [HttpPost("/addtask")]
        public async Task<ActionResult<ServiceResponse<List<GetTaskDto>>>> Post(AddTaskDto data)
        {
            
           
                return await _taskServiceInterface.AddTask(data);
         
        }

        [HttpPost("uploadimage")]
       public async Task<ActionResult<Models.ServiceResponse<List<GetImageDto>>>> UploadFile([FromForm] ImageModel imageModel)
        {
            return await _taskServiceInterface.UploadFile(imageModel);
        }

    }


}
