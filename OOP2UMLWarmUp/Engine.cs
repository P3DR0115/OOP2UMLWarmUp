using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2UMLWarmUp
{
    public class Engine
    {
        public bool isStarted; // { get => isStarted; set => isStarted = value; }


        public Engine()
        {
            this.Stop(); // isStarted = false;
        }

        public string About()
        {
            return "Engine Started: " + isStarted;
        }

        public void Start()
        {
            this.isStarted = true;
        }

        public void Stop()
        {
            this.isStarted = false;
        }
    }
}
