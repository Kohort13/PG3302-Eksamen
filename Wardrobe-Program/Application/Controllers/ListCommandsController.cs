using System;
using System.Collections.Generic;

namespace Wardrobe_Program
{
    class ListCommandsController : AbstractController
    {
        private readonly Dictionary<string, IController> _availableControllers;

        public ListCommandsController(Dictionary<string, IController> availableControllers) : base("Lists all available controllers in the app") {
            _availableControllers = availableControllers;
        }

        public override void Handle(Command command) {
            foreach (var controller in _availableControllers) {
                UserInterface.Instance.Print($"{controller.Key.PadRight(20)}{controller.Value.Description}", ConsoleColor.DarkGreen);
            }
        }

        public override void Help(Command command) {
            throw new System.NotImplementedException();
        }

        protected override ControllerValidator GetControllerValidator() {
            return new ControllerValidator
            {
                AvailableKeys = new()
            };
        }
    }
}
