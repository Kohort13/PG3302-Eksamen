using System;

namespace Wardrobe_Program
{
    public class ChangeSubtypeController : AbstractController
    {
        private readonly IDao<Garment> _garmentDao;
        public ChangeSubtypeController(IDao<Garment> garmentDao) : base("Changes the subtype of a garment")
        {
            _garmentDao = garmentDao;
        }

        public override void Handle(Command command) {
            if (!ValidateCommand(command)) return;
            if (!GetId(command, out var id)) return;
            Garment garmentToChange = _garmentDao.Retrieve(id);
            garmentToChange.Subtype = command.Parameters["-val"];
            UserInterface.Instance.Print($"Garment name is now: {garmentToChange.Subtype}");
        }

        public override void Help(Command command) {
            UserInterface.Instance.Print("Params: -id <id of garment to change> -val <garment subtype>");
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