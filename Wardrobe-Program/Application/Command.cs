using System;
using System.Collections.Generic;

namespace Wardrobe_Program
{
    public class Command
    {
        public string Keyword { get; set; }
        public Dictionary<string, string> Parameters { get; set; }

        //change-price -id 444 -v 256
        public Command(string userInput) {
            var firstSpace = userInput.IndexOf(" ");
            Parameters = new();
            if (firstSpace > 0) {
                var parametersAsList = new List<string>(userInput.Substring(firstSpace + 1).Split(" "));
                // {"-id", "444", "-v", "256"}
                for (int i = 0; i < parametersAsList.Count; i++) {
                    if (parametersAsList[i].StartsWith('-')) {
                        var value = !parametersAsList[i + 1].StartsWith("-") ? parametersAsList[i+1] : "";
                        Parameters.Add(parametersAsList[i], value);
                    }
                }
            }

            Keyword = userInput.Substring(0, firstSpace > 0 ? firstSpace : userInput.Length);
        }
    }
}
