using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using V2_Final500W.Models;

namespace V2_Final500W.Configurations
{
    /// <summary>
    /// This class is for the StudentSubject Class configuration
    /// </summary>

    public class StudentSubjectConfiguration : IEntityTypeConfiguration<StudentSubject>
    {
        /// <summary>
        /// This method is for building the StudentSubject class as a table with it's properties
        /// </summary>
        public void Configure(EntityTypeBuilder<StudentSubject> builder)
        {
            builder.ToTable("StudentSubject", "student_subject");

            builder.Property(x => x.Point)
                .HasColumnType("int")
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(x => x.SubjectId);//.IsRequired();
            builder.Property(x => x.StudentId);//.IsRequired();



        }
    }
}