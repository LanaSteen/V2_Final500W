using Microsoft.EntityFrameworkCore;
using V2_Final500W.Configurations;
using V2_Final500W.Models;

namespace V2_Final500W
{
    /// <summary>
    /// this is DbContext
    /// </summary>
    public class UniversityDbContext : DbContext
    {
        /// <summary>
        /// this is configuring dbContext options
        /// </summary>
        /// <param name="options"></param>
        public UniversityDbContext(DbContextOptions<UniversityDbContext> options) : base(options)
        {

        }
        #region DbSet
        /// <summary>
        /// Set Address table
        /// </summary>
        public DbSet<Address>? Address { get; set; }
        /// <summary>
        /// Set Balance table
        /// </summary>
        public DbSet<Balance>? Balance { get; set; }
        /// <summary>
        /// Set Department table
        /// </summary>
        public DbSet<Department>? Department { get; set; }
        /// <summary>
        /// Set Room table
        /// </summary>
        public DbSet<Room>? Room { get; set; }
        /// <summary>
        /// Set Schedule table
        /// </summary>
        public DbSet<Schedule>? Schedule { get; set; }
        /// <summary>
        /// Set Semester table
        /// </summary>
        public DbSet<Semester>? Semester { get; set; }
        /// <summary>
        /// Set Student table
        /// </summary>
        public DbSet<Student>? Student { get; set; }
        /// <summary>
        /// Set StudentSubject table
        /// </summary>
        public DbSet<StudentSubject>? StudentSubject { get; set; }
        /// <summary>
        /// Set Subject table
        /// </summary>
        public DbSet<Subject>? Subject { get; set; }
        /// <summary>
        /// Set Teacher table
        /// </summary>
        public DbSet<Teacher>? Teacher { get; set; }
        /// <summary>
        /// Set ScheduleRoom table
        /// </summary>
        public DbSet<ScheduleRoom>? ScheduleRoom { get; set; }
        /// <summary>
        /// Set ScheduleSubject table
        /// </summary>
        public DbSet<ScheduleSubject>? ScheduleSubject { get; set; }

        #endregion

        /// <summary>
        /// this is creating all models through configurations
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AddressConfiguration).Assembly);
        }
    }
}
