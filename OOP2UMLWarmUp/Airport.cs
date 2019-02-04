using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2UMLWarmUp
{
    class Airport
    {
        int MaxVehicles;
        List<AerialVehicle> Vehicles;

        string AirportCode { get => AirportCode; set => AirportCode = value; }

        Airport(string Code)
        {

        }

        Airport(string Code, int MaxVehicles)
        {

        }

        string AllTakeOff()
        {
            return "";
        }

        string Land(AerialVehicle a)
        {
            return "";
        }

        string Land(List<AerialVehicle> landing)
        {
            return "";
        }

        string TakeOff(AerialVehicle a)
        {
            return "";
        }

    }
}
