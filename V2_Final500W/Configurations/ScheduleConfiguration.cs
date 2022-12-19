using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.Reflection.Emit;
using V2_Final500W.Models;

namespace V2_Final500W.Configurations
{
    /// <summary>
    /// This class is for the Schedule Class configuration
    /// </summary>
    public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        /// <summary>
        /// This method is for building the Schedule class as a table with it's properties
        /// </summary>
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.ToTable("Schedule", "schedule");
            // builder.HasKey(x => x.Id);
            builder.Property(x => x.StartTime)
                  .HasColumnType("time(7)")
                   //"time(7)"
                   //  .HasPrecision(0) /// i.mn not sure if it needs
                   .IsRequired();
            //////////////////////// .HasDefaultValueSql("GETDATE()");//DateTime.Now

            builder.Property(x => x.EndTime)
                 .HasColumnType("time(7)")
                  //  .HasPrecision(0)
                  .IsRequired();
                

            //////////////////////////////////////////////////////////////????????????????????????????????

            builder.Property(x => x.SemesterId);



            builder.HasMany(x => x.ScheduleRooms)
                   .WithOne(x => x.Schedule)
                   .HasForeignKey(x => x.ScheduleId)
                   .HasConstraintName("FK_ScheduleRooms_Room");


            builder.HasMany(x => x.ScheduleSubjects)
                    .WithOne(x => x.Schedule)
                    .HasForeignKey(x => x.ScheduleId)
                    .HasConstraintName("FK_ScheduleSubjects_Room");
        }
    }
}
