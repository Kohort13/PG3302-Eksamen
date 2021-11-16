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
	}	
}
