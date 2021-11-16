namespace Wardrobe_Program
{
    public class Material
    {
        public string Fabric { get; set; }

        enum Colour
        {
            RED,
            ORANGE,
            YELLOW,
            GREEN,
            BLUE,
            INDIGO,
            VIOLET,
            BROWN,
            BLACK,
            WHITE,
            PINK
        }

        enum Shade
        {
            DARK,
            LIGHT,
            NEON,
            PASTEL
        }
    }
}
