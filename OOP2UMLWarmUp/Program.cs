using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2UMLWarmUp
{
    class Program
    {
        static void Main()
        {
            Airplane Boeing737 = new Airplane();

            Boeing737.TakeOff();

            Boeing737.StartEngine();

            Boeing737.TakeOff();

            Boeing737.FlyUp();
            Boeing737.FlyUp(50000);

            Boeing737.FlyDown();
            Boeing737.FlyDown(500000);
            Boeing737.FlyDown(Boeing737.currentAltitude);

            Boeing737.StopEngine();

            Console.WriteLine(Boeing737.About());

            Console.ReadLine();
        }
    }
}
