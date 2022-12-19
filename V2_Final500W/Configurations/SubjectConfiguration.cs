using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using V2_Final500W.Models;

namespace V2_Final500W.Configurations
{

    /// <summary>
    /// This class is for the Subject Class configuration
    /// </summary>
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        /// <summary>
        /// This method is for building the Subject class with it's properties
        /// </summary>
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.ToTable("Subject", "subject");



            // builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired();


            builder.Property(x => x.Credit)
                .HasColumnType("int")
                .HasDefaultValue(0)
                  .IsRequired();

            builder.Property(x => x.LowerBound)
                 .HasColumnType("int")
                 .HasDefaultValue(0);


            builder.Property(x => x.MaxNumberOfStudents)
                 .HasColumnType("int")
                 .IsRequired();

            builder.Property(x => x.MaxNumberOfTeachers)
                 .HasColumnType("int")
                 .IsRequired();


            builder.HasMany(x => x.Teachers)
                .WithOne(x => x.Subject)
                .HasForeignKey(x => x.SubjectId)
                .HasConstraintName("FK_Teachers_Subject");

            builder.HasMany(x => x.ScheduleSubject)
                .WithOne(x => x.Subject)
                .HasForeignKey(x => x.SubjectId)
                .HasConstraintName("FK_ScheduleSubject_Subject");

            builder.HasMany(x => x.StudentSubject)
            .WithOne(x => x.Subject)
            .HasForeignKey(x => x.SubjectId)
            .HasConstraintName("FK_StudentSubject_Subject");



        }
    }


}