using System.Collections.Generic;

namespace Wardrobe_Program
{
    public class NullGarment : IGarment
    {
        public long Id {
            get => -1;
            set{}
        }
        public string Subtype { 
            get => "";
            set{}
        }

        public float Price {
            get => 0f;
            set{}
        }

        public string Size {
            get => "";
            set{}
        }

        public string Brand {
            get => "";
            set{}
        }

        public List<string> Seasons {
            get => new();
            set {}
        }

        public List<Material> Materials {
            get => new();
            set{}
        }
        public string Note {
            get => "";
            set{}
        }

        public override string ToString() {
            return "Null-Object";
        }
    }
}