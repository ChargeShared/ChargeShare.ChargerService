using ChargeShare.ChargerService.DAL.DTOs;
using Shared.Models;

namespace ChargeShare.ChargerService.Services;

public interface IChargerService
{
    Task<ChargeStationModel> RegisterCharger(ChargerDTO chargerDto, ChargeSharedUserModel user);
}