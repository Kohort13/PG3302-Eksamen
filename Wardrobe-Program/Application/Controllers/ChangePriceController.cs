using System;

namespace Wardrobe_Program
{
    public class ChangePriceController : AbstractController, IHelpController
    {
        private readonly IDao<IGarment> _garmentDao;

        public ChangePriceController(IDao<IGarment> garmentDao) : base("Changes the price of a garment")
        {
            _garmentDao = garmentDao;
        }

        //Assumes that an id is given as first parameter, and price is given as second parameter, i.e. "change-price 7 599"
        public override void Handle(Command command)
        {
            if (!ValidateCommand(command)) return;
            if (!GetId(command, out var id)) return;
            IGarment garmentToChange = _garmentDao.Retrieve(id);
            garmentToChange.Price = Convert.ToSingle(command.Parameters["-val"]);
            UserInterface.Instance.Print($"Garment price is now: {garmentToChange.Price}");
        }

        public void Help() {
            UserInterface.Instance.Print("Params: -id <id of garment to change> -val <price of garment>");
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