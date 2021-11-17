using System;


namespace Wardrobe_Program
{
    public class ChangeSizeController : AbstractController
    {
        private readonly IDao<Garment> _garmentDao;

        public ChangeSizeController(IDao<Garment> garmentDao)
        {
            _garmentDao = garmentDao;
        }

        //Assumes that an id is given as first parameter, and name is 
        public override void Handle(Command command)
        {
            long id = Convert.ToInt64(command.Parameters["-id"]);
            Garment garmentToChange = _garmentDao.Retrieve((id));
            garmentToChange.Size = command.Parameters["-val"];
            UserInterface.Instance.Print($"Garment size is now: {garmentToChange.Size}");
        }

        public void Help(Command command)
        {
            throw new NotImplementedException();
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
