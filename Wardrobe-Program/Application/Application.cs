using System.Collections.Generic;

namespace Wardrobe_Program
{
    class Application
    {
        private Dictionary<string, IController> _controllers;

        public Application() {
            _controllers = new();
        }

        public void AddController(string commandTrigger, IController controller) {
            _controllers[commandTrigger] = controller;
        }

        public void RunApplication() {
            Logger.Instance.Info("Application is starting");
        }
    }
}
