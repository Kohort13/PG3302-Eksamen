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
	        return $"Item ID: {Id} - Name: {Name} - Purchase price: {Price} - Size: {Size} - Brand: {Brand} - Seasons: {Seasons} - Materials: {Materials} - Notes: {Notes}";
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
