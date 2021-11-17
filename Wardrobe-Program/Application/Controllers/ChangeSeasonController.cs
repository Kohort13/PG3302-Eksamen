﻿using System;
using System.Collections.Generic;

namespace Wardrobe_Program
{
	public class ChangeSeasonController : AbstractController
	{
		private readonly IDao<Garment> _garmentDao;

		public ChangeSeasonController(IDao<Garment> garmentDao)
		{
			_garmentDao = garmentDao;
            
		}

		//change-season -id 44 -sp -su -w -f
		public override void Handle(Command command)
		{
            if (!ValidateCommand(command)) {
                return;
            }
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
                        case  "-a" or "-f":
                            newSeasons.Add("Autumn");
                            break;
                    }
                }
            }

            garmentToChange.Seasons = newSeasons;
			UserInterface.Instance.Print($"Garment's seasons is now: {garmentToChange.Seasons}");
            Logger.Instance.Log("Garment has new seasons");
		}

        public override void Help(Command command) {
            throw new NotImplementedException();
        }

        protected override ControllerValidator GetControllerValidator() {
            return new ControllerValidator
            {
                AvailableKeys =
                {
                    { "-id", (true, true) },
                    { "-sp", (false, false) },
                    { "-su", (false, false) },
                    { "-au", (false, false) },
                    { "-fa", (false, false) },
                    { "-wi", (false, false) }
                }
            };
        }
    }
}