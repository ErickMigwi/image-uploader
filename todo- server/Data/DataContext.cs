using Microsoft.EntityFrameworkCore;

namespace todo__server.Data
{
   
    
        public class DataContext : DbContext
        {
            public DataContext(DbContextOptions<DataContext> options) : base(options)
            {

            }
            public DbSet<TaskModel> Tasks => Set<TaskModel>();
            public DbSet<ImgSaveFormatModel> Images => Set<ImgSaveFormatModel>();
    }
    
}
