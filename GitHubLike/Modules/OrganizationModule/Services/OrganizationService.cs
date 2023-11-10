using GitHubLike.Modules.Common.Repository;
using GitHubLike.Modules.OrganizationModule.Entity;
using GitHubLike.Modules.OrganizationModule.Models;
using GitHubLike.Modules.OrganizationModule.Repository;
using GitHubLike.Modules.ProjectModule.Entity;
using GitHubLike.Modules.ProjectModule.Models;
using GitHubLike.Modules.UserModule.Entity;
using Microsoft.EntityFrameworkCore;

namespace GitHubLike.Modules.OrganizationModule.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IRepository<Organizations> _organizationRepository;
        private readonly IRepository<OrganizationUsers> _organizationUsersRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Projects> _projectRepository;
        private readonly IRepository<ProjectUsers> _projectUserRepository;

        public OrganizationService(IRepository<Organizations> organizationRepository, 
            IRepository<OrganizationUsers> organizationUsersRepository, 
            IRepository<User> userRepository, 
            IRepository<Projects> projectRepository, 
            IRepository<ProjectUsers> projectUserRepository)
        {
            _organizationRepository = organizationRepository;
            _organizationUsersRepository = organizationUsersRepository;
            _userRepository = userRepository;
            _projectRepository = projectRepository;
            _projectUserRepository = projectUserRepository;
        }

        public async Task<Organizations> GetOrganization(long organizationId)
        {
            return await _organizationRepository.Query()
                .FirstOrDefaultAsync(p => p.Id == organizationId);
        }

        public async Task<OrganizationDetailViewDto> GetOrganizationDetail(long organizationId, long userId)
        {
            var organizationDetails = new OrganizationDetailViewDto();

            var organization = await _organizationRepository.Query().FirstOrDefaultAsync(o => o.Id == organizationId);
            organizationDetails.CreatedOn = DateOnly.FromDateTime(organization.CreatedAt.DateTime);
            organizationDetails.OrganizationName = organization.OrganizationName;
            organizationDetails.IsOwner = organization.OwnerUserId == userId;
            organizationDetails.IsAdmin = await _organizationUsersRepository.Query()
                .Include(o => o.OrganizationRole)
                .AnyAsync(o =>
                o.OrganizationId == organizationId
                && o.UserId == userId
                && o.OrganizationRole.OrganizationRoleName == ((Types.OrganizationRoles)1).ToString());

            var organizationUsers = _organizationUsersRepository.Query().Where(o => o.OrganizationId == organizationId)
                .Include(o => o.User)
                .Include(p => p.OrganizationRole)
                .Select
                (s => new OrganizationUserDetailViewDto
                {
                    UserId = s.UserId,
                    UserName = s.User.UserName,
                    UserRole = s.OrganizationRole.OrganizationRoleName
                });

            organizationDetails.OrganizationUsersList = organizationUsers.OrderBy(x => x.UserId).ToList();

            return organizationDetails;
        }

        public async Task<List<OrganizationUserInvitationsViewDto>> GetOrganizationUserInvitations(long userId)
        {
            var sharedOrganizations = _organizationRepository.Query()
                .Join(_organizationUsersRepository.Query().Where(p => p.UserId == userId && p.AcceptedInvite != false),
                    organizations => organizations.Id,
                    organizationUsers => organizationUsers.OrganizationId,
                    (organizations, organizationUsers) => new { organizations, organizationUsers })
                .Join(_userRepository.Query(),
                    combined => combined.organizations.OwnerUserId, user => user.Id,
                    (combined, user) => new OrganizationUserInvitationsViewDto
                    {
                        InviteAccepted = combined.organizationUsers.AcceptedInvite,
                        Organization = new OrganizationViewDto
                        {
                            OrganizationId = combined.organizations.Id,
                            OrganizationName = combined.organizations.OrganizationName,
                            CreatedAt = DateOnly.FromDateTime(combined.organizations.CreatedAt.DateTime)
                        },
                        UserName = user.UserName
                    }).AsNoTracking().ToList();


            var myOrganization = _organizationRepository.Query().FirstOrDefault(o => o.OwnerUserId == userId);
            sharedOrganizations.Add(new OrganizationUserInvitationsViewDto
            {
                InviteAccepted = true,
                Organization = new()
                {
                    OrganizationName = myOrganization.OrganizationName,
                    CreatedAt = DateOnly.FromDateTime(myOrganization.CreatedAt.DateTime),
                    OrganizationId = myOrganization.Id
                },
                UserName = "You"
            });

            return sharedOrganizations;
        }

        public async Task<List<OrganizationProjectsViewDto>> GetOrganizationProjects(long organizationId, long userId)
        {
            var organization = await _organizationRepository.Query().FirstOrDefaultAsync(o => o.Id == organizationId);
            var organizationProjectDetails = new List<OrganizationProjectsViewDto>();
            var organizationUser = await _organizationUsersRepository.Query()
                .FirstOrDefaultAsync(o => o.OrganizationId == organizationId && o.UserId == userId);

            if (organizationUser == null && organization.OwnerUserId != userId)
            {
                return null;
            }

            if (organization.OwnerUserId == userId || (organizationUser != null && organizationUser.OrgRoleId == 2)) // Owner or Admin
            {
                var organizationProjects = _projectRepository.Query()
                    .Where(p => p.OwnerTypeId == 2 && p.OwnerId == organizationId).AsNoTracking();

                foreach (var organizationProject in organizationProjects)
                {

                    organizationProjectDetails.Add(new()
                    {
                        CreatedBy = _userRepository.Query().FirstOrDefault(u => u.Id == organizationProject.CreatedByUserId).UserName,
                        CreatedOn = DateOnly.FromDateTime(organizationProject.CreatedAt.DateTime),
                        ProjectId = organizationProject.Id,
                        ProjectName = organizationProject.ProjectName,
                        OrganizationProjectUsers = await GetUserProjects(organizationProject.Id)
                    });
                }
            }

            else // Member
            {
                var organizationProjects = _projectRepository.Query()
                    .Where(p => p.OwnerTypeId == 2 && p.OwnerId == organizationId)
                    .AsNoTracking()
                    .Join(_projectUserRepository.Query().Where(p => p.UserId == userId),
                        projects => projects.Id,
                        projectUsers => projectUsers.ProjectId,
                        (projects, projectUsers) => new {
                            projects, projectUsers
                        });

                foreach (var organizationProject in organizationProjects)
                {
                    organizationProjectDetails.Add(new()
                    {
                        CreatedBy = _userRepository.Query().FirstOrDefault(u => u.Id == organizationProject.projects.CreatedByUserId).UserName,
                        CreatedOn = DateOnly.FromDateTime(organizationProject.projects.CreatedAt.DateTime),
                        ProjectId = organizationProject.projects.Id,
                        ProjectName = organizationProject.projects.ProjectName,
                        OrganizationProjectUsers = await GetUserProjects(organizationProject.projects.Id)
                    });
                }
            }

            return organizationProjectDetails;
        }

        public async Task<int> AddOrganization(Organizations organization)
        {
            await _organizationRepository.Add(organization);
            return await _organizationRepository.SaveChanges();
        }

        private async Task<List<ProjectUserDetailViewDto>> GetUserProjects(long projectId)
        {
           return _projectUserRepository.Query().Where(p => p.ProjectId == projectId)
                .Include(p => p.Users)
                .Select
                (s => new ProjectUserDetailViewDto
                {
                    UserId = s.UserId,
                    UserName = s.Users.UserName
                }).ToList();
        }
    }
}
