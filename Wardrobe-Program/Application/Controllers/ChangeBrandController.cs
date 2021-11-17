using System;

namespace Wardrobe_Program
{
	public class ChangeBrandController : IController
	{
		private readonly IDao<Garment> _garmentDao;

		public ChangeBrandController(IDao<Garment> garmentDao)
		{
			_garmentDao = garmentDao;
		}


		public void Handle(Command command)
		{
			UserInterface.Instance.Print("This should change the garment's brand");
			long id = Convert.ToInt64(command.Parameters["-id"]);
			Garment garmentToChange = _garmentDao.Retrieve(id);
			garmentToChange.Brand = command.Parameters["-v"];
			UserInterface.Instance.Print($"Garment's brand is now: {garmentToChange.Brand}");
		}

        public void Help(Command command) {
            throw new NotImplementedException();
        }
    }
}