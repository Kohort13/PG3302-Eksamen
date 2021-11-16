using System;

namespace Wardrobe_Program
{
    public class ChangePriceController : IController
    {
        private readonly IDao<Garment> _garmentDao;

        public ChangePriceController(IDao<Garment> garmentDao)
        {
            _garmentDao = garmentDao;
        }

        //Assumes that an id is given as first parameter, and price is given as second parameter, i.e. "change-price 7 599"
        public void Handle(Command command)
        {
            UserInterface.Instance.Print("This should change the garment price");
            int id = Convert.ToInt32(command.Parameters[0]);
            Garment garmentToChange = _garmentDao.Retrieve(id);
            garmentToChange.Name = command.Parameters[1];
            UserInterface.Instance.Print($"Garment price is now: {garmentToChange.Price}");
        }
    }
}