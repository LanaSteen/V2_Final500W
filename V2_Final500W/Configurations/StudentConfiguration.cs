using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using V2_Final500W.Models;

namespace V2_Final500W.Configurations
{
    /// <summary>
    /// This class is for the Student Class configuration
    /// </summary>
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        /// <summary>
        /// This method is for building the student class as a table with it's properties
        /// </summary>
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Student", "student");
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

            builder.Property(x => x.StartYear)
                   //  .HasColumnType("datetime2")
                   //  .HasPrecision(0) /// i.mn not sure if it needs   i need just year it will be just int
                   .HasColumnType("int")
                   //.HasDefaultValue(0)
                   .IsRequired();
                 
            //////////////////////// .HasDefaultValueSql("GETDATE()");//DateTime.Now


            builder.Property(x => x.DepartmentId);//.IsRequired();



          //  builder.Property(x => x.AddressId);//.IsRequired();

            builder.HasOne(b => b.Address)
                .WithOne(b => b.Student)
                .HasForeignKey<Student>(b => b.AddressId);





            builder.Property(x => x.SemesterId);//.IsRequired();





            builder.HasMany(x => x.StudentSubject)
            .WithOne(x => x.Student)
            .HasForeignKey(x => x.StudentId)
            .HasConstraintName("FK_StudentSubject_Student");




            //builder.HasOne(x => x.Address)
            //    .WithOne(x => x.Student)
            //    .HasForeignKey(x => x.)
            //    .HasConstraintName("FK_Schedules_Semester");

            //builder.HasOne(x => x.Department)
            //  .WithOne(x => x.Student)
            //  .HasForeignKey(x => x.DepartmentId)
            //  .HasConstraintName("FK_Departments_Semester");

            //builder.HasMany(x => x.Students)
            //    .WithOne(x => x.Semester)
            //    .HasForeignKey(x => x.SemesterId)
            //    .HasConstraintName("FK_Students_Semester");


            //builder.HasOne(s => s.Department)
            //.WithOne(ad => ad.Student)
            //.HasForeignKey<Department>(ad => ad.DepartmentId)
            //.HasConstraintName("FK_Department_Student");

            //builder.HasOne(s => s.Address)
            //.WithOne(ad => ad.Student)
            //.HasForeignKey<Address>(ad => ad.StudentId)
            //  .HasConstraintName("FK_Address_Student");


            //builder.Hasone(s => s.Semester)
            //.WithOne(ad => ad.Student)
            //.HasForeignKey<Semester>(ad => ad.SemesterId)
            //.HasConstraintName("FK_Semester_Student");



        }
    }
}
