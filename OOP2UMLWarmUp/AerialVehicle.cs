using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2UMLWarmUp
{
    abstract class AerialVehicle
    {
        public int currentAltitude { get => currentAltitude; set => currentAltitude = value; }
        public Engine engine { get => engine; set => engine = value; }
        public bool isFlying { get => isFlying; set => isFlying = value; }
        public int maxAltitude { get => maxAltitude; set => maxAltitude = value; }

        public AerialVehicle()
        {

        }

        string About()
        {
            return "";
        }

        void FlyDown()
        {

        }

        void FlyDown(int HowManyFeet)
        {

        }

        void FlyUp()
        {

        }

        void FlyUp(int HowManyFeet)
        {

        }

        string getEngineStartedString()
        {

            return "";
        }

        void StartEngine()
        {

        }

        void StopEngine()
        {

        }

        string TakeOff()
        {
            return "";
        }


    }
}
