using System;
using System.Collections.Generic;

namespace Wardrobe_Program
{
    abstract class Garment
    {
        public string Name{get;set;}
        public int Price{get;set;}
        public string Size{get;set;} = "onesize";
        public List<string> Seasons{get;set;}
        public List<Material> Materials {get;set;}
        public string Notes{get;set;}
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
