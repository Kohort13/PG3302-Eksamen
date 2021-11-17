using System;
using System.Collections.Generic;

namespace Wardrobe_Program
{
	public class ChangeSeasonController : IController
	{
		private readonly IDao<Garment> _garmentDao;

		public ChangeSeasonController(IDao<Garment> garmentDao)
		{
			_garmentDao = garmentDao;
		}

		//change-season -id 44 -sp -su -w -f
		public void Handle(Command command)
		{
			UserInterface.Instance.Print("This should change the garment's season");
			long id = Convert.ToInt64(command.Parameters["-id"]);
			Garment garmentToChange = _garmentDao.Retrieve(id);
            List<string> newSeasons = new();
            {
                foreach (var key in command.Parameters.Keys) {
                    switch (key) {
                        case "-sp":
                            newSeasons.Add("Spring");
                            break;
                        case "-su":
                            newSeasons.Add("Summer");
                            break;
                        case "-w":
                            newSeasons.Add("Winter");
                            break;
                        case "-f" or "-a":
                            newSeasons.Add("Autumn");
                            break;
                    }
                }
            }

            garmentToChange.Seasons = newSeasons;
			UserInterface.Instance.Print($"Garment's seasons is now: {garmentToChange.Seasons}");
		}

        public void Help(Command command) {
            throw new NotImplementedException();
        }
    }
}