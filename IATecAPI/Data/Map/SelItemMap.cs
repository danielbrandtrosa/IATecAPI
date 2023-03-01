using IATecAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IATecAPI.Data.Map
{
    public class SelItemMap : IEntityTypeConfiguration<SelItemModel>
    {
        public void Configure(EntityTypeBuilder<SelItemModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Titule).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Quantity).IsRequired();
        }
    }
}
