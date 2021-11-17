using System;

namespace Wardrobe_Program
{
    class ListGarmentsController : AbstractController
    {
        private readonly IDao<Garment> _availableGarments;

        public ListGarmentsController(IDao<Garment> availableGarments) {
            _availableGarments = availableGarments;
        }

        public override void Handle(Command command) {
            var garments = _availableGarments.ListAll();
            foreach (var garment in garments) {
                UserInterface.Instance.Print($"{garment}");
            }
        }

        public void Help(Command command) {
            throw new NotImplementedException();
        }

        protected override ControllerValidator GetControllerValidator() {
            return new ControllerValidator
            {
                AvailableKeys = new()
            };
        }
    }
}