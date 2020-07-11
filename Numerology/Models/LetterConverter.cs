using System.Collections.Immutable;
using System.Linq;

namespace Numerology.Models
{
    public class LetterConverter : ILetterConverter
    {
        public LetterConverter()
        {
            _alphabet = GetAlphabet();
            _significantDigits = GetSignificantDigits();
        }

        private readonly ImmutableArray<char> _alphabet;

        private ImmutableArray<char> GetAlphabet()
        {
            return "абвгдеёжзийклмнопрстуфхцчшщъыьэюя"
                .ToImmutableArray();
        }

        private readonly ImmutableArray<int> _significantDigits;

        private ImmutableArray<int> GetSignificantDigits()
        {
            return Enumerable.Range(1, 9)
                .ToImmutableArray();
        }

        public int GetLetterDigit(char c)
        {
            var index = _alphabet.IndexOf(c);
            if (index == -1) return 0;
            var significantDigitIndex = index % _significantDigits.Length;
            return _significantDigits[significantDigitIndex];
        }
    }
}
