using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using GitHubLike.Modules.Common.Entity;
using GitHubLike.Modules.Common.Repository;
using GitHubLike.Modules.OrganizationModule.Entity;
using GitHubLike.Modules.ProjectModule.Entity;
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
        private const string UserOwner = "User";
        private const string OrganizationOwner = "Organization";
        private const string OrganizationOwnerRole = "Owner";
        private const string OrganizationAdminRole = "Admin";
        private const string OrganizationMemberRole = "Member";
        private const int UserRolesCount = 2;
        private const int UserProjectsCount = 4;
        private const int SharedProjectsCount = UserProjectsCount - 2;
        private const int UserOrganizationsCount = 1;
        private const int OrganizationProjectsCount = UserProjectsCount - 3;

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

            #region Adding Owner Types

            var owners = new List<OwnerType>
            {
                new() { Type = UserOwner },
                new() { Type = OrganizationOwner }
            };

            _dbContext.Set<OwnerType>().AddRange(owners);
            _dbContext.SaveChanges();

            var userOwner = owners.FirstOrDefault(u => u.Type == UserOwner);
            var organizationOwner = owners.FirstOrDefault(u => u.Type == OrganizationOwner);

            #endregion

            #region Organization Roles

            var organizationRoles = new List<OrganizationRoles>
            {
                new()
                {
                    OrganizationRoleName = ((OrganizationModule.Types.OrganizationRoles)1).ToString()
                },
                new()
                {
                    OrganizationRoleName = ((OrganizationModule.Types.OrganizationRoles)2).ToString()
                },
                new()
                {
                    OrganizationRoleName = ((OrganizationModule.Types.OrganizationRoles)3).ToString()
                }
            };

            _dbContext.Set<OrganizationRoles>().AddRange(organizationRoles);
            _dbContext.SaveChanges();

            #endregion

            #region Adding Workspaces

            var workspaces = new List<Workspace>
            {
                new() { WorkspaceName = "User 1 Workspace" },
                new() { WorkspaceName = "User 2 Workspace" },
                new() { WorkspaceName = "User 3 Workspace" }
            };

            _dbContext.Set<Workspace>().AddRange(workspaces);
            _dbContext.SaveChanges();

            #endregion

            #region Adding Users

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

            _dbContext.Set<User>().AddRange(users);
            _dbContext.SaveChanges();

            #endregion

            #region Adding User Roles, Projects and Organizations

            var roles = new List<Roles>();
            var projects = new List<Projects>();
            var organizations = new List<Organizations>();

            foreach (var user in users)
            {
                for (int i = 1; i <= UserRolesCount; i++)
                {
                    roles.Add(new()
                    {
                        CreatedBy = user,
                        CreatedByUserId = user.Id,
                        RoleName = "Role " + i,
                        Permissions = i == 1 ? Permissions.Retrieve : Permissions.Retrieve | Permissions.Create
                    });
                }

                for (int i = 1; i <= UserProjectsCount; i++)
                {
                    projects.Add(new()
                    {
                        OwnerId = (int)user.Id,
                        OwnerTypeId = userOwner.OwnerTypeId,
                        OwnerTypes = userOwner,
                        ProjectName = "Project " + i + " of User: " + user.Id
                    });
                }

                for (int i = 1; i <= UserOrganizationsCount; i++)
                {
                    organizations.Add(new()
                    {
                        OrganizationName = "Organization " + i,
                        OwnerUser = user,
                        OwnerUserId = user.Id,
                        Workspace = user.Workspace,
                        WorkspaceId = user.WorkspaceId
                    });
                }
            }

            _dbContext.Set<Roles>().AddRange(roles);
            _dbContext.SaveChanges();

            _dbContext.Set<Projects>().AddRange(projects);
            _dbContext.SaveChanges();

            _dbContext.Set<Organizations>().AddRange(organizations);
            _dbContext.SaveChanges();

            #endregion

            #region Adding Shared Projects

            var sharedProjects = new List<ProjectUsers>();

            foreach (var user in users)
            {
                index = 0;

                var userRole = roles.FindAll(r => r.CreatedByUserId == user.Id);
                var sharedToUsers = users.FindAll(u => u.Id != user.Id);

                var sharedToUser = sharedToUsers[index];
                var projectToShare = projects.FindAll(p => p.OwnerId == user.Id).Take(SharedProjectsCount).ToList();

                sharedProjects.Add(new()
                {
                    Projects = projectToShare[index],
                    ProjectId = projectToShare[index].Id,
                    UserId = sharedToUser.Id,
                    Users = sharedToUser,
                    RoleId = userRole[index].Id,
                    Roles = userRole[index]
                });

                index += 1;

                sharedProjects.Add(new()
                {
                    Projects = projectToShare[index],
                    ProjectId = projectToShare[index].Id,
                    UserId = sharedToUser.Id,
                    Users = sharedToUser,
                    RoleId = userRole[index].Id,
                    Roles = userRole[index]
                });
            }

            foreach (var project in projects)
            {
                var userRole = roles.FindAll(r => r.CreatedByUserId == project.OwnerId);
                var sharedToUsers = users.FindAll(u => u.Id != project.OwnerId);

                var sharedToUser = sharedToUsers[index];

                sharedProjects.Add(new()
                {
                    Projects = project,
                    ProjectId = project.Id,
                    UserId = sharedToUser.Id,
                    Users = sharedToUser,
                    RoleId = userRole[index].Id,
                    Roles = userRole[index]
                });
            }

            _dbContext.Set<ProjectUsers>().AddRange(sharedProjects);
            _dbContext.SaveChanges();

            #endregion

            #region Adding Shared Organizations

            var sharedOrganizations = new List<OrganizationUsers>();
            var organizationProjects = new List<Projects>();

            foreach (var organization in organizations)
            {
                index = 0;

                var sharedToUsers = users.FindAll(u => u.Id != organization.OwnerUserId);

                sharedOrganizations.Add(new()
                {
                    Organization = organization,
                    OrganizationId = organization.Id,
                    User = sharedToUsers[index],
                    UserId = sharedToUsers[index].Id,
                    OrgRoleId = organizationRoles[index + 1].Id,
                    OrganizationRole = organizationRoles[index + 1]
                });

                index += 1;

                sharedOrganizations.Add(new()
                {
                    Organization = organization,
                    OrganizationId = organization.Id,
                    User = sharedToUsers[index],
                    UserId = sharedToUsers[index].Id,
                    OrgRoleId = organizationRoles[index + 1].Id,
                    OrganizationRole = organizationRoles[index + 1]
                });

                for (int i = 1; i <= OrganizationProjectsCount; i++)
                {
                    organizationProjects.Add(new()
                    {
                        OwnerId = (int)organization.Id,
                        OwnerTypeId = organizationOwner.OwnerTypeId,
                        OwnerTypes = organizationOwner,
                        ProjectName = "Organization " + organization.Id + " Project " + i
                    });
                }
            }

            _dbContext.Set<OrganizationUsers>().AddRange(sharedOrganizations);
            _dbContext.SaveChanges();

            _dbContext.Set<Projects>().AddRange(organizationProjects);
            _dbContext.SaveChanges();

            #endregion
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
