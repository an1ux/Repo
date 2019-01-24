namespace ProjectControl
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ProjectsContext : DbContext
    {
        public ProjectsContext()
            : base("name=ProjectsContext")
        {
        }

        public virtual DbSet<EndUser> EndUsers { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<UserProject> UserProjects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EndUser>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<EndUser>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<EndUser>()
                .HasMany(e => e.UserProjects)
                .WithRequired(e => e.EndUser)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Project>()
                .HasMany(e => e.UserProjects)
                .WithRequired(e => e.Project)
                .WillCascadeOnDelete(false);
        }
    }
}
