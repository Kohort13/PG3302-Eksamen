using System;
using System.Collections.Generic;

namespace Wardrobe_Program
{
    public abstract class Garment
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public string Size { get; set; } = "One-size";
        public string Brand { get; set; }
        public List<string> Seasons { get; set; }
        public List<Material> Materials { get; set; }
        public string Notes { get; set; }
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
