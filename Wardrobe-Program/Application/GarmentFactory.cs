using System;

namespace Wardrobe_Program 
{
    public abstract class GarmentFactory
    {
        public abstract Garment CreateGarment();
    }

    public class ShoeFactory : GarmentFactory
    {
        public override Garment CreateGarment()
        {
            return new Shoe();
        }
    }

    public class TopFactory : GarmentFactory
    {
        public override Garment CreateGarment()
        {
            return new Top();
        }
    }
    public class BottomFactory : GarmentFactory
    {
        public override Garment CreateGarment()
        {
            return new Bottom();
        }
    }
    public class AccessoryFactory : GarmentFactory
    {
        public override Garment CreateGarment()
        {
            return new Accessory();
        }
    }
    public class OuterwearFactory : GarmentFactory
    {
        public override Garment CreateGarment()
        {
            return new Outerwear();
        }
    }
}