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

            if (displacement < 0)
            {
                return DecipherSymbol(ch, Math.Abs(displacement));
            }

            char[] final = char.IsUpper(ch) ? _alphaUpper : _alphaLower;
            displacement %= 26;

            if (final == _alphaUpper)
            {
                foreach (char c in final)
                {
                    if (c == ch)
                    {
                        return (char)(ch + displacement > (final[final.Length - 1]) ? final[0] + displacement - (final[final.Length - 1] - ch + 1) : ch + displacement);
                    }
                }
            }
            else if (final == _alphaLower)
            {
                foreach (char c in final)
                {
                    if (c == ch)
                    {
                        return (char)(ch + displacement > (final[final.Length - 1]) ? final[0] + displacement - (final[final.Length - 1] - ch + 1) : ch + displacement);
                    }
                }
            }
            return (char)(ch);
        }

        public char DecipherSymbol(char ch, int displacement)
        {
            char[] final = char.IsUpper(ch) ? _alphaUpper : _alphaLower;

            if (displacement < 0)
            {
                return EncipherSymbol(ch, Math.Abs(displacement));
            }

            displacement %= 26;

            if (final == _alphaUpper)
            {
                foreach (char c in final)
                {
                    if (c == ch)
                    {
                        return (char)(ch - displacement < final[0] ? final[final.Length - 1] + 1 - (displacement - (ch - final[0])) : ch - displacement);
                    }
                }
            }

            if (final == _alphaLower)
            {
                foreach (char c in final)
                {
                    if (c == ch)
                    {
                        return (char)(ch - displacement < final[0] ? final[final.Length - 1] + 1 - (displacement - (ch - final[0])) : ch - displacement);
                    }
                }
            }

            return (char)(ch);
        }

        public string Decipher(string str, int displacement)
        {
            displacement %= 26;
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
