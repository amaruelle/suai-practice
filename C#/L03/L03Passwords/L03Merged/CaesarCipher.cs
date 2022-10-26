using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L03Merged
{
    internal class CaesarCipher : Password
    {
        public char[] _alphaUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        public char[] _alphaLower = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        public char[] _numeric = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
        int displacement;
        public CaesarCipher(string password, int displacement) : base(password)
        {
            this.displacement = displacement;
            this.Pass = password;
        }

        public char EncipherSymbol(char ch, int displacement)
        {
            if (!char.IsLetter(ch))
            {
                return ch;
            }

            char d = char.IsUpper(ch) ? 'A' : 'a';
            return (char)((((ch + displacement) - d) % 26) + d);
        }

        public string Decipher(string str, int displacement)
        {
            return Encipher(str, 26 - displacement);
        }

        public string Encipher(string str, int displacement)
        {
            string output = string.Empty;
            foreach (char ch in str) output += EncipherSymbol(ch, displacement);

            return output;
        }
    }
}
