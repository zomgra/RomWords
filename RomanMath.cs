using System;
using System.Linq;
using System.Collections.Generic;
namespace RymWords
{
    public class RomanMath
    {
        private static Dictionary<char, int> _keys = new Dictionary<char, int>()
        {
            {'I',1 },
            {'V',5 },
            {'X', 10 },
            {'L', 50 },
            {'C', 100 },
            {'D', 500 },
            {'M', 1000 },
        };

        public static int Parce(string roman)
        {
            if (!Validation(roman)) Console.WriteLine("Вы ввели не правильные буквы");

            int result = 0;
            for (int i = 0; i < roman.Length; i++)
            {
                if (i + 1 < roman.Length && IsSubtraction(roman[i], roman[i + 1]))
                    result -= _keys[roman[i]];
                else
                    result += _keys[roman[i]];
            }
            return result;
        }

        private static bool Validation(string roman)
        {
            foreach (char item in roman)
            {
                if (!_keys.ContainsKey(item)) return false;
            }
            return true;
        }
        private static bool IsSubtraction(char c1, char c2) => _keys[c1] < _keys[c2];
    }
}
