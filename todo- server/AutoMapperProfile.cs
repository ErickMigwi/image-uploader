using todo__server.DTO;

namespace todo__server
{
    public class AutoMapperProfile: Profile

    {
        public AutoMapperProfile()
        {
            CreateMap<TaskModel, AddTaskDto>();
            CreateMap<AddTaskDto, TaskModel>();
            CreateMap<TaskModel, GetTaskDto>();
            CreateMap<ImgSaveFormatModel, AddImagesDto>();
            CreateMap<AddImagesDto, ImgSaveFormatModel>();
            CreateMap<ImgSaveFormatModel, GetImageDto>();
            
        }
    }
}
