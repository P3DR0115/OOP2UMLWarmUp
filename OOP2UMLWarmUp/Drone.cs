using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2UMLWarmUp
{
    public class Drone : AerialVehicle
    {

        public Drone()
        {
            maxAltitude = 500;
        }

        public override void FlyDown()
        {
            base.FlyDown(100);
        }

        public override void FlyUp()
        {
            base.FlyUp(100);
        }
        
    }
}
