using System;
using System.Collections.Generic;

namespace Wardrobe_Program
{
    public class Command
    {
        public string Keyword { get; set; } = "";
        public Dictionary<string, string> Parameters { get; set; } = new();

        //change-price -id 444 -v 256
        public Command(string userInput) {
            var firstSpace = userInput.IndexOf(" ", StringComparison.Ordinal);
            Parameters = new Dictionary<string, string>();
            if (firstSpace > 0) {
                var parametersAsList = new List<string>(userInput.Substring(firstSpace + 1).Split(" "));
                // {"-id", "444", "-v", "256"}
                for (int i = 0; i < parametersAsList.Count; i++) {
                    if (parametersAsList[i].StartsWith('-')) {
                        int nextElementIndex = i + 1 >= parametersAsList.Count ? i : i + 1;
                        var value = !parametersAsList[nextElementIndex].StartsWith("-") ? parametersAsList[nextElementIndex] : "";
                        Parameters.Add(parametersAsList[i], value);
                    }
                }
            }

            Keyword = userInput.Substring(0, firstSpace > 0 ? firstSpace : userInput.Length);
        }

        /// <summary>
        /// Empty default constructor, DO NOT USE UNLESS IN Controller.GetAllowedCommandFormat()
        /// </summary>
        public Command() {
            
        }
    }
}
