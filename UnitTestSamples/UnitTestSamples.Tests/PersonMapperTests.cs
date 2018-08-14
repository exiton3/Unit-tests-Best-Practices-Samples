using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestSamples.Tests
{
    [TestClass]
    public class PersonMapperTests
    {
        private PersonMapper _mapper;

        [TestInitialize]
        public void TestInit()
        {
            _mapper = new PersonMapper();
        }

        [TestMethod]
        public void Map_FirstLastNameSet_SetFullNameInPersonInfo()
        {
            var person = new Person
            {
                FirstName = "Bob",
                LastName = "Martin",
                DateOfBirth = new DateTime(1960, 06, 21)
            };

            var personInfo = _mapper.Map(person);

            Assert.AreEqual("Bob Martin", personInfo.Name);
        }

        [TestMethod]
        public void Map_DateOfBirth_SetDateOfBirth()
        {
            var person = new Person
            {
                FirstName = "Bob",
                LastName = "Martin",
                DateOfBirth = new DateTime(1960,06,21)
            };

            var personInfo = _mapper.Map(person);

            Assert.AreEqual("21/06/1960", personInfo.DateOfBirth);
        }

        [TestMethod]
        public void Map_DateOfBirth_SetDateOfBirth2()
        {
            var person = MakePerson(x => x.DateOfBirth = new DateTime(1960, 06, 21));

            var personInfo = _mapper.Map(person);

            
            Assert.AreEqual("21/06/1960", personInfo.DateOfBirth);
        }


        [TestMethod]
        public void Map_FirstLastNameSet_SetFullNameInPersonInfo2()
        {
            var person = MakePerson(x =>
            {
                x.FirstName = "Bob";
                x.LastName = "Martin";
            });

            var personInfo = _mapper.Map(person);

            Assert.AreEqual("Bob Martin", personInfo.Name);
        }

        private static Person MakePerson(Action<Person> action = null)
        {
            var person = new Person
            {
                FirstName = "Bob",
                LastName = "Martin",
                DateOfBirth = new DateTime(1960, 06, 21)
            };
            action?.Invoke(person);

            return person;
        }
    }
}