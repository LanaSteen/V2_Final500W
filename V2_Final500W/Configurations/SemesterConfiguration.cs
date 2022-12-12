using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using V2_Final500W.Models;

namespace V2_Final500W.Configurations
{
    /// <summary>
    /// This class is for the Semester Class configuration
    /// </summary>
    public class SemesterConfiguration : IEntityTypeConfiguration<Semester>
    {
        /// <summary>
        /// This method is for building the room class as a table with it's properties
        /// </summary>
        public void Configure(EntityTypeBuilder<Semester> builder)
        {
            builder.ToTable("Semester", "semester");
            // builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired();


            builder.Property(x => x.AvaliableGPA)
                .HasColumnType("int")
                .HasDefaultValue(0)
                  .IsRequired();

            
            builder.Property(x => x.StartDate)
                  .HasColumnType("datetime2")
                   .HasPrecision(0) /// i.mn not sure if it needs
                   .IsRequired();
            //////////////////////// .HasDefaultValueSql("GETDATE()");//DateTime.Now

            builder.Property(x => x.EndDate)
                 .HasColumnType("datetime2")
                  .HasPrecision(0)
                  .IsRequired();

            builder.HasMany(x => x.Schedules)
                .WithOne(x => x.Semester)
                .HasForeignKey(x => x.SemesterId)
                .HasConstraintName("FK_Schedules_Semester");

            builder.HasMany(x => x.Departments)
              .WithOne(x => x.Semester)
              .HasForeignKey(x => x.SemesterId)
              .HasConstraintName("FK_Departments_Semester");

            builder.HasMany(x => x.Students)
                .WithOne(x => x.Semester)
                .HasForeignKey(x => x.SemesterId)
                .HasConstraintName("FK_Students_Semester");

        }
    }
}
