using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Project.Application.Catalog.UserAccount;
using Project.Application.Common;
using Project.Application.System.Users;
using Project.Data.EF;
using Project.Data.Entities;
using Project.Uttilities.Constants;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ProjectDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString(SystemConstants.MainConnectionString)));

builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<ProjectDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddTransient<IStorageService, FileStorageService>();
builder.Services.AddTransient<IManageAccountService , ManageAccountService>();
builder.Services.AddTransient<UserManager<AppUser> , UserManager<AppUser>>();
builder.Services.AddTransient<SignInManager<AppUser> , SignInManager<AppUser>>();
/*builder.Services.AddTransient<RoleManager<AppUser> , RoleManager<AppUser>>();*/
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddControllersWithViews();


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger Project", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Project v1");
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
