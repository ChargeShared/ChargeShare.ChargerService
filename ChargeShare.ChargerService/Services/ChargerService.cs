using ChargeShare.ChargerService.DAL.DTOs;
using ChargeShare.ChargerService.DAL.Repositories;
using Microsoft.AspNetCore.Identity;
using Shared.Models;

namespace ChargeShare.ChargerService.Services
{
    public class ChargerService : IChargerService
    {
        private readonly IChargerRepository _repository;
        public ChargerService(IChargerRepository repository)
        {
            _repository = repository;
        }

        public async Task<ChargeStationModel> RegisterCharger(ChargerDTO chargerDto, ChargeSharedUserModel user)
        {
            if (chargerDto.ChargerType == null)
            {
                throw new Exception("Chargertype cannot be null!");
            }

            ChargeStationModel chargeStation = new ChargeStationModel();

            chargeStation.Name = chargerDto.Name;
            chargeStation.ChargerType = (ChargerType)chargerDto.ChargerType;
            chargeStation.PricePerHour = chargerDto.PricePerHour;
            chargeStation.QuickCharge = chargerDto.QuickCharge;

            chargeStation.Owner = user;

            //TODO ABSOLUUT FIXEN VOOR PRODUCTIE!!!!!!!!
            chargeStation.Adres = user.Aresses.First();

            return await _repository.SaveChargeStationAsync(chargeStation);
        }
    }
}
