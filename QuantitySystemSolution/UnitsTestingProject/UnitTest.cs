﻿using QuantitySystem.Units;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using QuantitySystem.Quantities.BaseQuantities;

using QuantitySystem.Units.Metric.SI;
using QuantitySystem.Units.English.Imperial;
using QuantitySystem.Quantities;
using QuantitySystem.Quantities.DimensionlessQuantities;

namespace UnitsTestingProject
{
    
    
    /// <summary>
    ///This is a test class for UnitTest and is intended
    ///to contain all UnitTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UnitTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for GetSIUnitTypeOf
        ///</summary>
        [TestMethod()]
        public void GetSIUnitTypeOfTest()
        {
            Type quantityType = typeof(Length<>); // TODO: Initialize to an appropriate value

            Type expected = typeof(Metre); // TODO: Initialize to an appropriate value

            Type actual;
            actual = Unit.GetDefaultSIUnitTypeOf(quantityType);
            
            Assert.AreEqual(expected, actual);


            quantityType = typeof(Mass<>);
            expected = typeof(Gram);
            actual = Unit.GetDefaultSIUnitTypeOf(quantityType);

            Assert.AreEqual(expected, actual);



            quantityType = typeof(Area<>);
            expected = null;
            actual = Unit.GetDefaultSIUnitTypeOf(quantityType);

            Assert.AreEqual(expected, actual);



            quantityType = typeof(Length<double>);
            expected = typeof(Metre);
            actual = Unit.GetDefaultSIUnitTypeOf(quantityType);

            Assert.AreEqual(expected, actual);

            quantityType = typeof(Mass<int>);
            expected = typeof(Gram);
            actual = Unit.GetDefaultSIUnitTypeOf(quantityType);

            Assert.AreEqual(expected, actual);


            
        }

        /// <summary>
        ///A test for GetDefaultUnitTypeOf
        ///</summary>
        [TestMethod()]
        public void GetDefaultUnitTypeOfTest()
        {
            Type quantityType = typeof(AmountOfSubstance<>); // TODO: Initialize to an appropriate value
            
            string unitSystem = "metric.si"; // TODO: Initialize to an appropriate value

            
            Type expected = typeof(Mole); // TODO: Initialize to an appropriate value
            Type actual;
            actual = Unit.GetDefaultUnitTypeOf(quantityType, unitSystem);
        
            Assert.AreEqual(expected, actual);


            quantityType = typeof(Length<>);
            expected = typeof(Metre);

            actual = Unit.GetDefaultUnitTypeOf(quantityType, unitSystem);
            Assert.AreEqual(expected, actual);


            unitSystem = "imperial";
            expected = typeof(Foot);

            actual = Unit.GetDefaultUnitTypeOf(quantityType, unitSystem);
            Assert.AreEqual(expected, actual);


            quantityType = typeof(Volume<>);
            expected = typeof(Pint);

            actual = Unit.GetDefaultUnitTypeOf(quantityType, unitSystem);
            Assert.AreEqual(expected, actual);


            quantityType = typeof(Length<decimal>);
            expected = typeof(Foot);

            actual = Unit.GetDefaultUnitTypeOf(quantityType, unitSystem);
            Assert.AreEqual(expected, actual);

        }



        
        /// <summary>
        ///A test for GetThisUnitQuantity
        ///</summary>
        public void GetThisUnitQuantityTestHelper<T>()
        {

            Unit target = new Yard(); // TODO: Initialize to an appropriate value
            AnyQuantity<T> expected = new Length<T>(); // TODO: Initialize to an appropriate value
            
            AnyQuantity<T> actual;
            actual = target.GetThisUnitQuantity<T>();

            Assert.AreEqual(expected, actual);



            target = new Kelvin();

            expected = new Temperature<T>();

            actual = target.GetThisUnitQuantity<T>();

            Assert.AreEqual(expected, actual);

            
        }


        [TestMethod()]
        public void GetThisUnitQuantityTest()
        {
            GetThisUnitQuantityTestHelper<GenericParameterHelper>();
        }


        [TestMethod()]
        public void TestDynamicUnitCreationFlatUnits()
        {
            //when conducting this test, 
            // the type of quantity is sent to the Unit constructor
            // the return value should be the direct units of the passed Type
            //   otherwise the units will be expressed in the term of the base units.

            Unit unit = new Unit(typeof(Area<>));

            Assert.AreEqual("<m^2>", unit.Symbol);


            unit = new Unit(typeof(Force<>));

            Assert.AreEqual("<N>", unit.Symbol);


            unit = new Unit(typeof(Pressure<>));

            Assert.AreEqual("<Pa>", unit.Symbol);


            unit = new Unit(typeof(Viscosity<>));

            Assert.AreEqual("<kg/m.s>", unit.Symbol);

            unit = new Unit(typeof(Density<>));

            Assert.AreEqual("<kg/m^3>", unit.Symbol);


            unit = new Unit(typeof(Mass<>));
            Assert.AreEqual("<kg>", unit.Symbol);


            unit = new Unit(typeof(Angle<Double>));
            Assert.AreEqual("<rad>", unit.Symbol);

            unit = new Unit(typeof(SolidAngle<Double>));
            Assert.AreEqual("<sr>", unit.Symbol);

            unit = new Unit(typeof(Reynolds<>));
            Assert.AreEqual("<1>", unit.Symbol);


            unit = new Unit(typeof(Torque<>));
            Assert.AreEqual("<kg.m^2/s^2>", unit.Symbol);

            unit = new Unit(typeof(Energy<>));
            Assert.AreEqual("<J>", unit.Symbol);



        }



        [TestMethod()]
        public void TestDynamicUnitCreationQuantityUnits()
        {
            // this test is extracting the units in its derived symbols from the running 
            // instance of the quantity.


            Unit unit = new Unit(new Length<double>());

            Assert.AreEqual("<m>", unit.Symbol);

            unit = new Unit(new Area<double>());

            Assert.AreEqual("<m^2>", unit.Symbol);


            unit = new Unit(new Force<double>());

            Assert.AreEqual("<N>", unit.Symbol);

            unit = new Unit(new Volume<double>());

            Assert.AreEqual("<m^3>", unit.Symbol);

            unit = new Unit(new Density<double>());

            Assert.AreEqual("<kg/m^3>", unit.Symbol);

            unit = new Unit(new Pressure<double>());

            Assert.AreEqual("<Pa>", unit.Symbol);

            unit = new Unit(new Viscosity<double>());
            Assert.AreEqual("<Pa.s>", unit.Symbol);


            unit = new Unit(new Mass<double>());
            Assert.AreEqual("<kg>", unit.Symbol);

            unit = new Unit(new Angle<double>());
            Assert.AreEqual("<rad>", unit.Symbol);

            unit = new Unit(new Reynolds<double>());
            Assert.AreEqual("<kg.m/m^2.s.Pa.s>", unit.Symbol);


            unit = new Unit(new Torque<double>());
            Assert.AreEqual("<N.m>", unit.Symbol);

            unit = new Unit(new Energy<double>());
            Assert.AreEqual("<J>", unit.Symbol);


        }


        /// <summary>
        ///A test for PathToDefaultUnit
        ///</summary>
        [TestMethod()]
        public void PathToDefaultUnitTest()
        {

            //scenario 1: Mile To Foot

            UnitPath expected = new UnitPath();

            expected.Push(
                new UnitPathItem
                {
                    Unit = new Mile(),
                    Numerator = 1,
                    Denumenator=1
                }
                );

            expected.Push(
                new UnitPathItem
                {
                    Unit = new Yard(),
                    Numerator = 1760,
                    Denumenator = 1
                }
                );

            expected.Push(
                new UnitPathItem
                {
                    Unit = new Foot(),
                    Numerator = 3,
                    Denumenator = 1
                }
                );


            Mile mil = new Mile();

            UnitPath actual = mil.PathToDefaultUnit();
            

            Assert.AreEqual(expected, actual);



            Inch f = new Inch();
            UnitPath up = f.PathToDefaultUnit();
            Assert.AreEqual(1/12.0, up.ConversionFactor);


        }




        /// <summary>
        ///A test for PathFromDefaultUnit
        ///</summary>
        [TestMethod()]
        public void PathFromDefaultUnitTest()
        {

            //scenario 1: Mile To Foot

            UnitPath expected = new UnitPath();

            expected.Push(
                new UnitPathItem
                {
                    Unit = new Foot(),
                    Numerator = 1,
                    Denumenator=1
                }
                );

            expected.Push(
                new UnitPathItem
                {
                    Unit = new Yard(),
                    Numerator = 1, 
                    Denumenator= 3
                }
                );

            expected.Push(
                new UnitPathItem
                {
                    Unit = new Mile(),
                    Numerator = 1,
                    Denumenator= 1760
                }
                );


            Mile mil = new Mile();

            UnitPath actual = mil.PathFromDefaultUnit();

            Assert.AreEqual(expected, actual);

        }



        /// <summary>
        ///A test for PathFromUnit
        ///</summary>
        [TestMethod()]
        public void PathFromUnitTest()
        {

            double expected = 63360;

            Mile mil = new Mile();
            Inch i = new Inch();


            UnitPath actual = i.PathFromUnit(mil);


            Assert.AreEqual(expected, actual.ConversionFactor);

        }


        /// <summary>
        ///A test for PathToUnit
        ///</summary>
        [TestMethod()]
        public void PathToUnitTest()
        {

            double expected = 63360;

            Mile mil = new Mile();
            Inch i = new Inch();

            UnitPath actual = mil.PathToUnit(i);

            Assert.AreEqual(expected, actual.ConversionFactor);


            Gram g = new Gram();
            g.UnitPrefix = MetricPrefix.None;

            Gram Mg = new Gram();
            Mg.UnitPrefix = MetricPrefix.Mega;

            actual = g.PathToUnit(Mg);

            Assert.AreEqual(1e-6, actual.ConversionFactor);


            Metre mr = new Metre();

            actual = i.PathToUnit(mr);

            Assert.AreEqual(0.025400050800101596, actual.ConversionFactor);

            //now the idea is to make any combination of units to go to any combination of units
            Unit u = new Unit(QuantitySystem.QuantityDimension.ParseMLT("M1L0T-1"));
            Assert.AreEqual("<kg/s>", u.Symbol);

            
            
        }

        [TestMethod]
        public void RepetitiveUnits()
        {
            Time<double> t = 5;

            var t1 = t;

            var un = new Unit(t1);

            Assert.AreEqual("<s>",un.Symbol);

            var t2 = t * t * t * t * t * t;

            un = new Unit(t2);
            Assert.AreEqual("<s^6>", un.Symbol);



        }
    }
}