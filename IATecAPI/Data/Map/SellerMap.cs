using IATecAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IATecAPI.Data.Map
{
    public class SellerMap : IEntityTypeConfiguration<SellerModel>
    {
        public void Configure(EntityTypeBuilder<SellerModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Cpf).IsRequired().HasMaxLength(11);
        }
    }
}
