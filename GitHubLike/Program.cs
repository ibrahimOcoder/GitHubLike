using System.Text;
using GitHubLike.Modules.Common.Entity;
using GitHubLike.Modules.Common.Helpers;
using GitHubLike.Modules.Common.Repository;
using GitHubLike.Modules.Common.Services;
using GitHubLike.Modules.OrganizationModule.Repository;
using GitHubLike.Modules.OrganizationModule.Services;
using GitHubLike.Modules.ProjectModule.Repository;
using GitHubLike.Modules.ProjectModule.Services;
using GitHubLike.Modules.RoleModule.Repository;
using GitHubLike.Modules.RoleModule.Services;
using GitHubLike.Modules.UserModule.Repository;
using GitHubLike.Modules.UserModule.Services;
using GitHubLike.Modules.WorkspaceModule.Repository;
using GitHubLike.Modules.WorkspaceModule.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// TODO: move these DIs their respective modules somehow to have less code here for maintainability and more loose coupling:
builder.Services.AddScoped<IWorkspaceService, WorkspaceService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IProjectUsersService, ProjectUsersService>();
builder.Services.AddScoped<IOrganizationService, OrganizationService>();
builder.Services.AddScoped<IOrganizationUserService, OrganizationUserService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

#region JWT

var jwtIssuer = builder.Configuration.GetSection("Jwt:Issuer").Get<string>();
var jwtKey = builder.Configuration.GetSection("Jwt:Key").Get<string>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtIssuer,
            ValidAudience = jwtIssuer,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
        };
    });


#endregion

//DbSeeder seeder = new DbSeeder();
//seeder.SeedData();

builder.Services.AddControllers();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(300);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();
app.UseSession();
app.UseCors(builder => builder
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin()
);
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();