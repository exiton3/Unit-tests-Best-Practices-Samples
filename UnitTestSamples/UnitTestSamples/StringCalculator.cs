namespace UnitTestSamples
{
    public class StringCalculator
    {
        public int Add(string inputNumbers)
        {
            if (string.IsNullOrEmpty(inputNumbers))
            {
                return 0;
            }
            
            return int.Parse(inputNumbers);
        }
    }
}
