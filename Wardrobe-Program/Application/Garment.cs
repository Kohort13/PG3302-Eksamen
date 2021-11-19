using System.Collections.Generic;

namespace Wardrobe_Program
{
    public abstract class Garment : IGarment
    {
        public long Id { get; set; }
        public string Subtype { get; set; }
        public float Price { get; set; }
        public string Size { get; set; } = "One-size";
        public string Brand { get; set; }
        public List<string> Seasons { get; set; } = new();
        public List<Material> Materials { get; set; } = new();
        public string Note { get; set; }

        public override string ToString() {
            string type = GetType().FullName;
            type = type.Substring(type.LastIndexOf('.')+1);
	        return $"Item ID: {Id} - Type: {type} - Subtype: {Subtype} - Purchase price: {Price} " +
                   $"- Size: {Size} - Brand: {Brand} - Seasons: {Utils.ListToStringWithSeparator(Seasons, ",")} " +
                   $"- Materials: {Utils.ListToStringWithSeparator(Materials, ",")} - Notes: {Note}";
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
