using System.Linq;

namespace Numerology.Models
{
    public class StringAdder : IStringAdder
    {
        public StringAdder(ILetterConverter letterConverter)
        {
            _letterConverter = letterConverter;
        }

        private readonly ILetterConverter _letterConverter;

        public string Add(string str)
        {
            if (str == "")
                return "";
            return SumStringInt(str).ToString();
        }

        private int SumStringInt(string str)
        {
            return str
                .ToLower()
                .Select(_letterConverter.GetLetterDigit)
                .Sum();
        }
    }
}
