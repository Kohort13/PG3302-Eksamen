using System;

namespace Wardrobe_Program
{
    public class DeleteMaterialController : AbstractController
    {
        private readonly IDao<IGarment> _garmentDao;

        public DeleteMaterialController(IDao<IGarment> garmentDao)
            : base("Deletes a specified material from the garment")
        {
            _garmentDao = garmentDao;
        }

        public override void Handle(Command command)
        {
            if (!ValidateCommand(command)) return;
            if(!GetId(command, out var id))return;

            var garmentToChange = _garmentDao.Retrieve(id);
            int materialId;
            try {
                materialId = Convert.ToInt32(command.Parameters["-matId"]);
            }
            catch (Exception) {
                UserInterface.Instance.Print("Invalid material id...");
                return;
            }

            var materialToDelete = garmentToChange.Materials[materialId];
            garmentToChange.Materials.Remove(materialToDelete);

            UserInterface.Instance.Print($"You have deleted: {materialToDelete} from {garmentToChange}");
        }

        public override void Help(Command command)
        {
            UserInterface.Instance.Print("Params: -id <id of garment to change> -matId <id of material>");
        }

        protected override ControllerValidator GetControllerValidator() {
            return new ControllerValidator
            {
                AvailableKeys =
                {
                    { "-id", (true, true) },
                    { "-matId", (true, true)}
                }
            };
        }
    }
}