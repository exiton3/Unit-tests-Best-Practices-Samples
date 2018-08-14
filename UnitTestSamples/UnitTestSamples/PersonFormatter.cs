namespace UnitTestSamples
{
    public class PersonFormatter
    {
        public string Format(Person person)
        {
            return string.Format("{0}-{1}", person.FirstName, person.LastName);
        }
    }
}