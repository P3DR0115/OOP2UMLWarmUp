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


            // Assert


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
    }
}
