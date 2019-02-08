using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2UMLWarmUp
{
    public class ToyPlane : Airplane
    {
        bool isWoundUp;

        public ToyPlane()
        {
            maxAltitude = 50;
        }

        string About()
        {
            return "";
        }

        string getWindUpString()
        {
            return "";
        }

        void StartEngine()
        {
            base.engine.Start();
        }

        string TakeOff()
        {
            return "";
        }

        void UnWind()
        {

        }

        void WindUp()
        {

        }
    }
}
