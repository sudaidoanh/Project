using Microsoft.EntityFrameworkCore;
using Project.Data.Configuations;
using Project.Data.Configurations;
using Project.Data.Entities;

namespace Project.Data.EF
{
    public class ProjectDbContext : DbContext
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
            modelBuilder.ApplyConfiguration(new InviteConfiguration());
            modelBuilder.ApplyConfiguration(new MediaTaskConfiguration());
            modelBuilder.ApplyConfiguration(new PlanConfiguration());
            modelBuilder.ApplyConfiguration(new TaskConfiguration());
            modelBuilder.ApplyConfiguration(new TaskDetailConfiguration());

            //base.OnModelCreating(modelBuilder);
        }

        public DbSet<Distributor> Distributors { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Configuration> Configurations { get; set; }
        public DbSet<AreaDistributor> AreaDistributors { get; set; }
        public DbSet<AreaUser> AreaUsers { get; set; }
        public DbSet<SystemActivity> SystemActivities { get; set; }
        public DbSet<MediaTask> MediaTasks { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Invite> Invites { get; set; }
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
