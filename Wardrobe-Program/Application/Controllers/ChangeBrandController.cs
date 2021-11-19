using System;

namespace Wardrobe_Program
{
	public class ChangeBrandController : AbstractController
	{
		private readonly IDao<IGarment> _garmentDao;

		public ChangeBrandController(IDao<IGarment> garmentDao) : base("Changes the brand of a garment")
		{
			_garmentDao = garmentDao;
		}


		public override void Handle(Command command) {
            if (!ValidateCommand(command)) return;
            if (!GetId(command, out var id)) return;

            var garmentToChange = _garmentDao.Retrieve(id);
			garmentToChange.Brand = command.Parameters["-val"];
			UserInterface.Instance.Print($"Garment's brand is now: {garmentToChange.Brand}");
		}

        public override void Help(Command command) {
            UserInterface.Instance.Print("Params: -id <id of garment to change> -val <name of brand>");
        }

        protected override ControllerValidator GetControllerValidator() {
            return new ControllerValidator
            {
                AvailableKeys =
                {
                    { "-id", (true, true) },
                    { "-val", (true, true) }
                }
            };
        }
    }
}