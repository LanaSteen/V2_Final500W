using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using V2_Final500W.Models;

namespace V2_Final500W.Configurations
{
    /// <summary>
    /// This class is for the Teacher Class configuration
    /// </summary>
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {

        /// <summary>
        /// This method is for building the Teacher class as a table with it's properties
        /// </summary>
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {

            builder.ToTable("Teacher", "teacher");
            // builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.LastName)
             .HasMaxLength(200)
             .IsRequired();

            builder.Property(x => x.PersonalId)
              .HasMaxLength(11)
              .IsRequired();

            builder.Property(x => x.DepartmentId);//.IsRequired();

            builder.HasOne(b => b.Address) 
              .WithOne(b => b.Teacher)
              .HasForeignKey<Teacher>(b => b.AddressId);

            builder.HasOne(x => x.Subject)
         .WithMany(x => x.Teachers)
         .HasForeignKey(x => x.SubjectId)
         .HasConstraintName("FK_Teachers_Subject");
        }
    }
}
