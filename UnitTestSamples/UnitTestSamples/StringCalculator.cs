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

        public string ToNumbersString(int x, int y)
        {
            return string.Format("{0},{1}", x, y);
        }
    }
}
