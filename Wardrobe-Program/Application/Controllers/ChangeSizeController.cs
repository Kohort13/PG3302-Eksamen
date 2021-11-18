using System;


namespace Wardrobe_Program
{
    public class ChangeSizeController : AbstractController
    {
        private readonly IDao<Garment> _garmentDao;

        public ChangeSizeController(IDao<Garment> garmentDao) : base("Changes the size of a garment")
        {
            _garmentDao = garmentDao;
        }

        //Assumes that an id is given as first parameter, and name is 
        public override void Handle(Command command)
        {
            if (!ValidateCommand(command)) return;
            if (!GetId(command, out var id)) return;
            Garment garmentToChange = _garmentDao.Retrieve((id));
            garmentToChange.Size = command.Parameters["-val"];
            UserInterface.Instance.Print($"Garment size is now: {garmentToChange.Size}");
        }

        public override void Help(Command command) {
            UserInterface.Instance.Print("Params: -id <id of garment to change> -val <garment size>");
        }


        protected override ControllerValidator GetControllerValidator()
        {
            return new ControllerValidator
            {
                AvailableKeys =
                {
                    {"-id", (true, true)},
                    {"-val", (true, true)}
                }
            };
        }
    }
}
