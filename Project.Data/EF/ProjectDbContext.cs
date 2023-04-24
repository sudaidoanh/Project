using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.Data.Configuations;
using Project.Data.Configurations;
using Project.Data.Entities;
using Project.Data.Extensions;

namespace Project.Data.EF
{
    public class ProjectDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public ProjectDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new ConfigConfiguration());
            modelBuilder.ApplyConfiguration(new AreaConfiguration());
            modelBuilder.ApplyConfiguration(new AreaDistributorConfiguration());
            modelBuilder.ApplyConfiguration(new AreaUserConfiguration());
            modelBuilder.ApplyConfiguration(new DistributorConfiguration());
            modelBuilder.ApplyConfiguration(new MediaTaskConfiguration());
            modelBuilder.ApplyConfiguration(new PlanConfiguration());
            modelBuilder.ApplyConfiguration(new TaskConfiguration());
            modelBuilder.ApplyConfiguration(new TaskDetailConfiguration());
            modelBuilder.ApplyConfiguration(new NotificationConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new ReportConfiguration());
            modelBuilder.ApplyConfiguration(new SurveyConfiguration());
            modelBuilder.ApplyConfiguration(new SurveyDetailConfiguration());
            modelBuilder.ApplyConfiguration(new SurveyedConfiguration());
            modelBuilder.ApplyConfiguration(new SystemActivityConfiguration());

            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new AppRoleConfiguration());

            modelBuilder.Entity<Microsoft.AspNetCore.Identity.IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
            modelBuilder.Entity<Microsoft.AspNetCore.Identity.IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new {x.UserId, x.RoleId});
            modelBuilder.Entity<Microsoft.AspNetCore.Identity.IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);
            modelBuilder.Entity<Microsoft.AspNetCore.Identity.IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
            modelBuilder.Entity<Microsoft.AspNetCore.Identity.IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);

            modelBuilder.Seed();
            //base.OnModelCreating(modelBuilder);

        }

        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Distributor> Distributors { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Configuration> Configurations { get; set; }
        public DbSet<AreaDistributor> AreaDistributors { get; set; }
        public DbSet<AreaUser> AreaUsers { get; set; }
        public DbSet<SystemActivity> SystemActivities { get; set; }
        public DbSet<MediaTask> MediaTasks { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Entities.Task> Tasks { get; set; }
        public DbSet<TaskDetail> TaskDetails { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Surveyed> Surveyeds { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<SurveyDetail> SurveyDetails { get; set; }



    }
}
