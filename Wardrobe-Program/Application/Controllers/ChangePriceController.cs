using System;

namespace Wardrobe_Program
{
    public class ChangePriceController : AbstractController
    {
        private readonly IDao<Garment> _garmentDao;

        public ChangePriceController(IDao<Garment> garmentDao) : base("Changes the price of a garment")
        {
            _garmentDao = garmentDao;
        }

        //Assumes that an id is given as first parameter, and price is given as second parameter, i.e. "change-price 7 599"
        public override void Handle(Command command)
        {
            if (!ValidateCommand(command)) return;
            if (!GetId(command, out var id)) return;
            Garment garmentToChange = _garmentDao.Retrieve(id);
            garmentToChange.Price = Convert.ToSingle(command.Parameters["-val"]);
            UserInterface.Instance.Print($"Garment price is now: {garmentToChange.Price}");
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