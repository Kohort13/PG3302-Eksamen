namespace Wardrobe_Program 
{
    public abstract class GarmentFactory
    {
        public abstract Garment CreateGarment();
        public abstract string GarmentType { get; }
    }

    #region ConcreteImplementations

    public class ShoeFactory : GarmentFactory
    {
        public override Garment CreateGarment() {
            return new Shoe();
        }
        public override string GarmentType => "Shoe";
    }

    public class TopFactory : GarmentFactory
    {
        public override Garment CreateGarment() {
            return new Top();
        }
        public override string GarmentType => "Top";

    }
    public class BottomFactory : GarmentFactory
    {
        public override Garment CreateGarment() {
            return new Bottom();
        }
        public override string GarmentType => "Bottom";

    }
    public class AccessoryFactory : GarmentFactory
    {
        public override Garment CreateGarment() {
            return new Accessory();
        }
        public override string GarmentType => "Accessory";

    }
    public class OuterwearFactory : GarmentFactory
    {
        public override Garment CreateGarment() {
            return new Outerwear();
        }
        public override string GarmentType => "Outerwear";

    }

    #endregion

}