using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace L03Merged
{
    internal class Password
    {
        public static class HealthPattern
        {
            public static Regex containsLatinLowercase = new Regex(@"[a-z]");
            public static Regex containsLatinUppercase = new Regex(@"[A-Z]");
            public static Regex containsNumerals = new Regex(@"\d");
            public static Regex containsSpecialSymbols = new Regex(@"\W");
            public static Regex isGreaterThan = new Regex(@".{8,}"); // рабочее 
        }
        private string pass = "0";

        public string Pass { get; set; }

        public Password(string password) { this.pass = password; }

        public string GetHealth()
        {
            int healthScore = 0;
            if (HealthPattern.isGreaterThan.IsMatch(this.pass))
            {
                healthScore++;
                if (HealthPattern.containsLatinLowercase.IsMatch(this.pass))
                {
                    healthScore++;
                    if (HealthPattern.containsLatinUppercase.IsMatch(this.pass))
                    {
                        healthScore++;
                        if (HealthPattern.containsNumerals.IsMatch(this.pass))
                        {
                            healthScore++;
                            if (HealthPattern.containsSpecialSymbols.IsMatch(this.pass))
                            {
                                healthScore++;
                            }
                        }
                    }
                }
            }

            string health;
            switch (healthScore)
            {
                case 0: return health = "Very weak";
                case 1: return health = "Weak";
                case 2: return health = "Middle strength";
                case 3: return health = "Safe";
                case 4: return health = "Very safe";
                case 5: return health = "Maximum safety";
                default: return health = "Unknown strength";
            }
        }
    }


}
