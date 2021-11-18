using System;

namespace Wardrobe_Program
{
	public class ChangeBrandController : AbstractController
	{
		private readonly IDao<Garment> _garmentDao;

		public ChangeBrandController(IDao<Garment> garmentDao) : base("Changes the brand of a garment")
		{
			_garmentDao = garmentDao;
		}


		public override void Handle(Command command) {
            if (!ValidateCommand(command)) return;
            if (!GetId(command, out var id)) return;

            Garment garmentToChange = _garmentDao.Retrieve(id);
			garmentToChange.Brand = command.Parameters["-val"];
			UserInterface.Instance.Print($"Garment's brand is now: {garmentToChange.Brand}");
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