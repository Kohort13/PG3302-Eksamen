namespace Wardrobe_Program
{
    public class Material
    {
        public string Fabric { get; set; }
        public Colours Colour { get; set; }
        public Shades Shade { get; set; }

        public enum Colours
        {
            Red,
            Orange,
            Yellow,
            Green,
            Blue,
            Indigo,
            Violet,
            Brown,
            Black,
            White,
            Pink
        }

        public enum Shades
        {
            Dark,
            Light,
            Neon,
            Pastel
        }

        public override string ToString() {
            return $"Material{{{Colour}, {Shade}}}";
        }
    }
}
