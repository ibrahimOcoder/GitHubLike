using System.Reflection;
using GitHubLike.Modules.Common.Entity;
using GitHubLike.Modules.Common.Helpers;
using GitHubLike.Modules.Common.Repository;
using GitHubLike.Modules.RoleModule.Repository;
using GitHubLike.Modules.RoleModule.Services;
using GitHubLike.Modules.WorkspaceModule.Repository;
using GitHubLike.Modules.WorkspaceModule.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IWorkspaceService, WorkspaceService>();
builder.Services.AddScoped<IRoleService, RoleService>();

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();