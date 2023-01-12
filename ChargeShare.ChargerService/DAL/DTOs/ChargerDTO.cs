using System.ComponentModel.DataAnnotations;
using Shared.Models;

namespace ChargeShare.ChargerService.DAL.DTOs;

public class ChargerDTO
{
    [Required]
    public string Name { get; set; }

    [Required] public ChargerType? ChargerType { get; set; } = null;

    [Required]
    [Range(0.000000001, Double.MaxValue, ErrorMessage = "Price cannot be 0!")]
    public double PricePerHour { get; set; }

    public bool QuickCharge { get; set; }

    public override string ToString()
    {
        return $"{this.Name}, {this.ChargerType}, {this.PricePerHour}, {this.QuickCharge}";
    }

}