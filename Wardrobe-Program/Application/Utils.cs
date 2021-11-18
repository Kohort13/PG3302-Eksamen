using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Wardrobe_Program
{
    public class Utils
    {
        public static string ListToStringWithSeparator<T>(List<T> stringToSplit, string separator) {
            string result = "";
            for (int i = 0; i < stringToSplit.Count; i++) {
                result += (i < stringToSplit.Count -1) ? $"{stringToSplit[i]?.ToString()}{separator} " : stringToSplit[i].ToString();
            }

            return result;
        }

        public static T PickOne<T>(Collection<T> options) {
            return options[new Random().Next(options.Count)];
        }
    }
}