using System;
using System.Collections.Generic;

namespace Wardrobe_Program
{
    class ListColourController : AbstractController, IHelpController
    {
        public ListColourController() : base("Lists all available colours and shades") {
        }

        public override void Handle(Command command) {
            var colours = (Material.Colours[])Enum.GetValues(typeof(Material.Colours));
            UserInterface.Instance.Print("Available colours:");
            foreach(var colour in colours) {
                UserInterface.Instance.Print($"ID {(int)colour} - {colour}");
            }

            UserInterface.Instance.Print("Available shades:");
            var shades = (Material.Shades[]) Enum.GetValues(typeof(Material.Shades));
            foreach (var shade in shades) {
                UserInterface.Instance.Print($"ID {(int)shade} - {shade}");
            }
        }

        public void Help(Command command)
        {
            UserInterface.Instance.Print("Use list-colours to see a complete list of all available colours and shades");
        }

        protected override ControllerValidator GetControllerValidator()
        {
            return new ControllerValidator
            {
                AvailableKeys = new()
            };
        }
    }
}