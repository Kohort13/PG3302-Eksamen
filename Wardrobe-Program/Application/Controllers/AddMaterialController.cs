using System;

namespace Wardrobe_Program
{
    public class AddMaterialController : AbstractController, IHelpController
    {
        private readonly IDao<IGarment> _garmentDao;

        public AddMaterialController(IDao<IGarment> garmentDao) : base("Adds a material to the garment") {
            _garmentDao = garmentDao;
        }

        public override void Handle(Command command) {
            if (!ValidateCommand(command)) return;
            if (!GetId(command, out var id)) return;

            Material newMaterial;
            try {
                var colourId = Convert.ToInt32(command.Parameters["-col"]);
                var shadeId = Convert.ToInt32(command.Parameters["-sha"]);
                newMaterial = new Material
                {
                    Colour = (Material.Colours)colourId,
                    Shade = (Material.Shades)shadeId,
                    Fabric = command.Parameters["-fab"]
                };
            }
            catch (Exception) {
                UserInterface.Instance.Print("One or more of parameters passed in was incorrect");
                return;
            }
            var garmentToChange = _garmentDao.Retrieve((id));
            garmentToChange.Materials.Add(newMaterial);
            _garmentDao.Update(id, garmentToChange);
        }

        public void Help() {
            UserInterface.Instance.Print("Params: -id <id of garment to change> -col <id of colour> -sha <id of shade> -fab <name of fabric>");
            UserInterface.Instance.Print("Use list-colours to see available colour and shade id's");
        }

        protected override ControllerValidator GetControllerValidator() {
            return new ControllerValidator
            {
                AvailableKeys =
                {
                    {"-id", (true, true)},
                    {"-col", (true, true)},
                    {"-fab", (true, true)},
                    {"-sha", (true, true)}
                }
            };
        }
    }
}