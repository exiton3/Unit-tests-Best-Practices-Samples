using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestSamples.Tests
{
    [TestClass]
    public class PersonFormatterTests
    {

        [TestMethod]
        public void Format_PersonWithFirstAndLastName_StringFirstAndLastNameWithDashBetween()
        {
            Person person = new Person
            {
                FirstName = "Bob",
                LastName = "Martin"
            };

            PersonFormatter formatter = new PersonFormatter();

            var result = formatter.Format(person);

            Assert.AreEqual(s);
        }
    }
}