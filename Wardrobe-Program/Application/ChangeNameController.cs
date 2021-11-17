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
            UserInterface.Instance.Print("This should change the garment name");
            long id = Convert.ToInt64(command.Parameters[0]);
            Garment garmentToChange = _garmentDao.Retrieve(id);
            garmentToChange.Name = command.Parameters[1];
            UserInterface.Instance.Print($"Garment name is now: {garmentToChange.Name}");
        }
    }
}