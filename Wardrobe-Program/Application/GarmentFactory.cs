using System;

namespace Wardrobe_Program 
{
    public abstract class GarmentFactory
    {
        public abstract Garment CreateGarment();
    }

    public class ShoeFactory : GarmentFactory
    {
        public Garment CreateGarment()
        {
            return new Shoe();
        }
    }

    public class TopFactory : GarmentFactory
    {
        public Garment CreateGarment()
        {
            return new Top();
        }
    }
    public class BottomFactory : GarmentFactory
    {
        public Garment CreateGarment()
        {
            return new BottomFactory();
        }
    }
    public class AccessoryFactory : GarmentFactory
    {
        public Garment CreateGarment()
        {
            return new Accessory();
        }
    }
    public class OuterwearFactory : GarmentFactory
    {
        public Garment CreateGarment()
        {
            return new Outerwear();
        }
    }
}