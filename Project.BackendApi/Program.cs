using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Project.Application.Catalog.Area;
using Project.Application.Catalog.Plan;
using Project.Application.Catalog.Survey;
using Project.Application.Catalog.UserAccount;
using Project.Application.Common;
using Project.Application.System.Users;
using Project.Data.EF;
using Project.Data.Entities;
using Project.Uttilities.Constants;
using System.Net.Mail;
using System.Net;
using Project.Application.System.Roles;
using Project.Application.Catalog.Notification;
using Project.Application.Catalog.Task;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ProjectDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString(SystemConstants.MainConnectionString)));

builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<ProjectDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddTransient<IStorageService, FileStorageService>();
builder.Services.AddTransient<IManageAccountService , ManageAccountService>();
builder.Services.AddTransient<IPublicUserService , PublicUserService>();
builder.Services.AddTransient<IAreaManageService , AreaManageService>();
builder.Services.AddTransient<IPlanService , PlanService>();
builder.Services.AddTransient<ISurveyService , SurveyService>();
builder.Services.AddTransient<INotificationService , NotificationService>();
builder.Services.AddTransient<ITaskService , TaskService>();
builder.Services.AddTransient<IRoleService , RoleService>();
builder.Services.AddTransient<UserManager<AppUser> , UserManager<AppUser>>();
builder.Services.AddTransient<SignInManager<AppUser> , SignInManager<AppUser>>();
builder.Services.AddTransient<RoleManager<AppRole>, RoleManager<AppRole>>();
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddControllers();


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger Project", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using Bearer Schema.
            Enter 'Bearer [space] and then your token in the text input below. Example: 'Bearer 1234567890QWERTY'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
        new OpenApiSecurityScheme
            {
            Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
        new List<string>()
        }
    });
});

string issuer = builder.Configuration.GetValue<string>("Tokens:Issuer");
string signingKey = builder.Configuration.GetValue<string>("Tokens:Key");
byte[] signingKeyBytes = System.Text.Encoding.UTF8.GetBytes(signingKey);

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})

.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidIssuer = issuer,
        ValidateAudience = true,
        ValidAudience = issuer,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ClockSkew = System.TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(signingKeyBytes)
    };
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

app.UseAuthentication();

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
