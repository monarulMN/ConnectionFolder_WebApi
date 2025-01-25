using JobTitle_webapi.Model;
using Microsoft.EntityFrameworkCore;

namespace JobTitle_webapi.Data
{
    public class ApplicationDbContext :DbContext
    
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<JobTitle> JobTitles { get; set; }
    }
}
