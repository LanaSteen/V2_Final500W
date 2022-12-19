using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using V2_Final500W.Models;

namespace V2_Final500W.Configurations
{
    /// <summary>
    /// This class is for the Room Class configuration
    /// </summary>
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        /// <summary>
        /// This method is for building the room class as a table with it's properties
        /// </summary>
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable("Room", "room");
            // builder.HasKey(x => x.Id);
            builder.Property(x => x.Description)
                .HasMaxLength(200)
                .IsRequired();


            builder.Property(x => x.MaxNumberOfStudents)
                .HasColumnType("int")
                .HasDefaultValue(0)
                  .IsRequired();

            builder.Property(x => x.IsFree)
                .HasDefaultValue(true)
                .IsRequired();


            builder.HasMany(x => x.ScheduleRooms)
                .WithOne(x => x.Room)
                .HasForeignKey(x => x.RoomId)
                .HasConstraintName("FK_Room_ScheduleRooms");

        }
    }
}
