using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestSamples.Tests
{
    [TestClass]
    public class StringCalculatorTests
    {
        //Better
        [TestMethod]
        public void Add_EmptyString_ReturnsZero()
        {
            var calculator = new StringCalculator();
            
            int result = calculator.Add("");

            Assert.AreEqual(0, result);
        }
        
        //Bad
        [TestMethod]
        public void TestEmptyString()
        {
            var calculator = new StringCalculator();
            
            int result = calculator.Add("");

            Assert.AreEqual(0, result);
        }
        
        //Bad
        [TestMethod]
        public void Add_BigNumber_ThrowsException()
        {
            var stringCalculator = new StringCalculator();

            void Actual() => stringCalculator.Add("1001");

            AssertThat.Throws<OverflowException>(Actual);
        }
        
        //Better
        [TestMethod]
        void Add_MaximumSumResult_ThrowsOverflowException()
        {
            var stringCalculator = new StringCalculator();
            const string maximumResult = "1001";

            void Actual() => stringCalculator.Add(maximumResult);

            AssertThat.Throws<OverflowException>(Actual);
        }
    }
}
