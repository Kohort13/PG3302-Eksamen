using System.Collections.Generic;

namespace Wardrobe_Program
{
    public interface IGarment
    {
        long Id { get; set; }
        string Subtype { get; set; }
        float Price { get; set; }
        string Size { get; set; }
        string Brand { get; set; }
        List<string> Seasons { get; set; }
        List<Material> Materials { get; set; }
        string Note { get; set; }
    }
}