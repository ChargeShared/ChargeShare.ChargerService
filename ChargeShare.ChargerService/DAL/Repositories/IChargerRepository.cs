using Shared.Models;

namespace ChargeShare.ChargerService.DAL.Repositories;

public interface IChargerRepository
{
    Task<IEnumerable<ChargeStationModel>> GetAllAsync();
    Task<ChargeStationModel> SaveChargeStationAsync(ChargeStationModel chargeStation);
}