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
        
        //Bad
        [TestMethod]
        public void Add_MultipleNumbers_ReturnsCorrectResults()
        {
            var stringCalculator = new StringCalculator();
            var expected = 0;
            var testCases = new[]
            {
                "0,0,0",
                "0,1,2",
                "1,2,3"
            };

            foreach (var test in testCases)
            {
                Assert.AreEqual(expected, stringCalculator.Add(test));
                expected += 3;
            }

        }
        
        
        [DataRow("0,0,0", 0)]
        [DataRow("0,1,2", 3)]
        [DataRow("1,2,3", 6)]
        [DataTestMethod]
        public void Add_MultipleNumbers_ReturnsSumOfNumbers(string input, int expected)
        {
            var stringCalculator = new StringCalculator();

            var actual = stringCalculator.Add(input);

            Assert.AreEqual(expected, actual);
        }

        
        [TestMethod]
        public void ToNumbersString_TwoSimpleNumbers_StringNumbersWithCommaBetweenb()
        {
            var stringCalculator = new StringCalculator();

            var result = stringCalculator.ToNumbersString(1, 2);

            Assert.AreEqual(string.Format("{0},{1}", 1, 2), result);
        }

        [TestMethod]
        public void ToNumbersString_TwoSimpleNumbers_StringNumbersWithCommaBetween()
        {
            var stringCalculator = new StringCalculator();

            var result = stringCalculator.ToNumbersString(1, 2);

            Assert.AreEqual("1,2", result);
        }
    }
}
