using System.Diagnostics;
using System.Text;
using GitHubLike.Modules.Common.Entity;
using GitHubLike.Modules.Common.Repository;
using GitHubLike.Modules.RoleModule.Entity;
using GitHubLike.Modules.RoleModule.Types;
using GitHubLike.Modules.UserModule.Entity;
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
            int index = 1;

            var workspaces = new List<Workspace>
            {
                new() { WorkspaceName = "User 1 Workspace" },
                new() { WorkspaceName = "User 2 Workspace" },
                new() { WorkspaceName = "User 3 Workspace" }
            };

            _dbContext.Set<Workspace>().AddRange(workspaces);
            _dbContext.SaveChanges();

            var users = new List<User>();

            foreach (var workspace in workspaces)
            {
                users.Add(new()
                {
                    Email = "user" + index + "@google.com",
                    UserName = "User " + index,
                    UserPassword = ComputeHash("User@" + index),
                    Workspace = workspace,
                    WorkspaceId = workspace.Id
                });

                index += 1;
            }

            index = 1;

            _dbContext.Set<User>().AddRange(users);
            _dbContext.SaveChanges();

            var roles = new List<Roles>();

            #region Adding User Roles

            long[] userIds = users.Select(x => x.Id).ToArray();

            roles.Add(new()
            {
                CreatedBy = users.FirstOrDefault(u => u.Id == userIds[0]),
                CreatedByUserId = users.FirstOrDefault(u => u.Id == userIds[0]).Id,
                RoleName = "Role 01",
                Permissions = Permissions.Retrieve
            });

            roles.Add(new()
            {
                CreatedBy = users.FirstOrDefault(u => u.Id == userIds[0]),
                CreatedByUserId = users.FirstOrDefault(u => u.Id == userIds[0]).Id,
                RoleName = "Role 02",
                Permissions = Permissions.Retrieve | Permissions.Create
            });

            roles.Add(new()
            {
                CreatedBy = users.FirstOrDefault(u => u.Id == userIds[1]),
                CreatedByUserId = users.FirstOrDefault(u => u.Id == userIds[1]).Id,
                RoleName = "Role 01",
                Permissions = Permissions.Retrieve
            });

            roles.Add(new()
            {
                CreatedBy = users.FirstOrDefault(u => u.Id == userIds[1]),
                CreatedByUserId = users.FirstOrDefault(u => u.Id == userIds[1]).Id,
                RoleName = "Role 02",
                Permissions = Permissions.Retrieve | Permissions.Create
            });

            roles.Add(new()
            {
                CreatedBy = users.FirstOrDefault(u => u.Id == userIds[2]),
                CreatedByUserId = users.FirstOrDefault(u => u.Id == userIds[2]).Id,
                RoleName = "Role 01",
                Permissions = Permissions.Retrieve
            });

            roles.Add(new()
            {
                CreatedBy = users.FirstOrDefault(u => u.Id == userIds[2]),
                CreatedByUserId = users.FirstOrDefault(u => u.Id == userIds[2]).Id,
                RoleName = "Role 02",
                Permissions = Permissions.Retrieve | Permissions.Create
            });

            #endregion

            _dbContext.Set<Roles>().AddRange(roles);
            _dbContext.SaveChanges();
        }

        private string ComputeHash(string input)
        {
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                var data = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder();
                foreach (var c in data)
                {
                    sb.Append(c.ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}
