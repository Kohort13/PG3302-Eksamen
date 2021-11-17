using System;
using System.Collections.Generic;

namespace Wardrobe_Program
{
    public class Command
    {
        public string Keyword { get; set; } = "";
        public Dictionary<string, string> Parameters { get; set; } = new();

        //change-price -id 444 -v 256 -su -g
        public Command(string userInput) {
            var firstSpace = userInput.IndexOf(" ", StringComparison.Ordinal);
            Parameters = new Dictionary<string, string>();
            if (firstSpace > 0) {
                var parametersAsList = new List<string>(userInput.Substring(firstSpace + 1).Split(" "));
                //Når list-element starter på -, legg til ny key. Frem til du treffer en ny -, legg til påfølgende list-element til value for den key'en

                //Splits parameters into keys and values. All strings after one that starts with a '-' will be handled as one value

                for (int i = 0; i < parametersAsList.Count;) {
                    string key = "";
                    string value = "";
                    var current = parametersAsList[i];

                    if (i < parametersAsList.Count)
                    {
                        do {
                            if (current.StartsWith('-')) {
                                key = current;
                                value = "";
                                i++;
                            } else {
                                value += current + " ";
                                i++;
                            }
                            current = (i < parametersAsList.Count) ? parametersAsList[i] : parametersAsList[i - 1];

                        } while (i + 1 <= parametersAsList.Count && !current.StartsWith('-'));

                        Parameters.TryAdd(key, value.Trim());
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
