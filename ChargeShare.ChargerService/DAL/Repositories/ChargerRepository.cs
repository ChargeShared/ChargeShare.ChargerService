using ChargeShare.ChargerService.DAL.Contexts;
using Shared.Models;

namespace ChargeShare.ChargerService.DAL.Repositories
{
    public class ChargerRepository
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
    }
}
