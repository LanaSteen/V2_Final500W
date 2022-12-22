using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace V2_Final500W.Common
{
    /// <summary>
    /// This class is for the Responce Class configuration
    /// </summary>
    public class ResponceConfig : IEntityTypeConfiguration<Responce>
    {
        /// <summary>
        /// This method is for building Responce class properties and data
        /// </summary>
        public void Configure(EntityTypeBuilder<Responce> builder)
        {
           
            builder.HasKey(x => x.StatusCode);

            builder.Property(x => x.Message)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasData(new List<Responce>
            {
                  new()
                {   
                    
                    StatusCode = -3,
                    Message= "AKA \"System Error\" by meaning I don't have idea what's going on :)",
                },
                new()
                {
                   
                    StatusCode = -1,
                    Message= "Operation wass completed successfully",

                },
                 new()
                {
                    
                    StatusCode = -2,
                    Message= "Wrong parameters",
                }
            });

        }
    }


}
