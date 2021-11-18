using System;

namespace Wardrobe_Program
{
    public class ChangeNoteController : AbstractController
    {
        private readonly IDao<Garment> _garmentDao;
        public ChangeNoteController(IDao<Garment> garmentDao) : base("Changes the notes of a garment")
        {
            _garmentDao = garmentDao;
        }

        public override void Handle(Command command)
        {
            if (!ValidateCommand(command)) return;
            if (!GetId(command, out var id)) return;
            Garment garmentToChange = _garmentDao.Retrieve(id);
            garmentToChange.Note = command.Parameters["-val"];
            UserInterface.Instance.Print($"Garment notes is now: {garmentToChange.Note}");
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