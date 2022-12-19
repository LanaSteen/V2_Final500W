
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using V2_Final500W.Models;

namespace V2_Final500W.Configurations
{
    /// <summary>
    /// This class is for the ScheduleRoom Class configuration
    /// </summary>

    public class ScheduleSubjectConfiguration : IEntityTypeConfiguration<ScheduleSubject>
    {
        /// <summary>
        /// This method is for building the ScheduleRoom class as a table with it's properties
        /// </summary>
        public void Configure(EntityTypeBuilder<ScheduleSubject> builder)
        {
            builder.ToTable("ScheduleSubject", "schedule_subject");



            builder.Property(x => x.ScheduleId);//.IsRequired();
            builder.Property(x => x.SubjectId);//.IsRequired();



        }
    }
}