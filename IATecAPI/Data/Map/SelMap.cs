using IATecAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IATecAPI.Data.Map
{
    public class SelMap : IEntityTypeConfiguration<SelModel>
    {
        public void Configure(EntityTypeBuilder<SelModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.Identificador).IsRequired();
            builder.Property(x => x.SellerId).IsRequired();

            builder.HasOne(x => x.Seller);
        }
    }
}