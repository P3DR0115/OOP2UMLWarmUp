using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2UMLWarmUp
{
    public abstract class AerialVehicle
    {
        public int currentAltitude; // { get => currentAltitude; set => currentAltitude = value; }
        public Engine engine; // { get => engine; set => engine = value; }
        public bool isFlying; // { get => isFlying; set => isFlying = value; }
        public int maxAltitude; // { get => maxAltitude; set => maxAltitude = value; }

        public AerialVehicle()
        {
            engine = new Engine();
            currentAltitude = 0;
            maxAltitude = 0;
            isFlying = false;
        }

        public string About()
        {
            return "This " + this.ToString() + " has a max altitude of " + maxAltitude + " ft.\n" + 
                "It's current altitude is " + currentAltitude + " ft.\n" + 
                this.ToString() +"Engine is started = " + engine.isStarted;
        }

        public void FlyDown()
        {
            this.FlyDown(1000);
        }

        public void FlyDown(int HowManyFeet)
        {
            if (this.engine.isStarted && (this.currentAltitude - HowManyFeet >= 0))
            {
                this.currentAltitude -= HowManyFeet;
            }
            else
            {
                Console.WriteLine("Warning: Cannot fly down lower than current altitude. Current Altitude is " + currentAltitude + " ft.");
            }
        }

        public void FlyUp()
        {
            this.FlyUp(1000);
        }

        public void FlyUp(int HowManyFeet)
        {
            if(this.engine.isStarted && (this.currentAltitude + HowManyFeet <= this.maxAltitude))
            {
                this.currentAltitude += HowManyFeet;
            }
            else
            {
                this.currentAltitude = maxAltitude;
                Console.WriteLine("Max Altitude Reached, current altitude is " + currentAltitude + " ft.");
            }
        }

        public string getEngineStartedString()
        {
            if(engine.isStarted)
            {
                return "Engine is started";
            }
            else
            {
                return "Engine is not started";
            }
        }

        public void StartEngine()
        {
            engine.isStarted = true;
        }

        public void StopEngine()
        {
            engine.isStarted = false;
        }

        public string TakeOff()
        {
            if(engine.isStarted)
            {
                return this.ToString() + " is flying.";
            }
            else
            {
                return this.ToString() + " cannot fly, its' engine is not started.";
            }
        }


    }
}
