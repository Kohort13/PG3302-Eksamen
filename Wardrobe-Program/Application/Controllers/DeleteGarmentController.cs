using System;
using System.Collections.Generic;


namespace Wardrobe_Program
{
    public class DeleteGarmentController : AbstractController
    {
        private readonly IDao<Garment> _garmentDao;

        public DeleteGarmentController(IDao<Garment> garmentDao)
            : base("Removes an existing garment from the database")
        {
            _garmentDao = garmentDao;
        }

        public override void Handle(Command command)
        {
            if (!ValidateCommand(command)) return;
            if (!GetId(command, out var id)) return;
            var garmentToDelete = _garmentDao.Retrieve(id);
            UserInterface.Instance.Print($"You have deleted garment: {garmentToDelete}");
            _garmentDao.Delete(id);
        }

        protected override ControllerValidator GetControllerValidator()
        {
            return new ControllerValidator
            {
                AvailableKeys =
                {
                    {"-id", (true, true)}
                }
            };
        }
    }
}