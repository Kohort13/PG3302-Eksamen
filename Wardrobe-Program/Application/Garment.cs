using System;

namespace Wardrobe_Program{
    public class Garment{
        public string Name{get;set;}
        public int Price{get;set;}
        public string Size{get;set;}
        public List<Season> Seasons{get;set;}
        public List<Material> Materials {get;set;}
        public string Notes{get;set;}
    }
}
