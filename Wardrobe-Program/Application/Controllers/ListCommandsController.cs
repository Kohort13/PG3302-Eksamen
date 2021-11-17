using System;
using System.Collections.Generic;

namespace Wardrobe_Program
{
    class ListCommandsController : AbstractController
    {
        private readonly Dictionary<string, IController> _availableControllers;

        public ListCommandsController(Dictionary<string, IController> availableControllers) {
            _availableControllers = availableControllers;
        }

        public override void Handle(Command command) {
            foreach (var commandComponent in _availableControllers.Keys) {
                UserInterface.Instance.Print($"{commandComponent}", ConsoleColor.DarkGreen);
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
