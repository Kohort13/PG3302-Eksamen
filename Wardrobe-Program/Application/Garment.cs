using System;
using System.Collections.Generic;

namespace Wardrobe_Program
{
    public abstract class Garment
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Size { get; set; } = "One-size";
        public string Brand { get; set; }
        public List<string> Seasons { get; set; } = new();
        public List<Material> Materials { get; set; } = new();
        public string Notes { get; set; }

        public override string ToString() {
	        return $"Item ID: {Id} - Name: {Name} - Purchase price: {Price} " +
                   $"- Size: {Size} - Brand: {Brand} - Seasons: {SeasonsAsString()} " +
                   $"- Materials: {Materials} - Notes: {Notes}";
        }

        private string SeasonsAsString() {
            return ListToStringWithSeparator(Seasons, ",");
        }
        
        private string MaterialsAsString() {
            return ListToStringWithSeparator(Materials, ",");
        }

        private static string ListToStringWithSeparator<T>(List<T> stringToSplit, string separator) {
            string result = "";
            for (int i = 0; i < stringToSplit.Count; i++) {
                result += (i < stringToSplit.Count -1) ? $"{stringToSplit[i]?.ToString()}{separator} " : stringToSplit[i].ToString();
            }

            return result;
        }
    }

    #region GARMENT CONCRETE CLASSES

    public class Shoe : Garment
    {
        
    }

    public class Top : Garment
    {
        
    }

    public class Bottom : Garment
    {
        
    }

    public class Accessory : Garment
    {
        
    }

    public class Outerwear : Garment
    {
        
    }

    #endregion
}
