using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2UMLWarmUp
{
    public class Airport
    {
        public int MaxVehicles;
        public List<AerialVehicle> Vehicles;

        public string AirportCode { get; set; }

        public Airport(string Code) : this(Code, 5) { }

        public Airport(string Code, int MaxVehiclesUserDefined)
        {
            AirportCode = Code;
            MaxVehicles = MaxVehiclesUserDefined;
            Vehicles = new List<AerialVehicle>();
        }

        public string AllTakeOff()
        {
            string takeoffMessage = "";
            for(int i = 0; i < Vehicles.Count; i++)
            {
                Vehicles[i].StartEngine();
                Vehicles[i].TakeOff();
                takeoffMessage += Vehicles[i].ToString() + " has taken off. ";
                
            }

            Vehicles.Clear();

            if (takeoffMessage != "")
            {
                return takeoffMessage;
            }
            else
            {
                return "All Vehicles have already taken off";
            }
        }

        public string Land(AerialVehicle av)
        {
            string message = "";

            if (av.isFlying)
            {
                av.FlyDown(av.currentAltitude);
                av.StopEngine();
                Vehicles.Add(av);
                message += av.ToString() + " has landed. ";
            }

            return message;
        }

        public string Land(List<AerialVehicle> landing)
        {
            string message = "";

            for(int i = 0; i < landing.Count; i++)
            {
                landing[i].FlyDown(landing[i].currentAltitude);
                landing[i].StopEngine();
                Vehicles.Add(landing[i]);
                message += landing[i].ToString() + " has landed. ";
                
            }

            return message;
        }

        public string TakeOff(AerialVehicle a)
        {
            string takeoffMessage = "";
            
            a.StartEngine();
            a.TakeOff();
            Vehicles.Remove(a);
            takeoffMessage += a.ToString() + " has taken off. ";
                
            
            return takeoffMessage;
        }

    }
}
