using System;

namespace Wardrobe_Program
{
    class ListGarmentsController : IController
    {
        private readonly IDao<Garment> _availableGarments;

        public ListGarmentsController(IDao<Garment> availableGarments)
        {
            _availableGarments = availableGarments;
        }

        public void Handle(Command command)
        {
            foreach (var commandComponent in _availableGarments.Keys)
            {
                UserInterface.Instance.Print($"commandComponent");
            }
        }
    }
}