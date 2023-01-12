using ChargeShare.ChargerService.DAL.Contexts;
using Shared.Models;

namespace ChargeShare.ChargerService.DAL.Repositories
{
    public class ChargerRepository : IChargerRepository
    {
        private readonly ChargerContext _chargerContext;

        public ChargerRepository(ChargerContext chargerContext)
        {
            _chargerContext = chargerContext;
        }

        public async Task<IEnumerable<ChargeStationModel>> GetAllAsync()
        {
            return _chargerContext.Chargers;
        }

        public async Task<ChargeStationModel> SaveChargeStationAsync(ChargeStationModel chargeStation)
        {
            if (chargeStation == null) throw new ArgumentNullException();

            _chargerContext.Chargers.Add(chargeStation);
            await _chargerContext.SaveChangesAsync();

            return chargeStation;
        }
    }
}
