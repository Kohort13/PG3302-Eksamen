using System;

namespace Wardrobe_Program
{
    public class ChangeNoteController : AbstractController
    {
        private readonly IDao<IGarment> _garmentDao;
        public ChangeNoteController(IDao<IGarment> garmentDao) : base("Changes the notes of a garment")
        {
            _garmentDao = garmentDao;
        }

        public override void Handle(Command command)
        {
            if (!ValidateCommand(command)) return;
            if (!GetId(command, out var id)) return;
            var garmentToChange = _garmentDao.Retrieve(id);
            garmentToChange.Note = command.Parameters["-val"];
            UserInterface.Instance.Print($"Garment notes is now: {garmentToChange.Note}");
        }

        public override void Help(Command command) {
            UserInterface.Instance.Print("Params: -id <id of garment to change> -val <your note here>");
        }

        protected override ControllerValidator GetControllerValidator()
        {
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