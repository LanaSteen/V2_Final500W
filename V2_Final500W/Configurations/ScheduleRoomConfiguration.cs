using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using V2_Final500W.Models;

namespace V2_Final500W.Configurations
{

    /// <summary>
    /// This class is for the ScheduleRoom Class configuration
    /// </summary>
    public class ScheduleRoomConfiguration : IEntityTypeConfiguration<ScheduleRoom>
    {
        /// <summary>
        /// This method is for building the ScheduleRoom class as a table with it's properties
        /// </summary>
        public void Configure(EntityTypeBuilder<ScheduleRoom> builder)
        {
            builder.ToTable("ScheduleRoom", "schedule_room");


            builder.Property(x => x.ScheduleId);//.IsRequired();
            builder.Property(x => x.RoomId);//.IsRequired();



        }
    }
       
}
