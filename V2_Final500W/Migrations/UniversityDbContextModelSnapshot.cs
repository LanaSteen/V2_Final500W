// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using V2_Final500W;

#nullable disable

namespace V2_Final500W.Migrations
{
    [DbContext(typeof(UniversityDbContext))]
    partial class UniversityDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("V2_Final500W.Common.Responce", b =>
                {
                    b.Property<int>("StatusCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatusCode"), 1L, 1);

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("StatusCode");

                    b.ToTable("Responces");

                    b.HasData(
                        new
                        {
                            StatusCode = -3,
                            Message = "AKA \"System Error\" by meaning I don't have idea what's going on :)"
                        },
                        new
                        {
                            StatusCode = -1,
                            Message = "Operation wass completed successfully"
                        },
                        new
                        {
                            StatusCode = -2,
                            Message = "Wrong parameters"
                        });
                });

            modelBuilder.Entity("V2_Final500W.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address1")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Address2")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Address", "address");
                });

            modelBuilder.Entity("V2_Final500W.Models.Balance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18,2)")
                        .HasDefaultValue(0m);

                    b.Property<decimal?>("Debth")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("SemesterId")
                        .HasColumnType("int");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SemesterId");

                    b.HasIndex("StudentId");

                    b.ToTable("Balance", "balance");
                });

            modelBuilder.Entity("V2_Final500W.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CurrentAmount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("MaxNumberOfStudents")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int?>("SemesterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SemesterId");

                    b.ToTable("Department", "department");
                });

            modelBuilder.Entity("V2_Final500W.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool?>("IsFree")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<int>("MaxNumberOfStudents")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.ToTable("Room", "room");
                });

            modelBuilder.Entity("V2_Final500W.Models.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time(7)");

                    b.Property<int?>("SemesterId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time(7)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SemesterId");

                    b.ToTable("Schedule", "schedule");
                });

            modelBuilder.Entity("V2_Final500W.Models.ScheduleRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("RoomId")
                        .HasColumnType("int");

                    b.Property<int?>("ScheduleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.HasIndex("ScheduleId");

                    b.ToTable("ScheduleRoom", "schedule_room");
                });

            modelBuilder.Entity("V2_Final500W.Models.ScheduleSubject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ScheduleId")
                        .HasColumnType("int");

                    b.Property<int?>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ScheduleId");

                    b.HasIndex("SubjectId");

                    b.ToTable("ScheduleSubject", "schedule_subject");
                });

            modelBuilder.Entity("V2_Final500W.Models.Semester", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AvaliableGPA")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<DateTime?>("EndDate")
                        .HasPrecision(0)
                        .HasColumnType("datetime2(0)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("StartDate")
                        .HasPrecision(0)
                        .HasColumnType("datetime2(0)");

                    b.Property<int?>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Semester", "semester");
                });

            modelBuilder.Entity("V2_Final500W.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("PersonalId")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<int?>("SemesterId")
                        .HasColumnType("int");

                    b.Property<int>("StartYear")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique()
                        .HasFilter("[AddressId] IS NOT NULL");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("SemesterId");

                    b.ToTable("Student", "student");
                });

            modelBuilder.Entity("V2_Final500W.Models.StudentSubject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Point")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.Property<int?>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("SubjectId");

                    b.ToTable("StudentSubject", "student_subject");
                });

            modelBuilder.Entity("V2_Final500W.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Credit")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("LowerBound")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("MaxNumberOfStudents")
                        .HasColumnType("int");

                    b.Property<int>("MaxNumberOfTeachers")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Subject", "subject");
                });

            modelBuilder.Entity("V2_Final500W.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("PersonalId")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<int?>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique()
                        .HasFilter("[AddressId] IS NOT NULL");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Teacher", "teacher");
                });

            modelBuilder.Entity("V2_Final500W.Models.Balance", b =>
                {
                    b.HasOne("V2_Final500W.Models.Semester", "Semester")
                        .WithMany()
                        .HasForeignKey("SemesterId");

                    b.HasOne("V2_Final500W.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId");

                    b.Navigation("Semester");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("V2_Final500W.Models.Department", b =>
                {
                    b.HasOne("V2_Final500W.Models.Semester", "Semester")
                        .WithMany("Departments")
                        .HasForeignKey("SemesterId")
                        .HasConstraintName("FK_Departments_Semester");

                    b.Navigation("Semester");
                });

            modelBuilder.Entity("V2_Final500W.Models.Schedule", b =>
                {
                    b.HasOne("V2_Final500W.Models.Semester", "Semester")
                        .WithMany("Schedules")
                        .HasForeignKey("SemesterId")
                        .HasConstraintName("FK_Schedules_Semester");

                    b.Navigation("Semester");
                });

            modelBuilder.Entity("V2_Final500W.Models.ScheduleRoom", b =>
                {
                    b.HasOne("V2_Final500W.Models.Room", "Room")
                        .WithMany("ScheduleRooms")
                        .HasForeignKey("RoomId")
                        .HasConstraintName("FK_Room_ScheduleRooms");

                    b.HasOne("V2_Final500W.Models.Schedule", "Schedule")
                        .WithMany("ScheduleRooms")
                        .HasForeignKey("ScheduleId")
                        .HasConstraintName("FK_ScheduleRooms_Room");

                    b.Navigation("Room");

                    b.Navigation("Schedule");
                });

            modelBuilder.Entity("V2_Final500W.Models.ScheduleSubject", b =>
                {
                    b.HasOne("V2_Final500W.Models.Schedule", "Schedule")
                        .WithMany("ScheduleSubjects")
                        .HasForeignKey("ScheduleId")
                        .HasConstraintName("FK_ScheduleSubjects_Room");

                    b.HasOne("V2_Final500W.Models.Subject", "Subject")
                        .WithMany("ScheduleSubject")
                        .HasForeignKey("SubjectId")
                        .HasConstraintName("FK_ScheduleSubject_Subject");

                    b.Navigation("Schedule");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("V2_Final500W.Models.Student", b =>
                {
                    b.HasOne("V2_Final500W.Models.Address", "Address")
                        .WithOne("Student")
                        .HasForeignKey("V2_Final500W.Models.Student", "AddressId");

                    b.HasOne("V2_Final500W.Models.Department", "Department")
                        .WithMany("Students")
                        .HasForeignKey("DepartmentId")
                        .HasConstraintName("FK_Students_Department");

                    b.HasOne("V2_Final500W.Models.Semester", "Semester")
                        .WithMany("Students")
                        .HasForeignKey("SemesterId")
                        .HasConstraintName("FK_Students_Semester");

                    b.Navigation("Address");

                    b.Navigation("Department");

                    b.Navigation("Semester");
                });

            modelBuilder.Entity("V2_Final500W.Models.StudentSubject", b =>
                {
                    b.HasOne("V2_Final500W.Models.Student", "Student")
                        .WithMany("StudentSubject")
                        .HasForeignKey("StudentId")
                        .HasConstraintName("FK_StudentSubject_Student");

                    b.HasOne("V2_Final500W.Models.Subject", "Subject")
                        .WithMany("StudentSubject")
                        .HasForeignKey("SubjectId")
                        .HasConstraintName("FK_StudentSubject_Subject");

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("V2_Final500W.Models.Teacher", b =>
                {
                    b.HasOne("V2_Final500W.Models.Address", "Address")
                        .WithOne("Teacher")
                        .HasForeignKey("V2_Final500W.Models.Teacher", "AddressId");

                    b.HasOne("V2_Final500W.Models.Department", "Department")
                        .WithMany("Teachers")
                        .HasForeignKey("DepartmentId")
                        .HasConstraintName("FK_Teachers_Department");

                    b.HasOne("V2_Final500W.Models.Subject", "Subject")
                        .WithMany("Teachers")
                        .HasForeignKey("SubjectId")
                        .HasConstraintName("FK_Teachers_Subject");

                    b.Navigation("Address");

                    b.Navigation("Department");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("V2_Final500W.Models.Address", b =>
                {
                    b.Navigation("Student");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("V2_Final500W.Models.Department", b =>
                {
                    b.Navigation("Students");

                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("V2_Final500W.Models.Room", b =>
                {
                    b.Navigation("ScheduleRooms");
                });

            modelBuilder.Entity("V2_Final500W.Models.Schedule", b =>
                {
                    b.Navigation("ScheduleRooms");

                    b.Navigation("ScheduleSubjects");
                });

            modelBuilder.Entity("V2_Final500W.Models.Semester", b =>
                {
                    b.Navigation("Departments");

                    b.Navigation("Schedules");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("V2_Final500W.Models.Student", b =>
                {
                    b.Navigation("StudentSubject");
                });

            modelBuilder.Entity("V2_Final500W.Models.Subject", b =>
                {
                    b.Navigation("ScheduleSubject");

                    b.Navigation("StudentSubject");

                    b.Navigation("Teachers");
                });
#pragma warning restore 612, 618
        }
    }
}
