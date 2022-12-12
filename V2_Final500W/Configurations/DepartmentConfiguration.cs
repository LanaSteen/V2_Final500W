using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using V2_Final500W.Models;

namespace V2_Final500W.Configurations
{
    /// <summary>
    /// This class is for the Department Class configuration
    /// </summary>
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        /// <summary>
        /// This method is for building the department class with it's properties
        /// </summary>
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Department", "department");
            // builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .HasMaxLength(150)
                .IsRequired();


            builder.Property(x => x.MaxNumberOfStudents)
                .HasColumnType("int")
                .HasDefaultValue(0)
                  .IsRequired();

            builder.Property(x => x.CurrentAmount)
                .HasColumnType("int")
                .HasDefaultValue(0)
                  .IsRequired();

            builder.Property(x => x.SemesterId);
              

            builder.HasMany(x => x.Students)
             .WithOne(x => x.Department)
             .HasForeignKey(x => x.DepartmentId)
             .HasConstraintName("FK_Students_Department");


            builder.HasMany(x => x.Teachers)
           .WithOne(x => x.Department)
           .HasForeignKey(x => x.DepartmentId)
           .HasConstraintName("FK_Teachers_Department");
        }

    }
}
