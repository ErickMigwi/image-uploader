global using todo__server.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace todo__server.Services
{

   
    public class TaskService : TaskServiceInterface
       
    {
       


        private readonly DataContext _context;
        private readonly IMapper _mapper;
      
        public TaskService(IMapper mapper, DataContext context )
        {
            _mapper = mapper;
            _context = context;
          
        }

        public async Task<ServiceResponse<List<GetTaskDto>>> AddTask(AddTaskDto data)
        {
            var serviceResponse = new ServiceResponse<List<GetTaskDto>>();
            try
            {
                var task = _mapper.Map<TaskModel>(data);


                await _context.Tasks.AddAsync(task);
                await _context.SaveChangesAsync();

                // Retrieve tasks after saving changes
                var tasks = await _context.Tasks.ToListAsync();
                serviceResponse.Data = tasks.Select(s => _mapper.Map<GetTaskDto>(s)).ToList();
                serviceResponse.Success = true; // Set success to true

                return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message; // Always use outer exception message
                 
                return serviceResponse;
            }
        }


        public async Task<ServiceResponse<List<GetTaskDto>>> GetTasks()
        {
            var serviceResponse = new ServiceResponse<List<GetTaskDto>>();
            try
            {
                var tasks = await _context.Tasks.ToListAsync();
                serviceResponse.Data = tasks.Select(s=>_mapper.Map<GetTaskDto>(s)).ToList();
                return serviceResponse;
            }catch (Exception ex)
            {
                serviceResponse.Message = "An erro ouccured fetching the tasks";
                serviceResponse.Success = false;
                return serviceResponse;
            }
        }
        public async Task<Models.ServiceResponse<List<GetImageDto>>> UploadFile([FromForm] ImageModel imageModel)
        {
            
            var serviceResponse = new ServiceResponse<List<GetImageDto>>();

            try
            {
                var file = imageModel.formFile; 

                if (file != null && file.Length > 0)
                {
                   
                    string directory = Path.Combine(Directory.GetCurrentDirectory(), "profileimages");
                    if (!Directory.Exists(directory))
                        Directory.CreateDirectory(directory);

                    
                    string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string filePath = Path.Combine(directory, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }


                    var imageClass = new ImgSaveFormatModel();
                    
                    imageClass.ImageName = uniqueFileName;
                    Console.WriteLine(imageClass);
                   
                    
                    await _context.Images.AddAsync(imageClass);
                   
                    await _context.SaveChangesAsync();
                   
                    var imgStrings =  await _context.Images.ToListAsync();

                   var data =  imgStrings.Select(i => _mapper.Map<GetImageDto>(i)).ToList();
                    serviceResponse.Message = "Image uploaded successfully";
                    serviceResponse.Data = data;
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "No file uploaded.";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = $"Internal server error: {ex}";
                 Console.WriteLine(ex);
            }

            return serviceResponse;

        }
    }
}
