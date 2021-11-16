
using System;


namespace Wardrobe_Program
{
	public class ChangeSizeController : IController
	{
		private readonly IDao<Garment> _garmentDao;

		public ChangeSizeController(IDao<Garment> garmentDao)
		{
			_garmentDao = garmentDao;
		}

		//Assumes that an id is given as first parameter, and name is 
		public void Handle(Command command)
		{
			UserInterface.Instance.Print("This should change the garment size");
			int id = Convert.ToInt32(command.Parameters[0]);
			Garment garmentToChange = _garmentDao.Retrieve((id));
			garmentToChange.Size = command.Parameters[1];
			UserInterface.Instance.Print($"Garment size is now: {garmentToChange.Size}");
		}
	}
}
