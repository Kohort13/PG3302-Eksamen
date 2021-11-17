using System.Collections.Generic;

namespace Wardrobe_Program
{
    class ListCommandsController : IController
    {
        private readonly Dictionary<string, IController> _availableControllers;

        public ListCommandsController(Dictionary<string, IController> availableControllers) {
            _availableControllers = availableControllers;
        }
        
        public void Handle(Command command) {
            foreach (var commandComponent in _availableControllers.Keys) {
                UserInterface.Instance.Print($"{commandComponent}");
            } 
        }

        public void Help(Command command) {
            throw new System.NotImplementedException();
        }
    }
}
