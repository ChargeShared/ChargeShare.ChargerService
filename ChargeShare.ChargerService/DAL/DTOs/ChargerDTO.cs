using Shared.Models;

namespace ChargeShare.ChargerService.DAL.DTOs;

public class ChargerDTO
{
    public string Name { get; set; }
    public ChargerType ChargerType { get; set; }
    public double PricePerHour { get; set; }
    public bool QuickCharge { get; set; }
}