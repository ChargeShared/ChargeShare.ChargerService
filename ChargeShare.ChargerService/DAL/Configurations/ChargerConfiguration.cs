using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Models;

namespace ChargeShare.ChargerService.DAL.Configurations
{
    public class ChargerConfiguration : IEntityTypeConfiguration<ChargeStationModel>
    {
        public void Configure(EntityTypeBuilder<ChargeStationModel> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
