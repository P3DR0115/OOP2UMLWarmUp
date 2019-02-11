using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2UMLWarmUp
{
    public class ToyPlane : Airplane
    {
        public bool isWoundUp;

        public ToyPlane()
        {
            maxAltitude = 50;
            UnWind();
        }

        public string About()
        {
            return "This " + this.ToString() + " has a max altitude of " + maxAltitude + " ft.\n" +
                "It's current altitude is " + currentAltitude + " ft.\n" +
                this.ToString() + "Engine is started = " + engine.isStarted;
        }

        public string getWindUpString()
        {
            if (isWoundUp)
                return this.ToString() + " is wound up";
            else
                return this.ToString() + " is not wound up";
        }

        public override void StartEngine()
        {
            if (this.isWoundUp)
                base.engine.Start();
            else
                Console.WriteLine("Cannot start engine, toy plane is not wound up!");
        }

        public override string TakeOff()
        {
            return base.TakeOff();

        }

        public void UnWind()
        {
            this.isWoundUp = false;
        }

        public void WindUp()
        {
            this.isWoundUp = true;
        }
    }
}
