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
            return "This " + ToString() + " has a max altitude of " + maxAltitude + " ft.\n" + 
                "It's current altitude is " + currentAltitude + " ft.\n" + 
                ToString() +"Engine is started = " + engine.isStarted;
        }

        public virtual void FlyDown()
        {
            this.FlyDown(1000);
        }

        public void FlyDown(int HowManyFeet)
        {
            if (isFlying)
            {
                if (currentAltitude - HowManyFeet >= 0)
                {
                    currentAltitude -= HowManyFeet;

                    if (currentAltitude == 0)
                    {
                        isFlying = false;
                    }
                }
                else
                {
                    Console.WriteLine("Warning: Cannot fly down lower than current altitude. Current Altitude is " + currentAltitude + " ft.");
                }
            }
            else
            {
                Console.WriteLine("Warning: Currently not flying.");
            }
        }

        public virtual void FlyUp()
        {
            FlyUp(1000);
        }

        public void FlyUp(int HowManyFeet)
        {
            if(this.isFlying )
            {
                if (currentAltitude + HowManyFeet <= maxAltitude)
                {
                    currentAltitude += HowManyFeet;
                }
                else
                {
                    currentAltitude = maxAltitude;
                    Console.WriteLine("Max Altitude Reached, current altitude is " + currentAltitude + " ft.");
                }
            }
            else
            {
                Console.WriteLine("Warning: Currently not flying.");
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

        public virtual void StartEngine()
        {
            engine.isStarted = true;
        }

        public void StopEngine()
        {
            engine.isStarted = false;
        }

        public virtual string TakeOff()
        {
            if(engine.isStarted)
            {
                isFlying = true;
                return ToString() + " is flying.";
            }
            else
            {
                return ToString() + " cannot fly, its' engine is not started.";
            }
        }


    }
}
