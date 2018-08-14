namespace UnitTestSamples
{
    public class PersonMapper
    {
        public PersonInfo Map(Person person)
        {
            return new PersonInfo
            {
                Name = person.FirstName +" " + person.LastName,
                DateOfBirth = person.DateOfBirth.ToShortDateString()
            };
        }
    }

    public class PersonInfo
    {
        public string Name { get; set; }
        public string DateOfBirth { get; set; }
    }
}