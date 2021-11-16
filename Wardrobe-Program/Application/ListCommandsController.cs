using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
