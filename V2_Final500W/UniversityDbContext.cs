using Microsoft.EntityFrameworkCore;
using V2_Final500W.Common;
using V2_Final500W.Configurations;
using V2_Final500W.Models;
using V2_Final500W.ViewModels;

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
        public DbSet<Address> Addresses { get; set; }
        /// <summary>
        /// Set Balance table
        /// </summary>
        public DbSet<Balance> Balances { get; set; }
        /// <summary>
        /// Set Department table
        /// </summary>
        public DbSet<Department> Departments { get; set; }
        /// <summary>
        /// Set Room table
        /// </summary>
        public DbSet<Room> Rooms { get; set; }
        /// <summary>
        /// Set Schedule table
        /// </summary>
        public DbSet<Schedule> Schedules { get; set; }
        /// <summary>
        /// Set Schedule table
        /// </summary>
        public DbSet<ScheduleRoom> ScheduleRooms { get; set; }
        /// <summary>
        /// Set Schedule table
        /// </summary>
        public DbSet<ScheduleSubject> ScheduleSubjects { get; set; }
        /// <summary>
        /// Set Semester table
        /// </summary>
        public DbSet<Semester> Semesters { get; set; }
        /// <summary>
        /// Set Student table
        /// </summary>
        public DbSet<Student> Students { get; set; }
        /// <summary>
        /// Set StudentSubject table
        /// </summary>
        public DbSet<StudentSubject>? StudentSubjects { get; set; }
        /// <summary>
        /// Set Subject table
        /// </summary>
        public DbSet<Subject> Subjects { get; set; }
        /// <summary>
        /// Set Teacher table
        /// </summary>
        public DbSet<Teacher> Teachers { get; set; }
        ///// <summary>
        ///// Set ScheduleRoom table
        ///// </summary>
        //public DbSet<ScheduleRoom> ScheduleRoom { get; set; }
        ///// <summary>
        ///// Set ScheduleSubject table
        ///// </summary>
        //public DbSet<ScheduleSubject> ScheduleSubject { get; set; }

        /// <summary>
        /// Set Responce table
        /// </summary>
        public DbSet<Responce> Responces { get; set; }

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
