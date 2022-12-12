using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using V2_Final500W.Models;

namespace V2_Final500W.Configurations
{
    /// <summary>
    /// This class is for the Balance Class configuration
    /// </summary>
    public class BalanceConfiguration : IEntityTypeConfiguration<Balance>
    {
        /// <summary>
        /// This method is for building Balance table with it's properties
        /// </summary>
        public void Configure(EntityTypeBuilder<Balance> builder)
        {
            builder.ToTable("Balance", "balance");
            // builder.HasKey(x => x.Id);
            builder.Property(x => x.Amount).HasColumnType("decimal(18,2)").HasDefaultValue(0);

            builder.Property(x => x.SemesterId);//.IsRequired();
            builder.Property(x => x.StudentId); //.IsRequired();

            builder.Property(x => x.Debth).HasColumnType("decimal(18,2)").HasDefaultValue(0);


        }
    }
}
