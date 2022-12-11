using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models;


public class AdresModel
{
    public int Id { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
    public string Region { get; set; }
    public string Province { get; set; }
    public string HouseNumber { get; set; }
    public string HouseAddition { get; set; }
}

