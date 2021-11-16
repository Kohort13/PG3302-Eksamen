using System;
using System.Collections.Generic;

namespace Wardrobe_Program
{
    public class Command
    {
        public string CommandComponent { get; set; }
        public List<string> Parameters { get; set; }

        public Command(string userInput) {
            var firstSpace = userInput.IndexOf(" ");
            if (firstSpace > 0) {
                Parameters = new List<string>(userInput.Substring(firstSpace + 1).Split(" "));
            }

            Parameters ??= new List<string>();
            CommandComponent = userInput.Substring(0, firstSpace > 0 ? firstSpace : userInput.Length);
        }
    }
}
