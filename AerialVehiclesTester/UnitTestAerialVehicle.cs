using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP2UMLWarmUp;

namespace AerialVehiclesTester
{
    [TestClass]
    public class UnitTestAerialVehicle
    {
        Airplane boeing;
        ToyPlane toy;
        Helicopter apache;
        Drone uav;
        Engine motor;
        Airport terminal;

        [TestMethod]
        public void TestEngine()
        {
            // Arrange
            motor = new Engine();

            // Act
            string engineAboutPreStart = motor.About();

            bool originalEngineStatus = motor.isStarted;
            motor.Start();
            bool postEngineStartStatus = motor.isStarted;
            string engineAboutPostStart = motor.About();
            motor.Stop();
            bool postEngineStopStatus = motor.isStarted;


            // Assert
            Assert.AreEqual(false, originalEngineStatus);
            Assert.AreEqual(true, postEngineStartStatus);
            Assert.AreEqual(false, postEngineStopStatus);
            Assert.AreEqual("Engine Started: False", engineAboutPreStart);
            Assert.AreEqual("Engine Started: True", engineAboutPostStart);
        }

        [TestMethod]
        public void TestAirplane()
        {
            // Arrange
            boeing = new Airplane();
            int testHeight = 7;

            // Act
            string initialAbout = boeing.About();

            int planeGroundHeight = boeing.currentAltitude; // 0 ft

            // Test before starting engine
            boeing.FlyUp();
            int planeHeightPreStartUp = boeing.currentAltitude; // 0 ft

            boeing.FlyDown();
            int planeHeightPreStartDown = boeing.currentAltitude; // 0 ft

            bool EngineStatusPreStart = boeing.engine.isStarted;
            string TakeoffPreStart = boeing.TakeOff();

            boeing.StartEngine();
            bool EngineStatusPostStart = boeing.engine.isStarted;

            // Test after starting engine but before taking off

            boeing.FlyUp();
            int planeHeightPreTakeoffUp = boeing.currentAltitude; // 0 ft

            boeing.FlyDown();
            int planeHeightPreTakeOffDown = boeing.currentAltitude; // 0 ft

            // Test after starting engine and after taking off
            string confirmTakeOff = boeing.TakeOff();
            boeing.FlyUp();
            int planeHeightPostStartUp = boeing.currentAltitude; // 1000 ft

            boeing.FlyUp(35000);
            int planeHeightPostStartUpX = boeing.currentAltitude; // 36000 ft

            boeing.FlyUp(50000);
            int planeHeightPostStartUpMax = boeing.currentAltitude; // maxAltitude

            boeing.FlyDown();
            int planeHeightPostStartDown = boeing.currentAltitude; // maxAltitude - 1000 ft

            string planeFlightAbout = boeing.About();

            boeing.FlyDown(50000);
            int planeHeightPostStartDownMax = boeing.currentAltitude; // same as above

            boeing.FlyDown(5000);
            int planeHeightPostStartDownX = boeing.currentAltitude; // maxAltitude - 6000 ft
            
            boeing.StopEngine();
            bool EngineStatusPostStop = boeing.engine.isStarted;

            string planeMidflightEngineOff = boeing.About();

            boeing.FlyDown(boeing.currentAltitude);
            bool planeLand = boeing.isFlying;

            // Assert
            Assert.AreEqual("This " + boeing.ToString() + " has a max altitude of " + boeing.maxAltitude + " ft.\n" +
                "It's current altitude is " + "0 ft.\n" +
                boeing.ToString() + "Engine is started = False", initialAbout);

            Assert.AreEqual(0, planeGroundHeight);
            Assert.AreEqual(0, planeHeightPreStartUp);
            Assert.AreEqual(0, planeHeightPreStartDown);
            Assert.AreEqual(false, EngineStatusPreStart);
            Assert.AreEqual(boeing.ToString() + " cannot fly, its' engine is not started.", TakeoffPreStart);
            Assert.AreEqual(true, EngineStatusPostStart);

            Assert.AreEqual(0, planeHeightPreTakeoffUp);
            Assert.AreEqual(0, planeHeightPreTakeOffDown);

            Assert.AreEqual(boeing.ToString() + " is flying.", confirmTakeOff);
            Assert.AreEqual(1000, planeHeightPostStartUp);
            Assert.AreEqual(36000, planeHeightPostStartUpX);
            Assert.AreEqual(boeing.maxAltitude, planeHeightPostStartUpMax);
            Assert.AreEqual(boeing.maxAltitude - 1000, planeHeightPostStartDown);

            Assert.AreEqual("This " + boeing.ToString() + " has a max altitude of " + boeing.maxAltitude + " ft.\n" +
                "It's current altitude is " + (boeing.maxAltitude - 1000) + " ft.\n" +
                boeing.ToString() + "Engine is started = True", planeFlightAbout);

            Assert.AreEqual(boeing.maxAltitude - 1000, planeHeightPostStartDownMax);
            Assert.AreEqual(boeing.maxAltitude - 6000, planeHeightPostStartDownX);
            Assert.AreEqual(false, EngineStatusPostStop);
            Assert.AreEqual("This " + boeing.ToString() + " has a max altitude of " + boeing.maxAltitude + " ft.\n" +
                "It's current altitude is " + (boeing.maxAltitude - 6000) + " ft.\n" +
                boeing.ToString() + "Engine is started = False", planeMidflightEngineOff);

            Assert.AreEqual(false, planeLand);

        }

        [TestMethod]
        public void TestToyPlane()
        {
            // Arrange

            toy = new ToyPlane();

            // Act

            string initialAbout = toy.About();

            int planeGroundHeight = toy.currentAltitude; // 0 ft
            bool planePreWindUp = toy.isWoundUp;

            // Test before winding up or starting engine
            toy.FlyUp();
            int planeHeightPreStartUp = toy.currentAltitude; // 0 ft

            toy.FlyDown();
            int planeHeightPreStartDown = toy.currentAltitude; // 0 ft

            bool EngineStatusPreStart = toy.engine.isStarted;
            string TakeoffPreStart = toy.TakeOff();

            // Test after winding up but before starting engine
            toy.WindUp();
            bool planePostWindUp = toy.isWoundUp;

            toy.FlyUp();
            int planeHeightPreWindUp = toy.currentAltitude;

            toy.FlyDown();
            int planeHeightPreWindDown = toy.currentAltitude;

            // Test after starting engine but before taking off
            toy.StartEngine();
            bool EngineStatusPostStart = toy.engine.isStarted;

            toy.FlyUp();
            int planeHeightPreTakeoffUp = toy.currentAltitude; // 0 ft

            toy.FlyDown();
            int planeHeightPreTakeOffDown = toy.currentAltitude; // 0 ft

            // Test after starting engine and after taking off
            string confirmTakeOff = toy.TakeOff();
            toy.FlyUp();
            int planeHeightPostStartUp = toy.currentAltitude; // 10 ft

            toy.FlyUp(20);
            int planeHeightPostStartUpX = toy.currentAltitude; // 30 ft

            toy.FlyUp(50000);
            int planeHeightPostStartUpMax = toy.currentAltitude; // maxAltitude

            toy.FlyDown();
            int planeHeightPostStartDown = toy.currentAltitude; // maxAltitude - 10 ft

            string planeFlightAbout = toy.About();

            toy.FlyDown(50000);
            int planeHeightPostStartDownMax = toy.currentAltitude; // same as above

            toy.FlyDown(15);
            int planeHeightPostStartDownX = toy.currentAltitude; // maxAltitude - 25 ft

            toy.StopEngine();
            bool EngineStatusPostStop = toy.engine.isStarted;

            string planeMidflightEngineOff = toy.About();

            toy.FlyDown(toy.currentAltitude);
            bool planeLand = toy.isFlying;

            // Assert
            Assert.AreEqual("This " + toy.ToString() + " has a max altitude of " + toy.maxAltitude + " ft.\n" +
                "It's current altitude is " + "0 ft.\n" +
                toy.ToString() + "Engine is started = False", initialAbout);

            Assert.AreEqual(0, planeGroundHeight);
            Assert.AreEqual(0, planeHeightPreStartUp);
            Assert.AreEqual(0, planeHeightPreStartDown);
            Assert.AreEqual(EngineStatusPreStart, false);
            Assert.AreEqual(toy.ToString() + " cannot fly, its' engine is not started.", TakeoffPreStart);
            Assert.AreEqual(true, EngineStatusPostStart);

            Assert.AreEqual(true, planePostWindUp);
            Assert.AreEqual(0, planeHeightPreWindUp);
            Assert.AreEqual(0, planeHeightPreWindDown);

            Assert.AreEqual(0, planeHeightPreTakeoffUp);
            Assert.AreEqual(0, planeHeightPreTakeOffDown);

            Assert.AreEqual(toy.ToString() + " is flying.", confirmTakeOff);
            Assert.AreEqual(10, planeHeightPostStartUp);
            Assert.AreEqual(30, planeHeightPostStartUpX);
            Assert.AreEqual(toy.maxAltitude, planeHeightPostStartUpMax);
            Assert.AreEqual(toy.maxAltitude - 10, planeHeightPostStartDown);

            Assert.AreEqual("This " + toy.ToString() + " has a max altitude of " + toy.maxAltitude + " ft.\n" +
                "It's current altitude is " + (toy.maxAltitude - 10) + " ft.\n" +
                toy.ToString() + "Engine is started = True", planeFlightAbout);

            Assert.AreEqual(toy.maxAltitude - 10, planeHeightPostStartDownMax);
            Assert.AreEqual(toy.maxAltitude - 25, planeHeightPostStartDownX);
            Assert.AreEqual(false, EngineStatusPostStop);
            Assert.AreEqual("This " + toy.ToString() + " has a max altitude of " + toy.maxAltitude + " ft.\n" +
                "It's current altitude is " + (toy.maxAltitude - 25) + " ft.\n" +
                toy.ToString() + "Engine is started = False", planeMidflightEngineOff);

            Assert.AreEqual(false, planeLand);

        }

        [TestMethod]
        public void TestHeli()
        {
            apache = new Helicopter();
            int testHeight = 87;
            TestAerial(apache, testHeight);
        }

        [TestMethod]
        public void TestDrone()
        {
            uav = new Drone();
            int testHeight = 17;
            TestAerial(uav, testHeight);
        }

        [TestMethod]
        void TestAerial(AerialVehicle aerial, int testControlHeight)
        {
            //Arrange
            if (aerial == null)
            {
                // Simply give aerial a default aerial Vehicle type in case nothing was passed
                aerial = new Drone();
            }

            // Act
            string initialAbout = aerial.About();

            int planeGroundHeight = aerial.currentAltitude; // 0 ft

            // Test before starting engine
            aerial.FlyUp();
            int planeHeightPreStartUp = aerial.currentAltitude; // 0 ft

            aerial.FlyDown();
            int planeHeightPreStartDown = aerial.currentAltitude; // 0 ft

            bool EngineStatusPreStart = aerial.engine.isStarted;
            string TakeoffPreStart = aerial.TakeOff();

            aerial.StartEngine();
            bool EngineStatusPostStart = aerial.engine.isStarted;

            // Test after starting engine but before taking off

            aerial.FlyUp();
            int planeHeightPreTakeoffUp = aerial.currentAltitude; // 0 ft

            aerial.FlyDown();
            int planeHeightPreTakeOffDown = aerial.currentAltitude; // 0 ft

            // Test after starting engine and after taking off
            string confirmTakeOff = aerial.TakeOff();
            aerial.FlyUp();
            int planeHeightPostStartUp = aerial.currentAltitude; // 1000 ft

            aerial.FlyUp(testControlHeight);
            int planeHeightPostStartUpX = aerial.currentAltitude; // X ft

            aerial.FlyUp(50000);
            int planeHeightPostStartUpMax = aerial.currentAltitude; // maxAltitude

            aerial.FlyDown();
            int planeHeightPostStartDown = aerial.currentAltitude; // maxAltitude - 1000 ft

            string planeFlightAbout = aerial.About();

            aerial.FlyDown(50000);
            int planeHeightPostStartDownMax = aerial.currentAltitude; // same as above

            aerial.FlyDown(testControlHeight);
            int planeHeightPostStartDownX = aerial.currentAltitude; // maxAltitude - 6000 ft

            aerial.StopEngine();
            bool EngineStatusPostStop = aerial.engine.isStarted;

            string planeMidflightEngineOff = aerial.About();

            aerial.FlyDown(aerial.currentAltitude);
            bool planeLand = aerial.isFlying;

            // Assert
            Assert.AreEqual("This " + aerial.ToString() + " has a max altitude of " + aerial.maxAltitude + " ft.\n" +
                "It's current altitude is " + "0 ft.\n" +
                aerial.ToString() + "Engine is started = False", initialAbout);

            Assert.AreEqual(0, planeGroundHeight);
            Assert.AreEqual(0, planeHeightPreStartUp);
            Assert.AreEqual(0, planeHeightPreStartDown);
            Assert.AreEqual(false, EngineStatusPreStart);
            Assert.AreEqual(aerial.ToString() + " cannot fly, its' engine is not started.", TakeoffPreStart);
            Assert.AreEqual(true, EngineStatusPostStart);

            Assert.AreEqual(0, planeHeightPreTakeoffUp);
            Assert.AreEqual(0, planeHeightPreTakeOffDown);

            Assert.AreEqual(aerial.ToString() + " is flying.", confirmTakeOff);

            if(this.Equals(uav))
            {
                Assert.AreEqual(100, planeHeightPostStartUp);
                Assert.AreEqual(117, planeHeightPostStartUpX);
                Assert.AreEqual(aerial.maxAltitude, planeHeightPostStartUpMax);
                Assert.AreEqual(aerial.maxAltitude - 100, planeHeightPostStartDown);

                Assert.AreEqual("This " + aerial.ToString() + " has a max altitude of " + aerial.maxAltitude + " ft.\n" +
                    "It's current altitude is " + (aerial.maxAltitude - 100) + " ft.\n" +
                    aerial.ToString() + "Engine is started = True", planeFlightAbout);

                Assert.AreEqual(aerial.maxAltitude - 100, planeHeightPostStartDownMax);
                Assert.AreEqual(aerial.maxAltitude - 100 - testControlHeight, planeHeightPostStartDownX);

                Assert.AreEqual("This " + aerial.ToString() + " has a max altitude of " + aerial.maxAltitude + " ft.\n" +
                    "It's current altitude is " + (aerial.maxAltitude - 200) + " ft.\n" +
                    aerial.ToString() + "Engine is started = False", planeMidflightEngineOff);
            }
            else if(this.Equals(apache))
            {
                Assert.AreEqual(1000, planeHeightPostStartUp);
                Assert.AreEqual(1087, planeHeightPostStartUpX);
                Assert.AreEqual(aerial.maxAltitude, planeHeightPostStartUpMax);
                Assert.AreEqual(aerial.maxAltitude - 1000, planeHeightPostStartDown);

                Assert.AreEqual("This " + aerial.ToString() + " has a max altitude of " + aerial.maxAltitude + " ft.\n" +
                    "It's current altitude is " + (aerial.maxAltitude - 1000) + " ft.\n" +
                    aerial.ToString() + "Engine is started = True", planeFlightAbout);

                Assert.AreEqual(aerial.maxAltitude - 1000, planeHeightPostStartDownMax);
                Assert.AreEqual(aerial.maxAltitude - 1000 - testControlHeight, planeHeightPostStartDownX);

                Assert.AreEqual("This " + aerial.ToString() + " has a max altitude of " + aerial.maxAltitude + " ft.\n" +
                    "It's current altitude is " + (aerial.maxAltitude - 6000) + " ft.\n" +
                    aerial.ToString() + "Engine is started = False", planeMidflightEngineOff);
            }
            
            Assert.AreEqual(false, EngineStatusPostStop);

            Assert.AreEqual(false, planeLand);

        }

        [TestMethod]
        public void TestAirport()
        {
            // Arrange
            terminal = new Airport("115");
            boeing = new Airplane();
            apache = new Helicopter();
            uav = new Drone();
            toy = new ToyPlane();

            List<AerialVehicle> testVehicles = new List<AerialVehicle>()
            {
                boeing,
                apache,
                uav,
                toy
            };

            // Act
            boeing.StartEngine();
            boeing.TakeOff();
            boeing.FlyUp();
            foreach(AerialVehicle a in testVehicles)
            {
                a.StartEngine();
                a.TakeOff();
                a.FlyUp();
            }
            

            string landPlane = terminal.Land(boeing);
            string landVehicles = terminal.Land(testVehicles);
            string takeoffPlane = terminal.TakeOff(boeing);
            string takeoffAll = terminal.AllTakeOff();







            // Assert
            Assert.AreEqual(terminal.AirportCode, "115");
            Assert.AreEqual(terminal.MaxVehicles, 5);
            Assert.AreEqual(takeoffPlane, boeing.ToString() + " has taken off. ");
            Assert.AreEqual(takeoffAll, testVehicles[0].ToString() + " has taken off. " + testVehicles[1].ToString() + " has taken off. " +
                testVehicles[2].ToString() + " has taken off. " + testVehicles[3].ToString() + " has taken off. ");
            Assert.AreEqual(landPlane, boeing.ToString() + " has landed. ");
            Assert.AreEqual(landVehicles, testVehicles[0].ToString() + " has landed. " + testVehicles[1].ToString() + " has landed. " +
                testVehicles[2].ToString() + " has landed. " + testVehicles[3].ToString() + " has landed. ");


            terminal = new Airport("ORD", 48);
            Assert.AreEqual("ORD", terminal.AirportCode);
            Assert.AreEqual(48, terminal.MaxVehicles);
        }
    }
}
