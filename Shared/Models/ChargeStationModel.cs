using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models;

public class ChargeStationModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int AdresId { get; set; }
    public AdresModel Adres { get; set; }
    public int OwnerId { get; set; }
    public ChargeSharedUserModel Owner { get; set; }
    public ChargerType ChargerType { get; set; }
    public double PricePerHour { get; set; }
    public bool QuickCharge { get; set; }
}

public enum ChargerType
{
    J1772,
    CCS_Combo_1,
    Type_2,
    CCS_Combo_2,
    CHAdeMO,
    Tesla,
    Wall_Outlet
}

