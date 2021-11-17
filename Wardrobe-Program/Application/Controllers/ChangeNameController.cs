using System;

namespace Wardrobe_Program
{
    public class ChangeNameController : IController
    {
        private readonly IDao<Garment> _garmentDao;
        public ChangeNameController(IDao<Garment> garmentDao) {
            _garmentDao = garmentDao;
        }


        //Assumes that an id is given as first parameter, and name is given as second parameter, i.e. "change-name 44 A-new-name"
        public void Handle(Command command) {
            long id = Convert.ToInt64(command.Parameters["-id"]);
            Garment garmentToChange = _garmentDao.Retrieve(id);
            garmentToChange.Name = command.Parameters["-v"];
            UserInterface.Instance.Print($"Garment name is now: {garmentToChange.Name}");
        }

        public void Help(Command command) {
            throw new NotImplementedException();
        }
    }
}