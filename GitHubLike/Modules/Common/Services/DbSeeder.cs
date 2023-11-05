using System.Diagnostics;
using GitHubLike.Modules.Common.Entity;
using GitHubLike.Modules.Common.Repository;
using GitHubLike.Modules.WorkspaceModule.Entity;
using Microsoft.EntityFrameworkCore;

namespace GitHubLike.Modules.Common.Services
{
    public class DbSeeder
    {
        private readonly ApplicationDbContext _dbContext;

        public DbSeeder()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            
            _dbContext = new ApplicationDbContext(optionsBuilder.Options);
        }

        public void SeedData()
        {
            _dbContext.Set<Workspace>().Add(new Workspace { WorkspaceName = "Test" });
            _dbContext.SaveChanges();
        }
    }
}
