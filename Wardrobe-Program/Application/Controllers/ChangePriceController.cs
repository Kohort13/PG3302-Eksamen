using System;

namespace Wardrobe_Program
{
    public class ChangePriceController : AbstractController
    {
        private readonly IDao<Garment> _garmentDao;

        public ChangePriceController(IDao<Garment> garmentDao)
        {
            _garmentDao = garmentDao;
        }

        //Assumes that an id is given as first parameter, and price is given as second parameter, i.e. "change-price 7 599"
        public override void Handle(Command command)
        {
            long id = Convert.ToInt64(command.Parameters["-id"]);
            Garment garmentToChange = _garmentDao.Retrieve(id);
            garmentToChange.Price = Convert.ToSingle(command.Parameters["-val"]);
            UserInterface.Instance.Print($"Garment price is now: {garmentToChange.Price}");
        }

        public void Help(Command command) {
            throw new NotImplementedException();
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