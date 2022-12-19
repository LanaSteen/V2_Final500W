using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using V2_Final500W.Models;

namespace V2_Final500W.Configurations
{
    /// <summary>
    /// This class is for the Address Class configuration
    /// </summary>
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {

        /// <summary>
        /// This method is for building Adress class properties
        /// </summary>
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address", "address");
           // builder.HasKey(x => x.Id);
            builder.Property(x => x.Address1).HasMaxLength(200).IsRequired();//.IsRequired();
            builder.Property(x => x.Address2).HasMaxLength(200);

       
            builder.HasOne(b => b.Student)
                .WithOne(b => b.Address)
                .HasForeignKey<Address>(b => b.StudentId);


            builder.HasOne(b => b.Teacher)
              .WithOne(b => b.Address)
              .HasForeignKey<Address>(b => b.StudentId);

            //builder.Property(x => x.Adddress1Type).IsRequired().HasDefaultValue("Living");

            //builder.Property(x => x.Adddress2Type);




            // builder.HasMany(x => x.Students)
            //.WithOne(x => x.Address)
            //.HasForeignKey(x => x.AddressId)
            //.HasConstraintName("FK_Students_Address");



            // builder.HasMany(x => x.Teachers)
            //.WithOne(x => x.Address)
            //.HasForeignKey(x => x.AddressId)
            //.HasConstraintName("FK_Teachers_Address");
        }
    }
}

