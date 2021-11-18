using System;

namespace Wardrobe_Program
{
    public class ChangeNameController : AbstractController
    {
        private readonly IDao<Garment> _garmentDao;
        public ChangeNameController(IDao<Garment> garmentDao) : base("Changes the name of a garment")
        {
            _garmentDao = garmentDao;
        }

        public override void Handle(Command command) {
            long id = Convert.ToInt64(command.Parameters["-id"]);
            Garment garmentToChange = _garmentDao.Retrieve(id);
            garmentToChange.Name = command.Parameters["-val"];
            UserInterface.Instance.Print($"Garment name is now: {garmentToChange.Name}");
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