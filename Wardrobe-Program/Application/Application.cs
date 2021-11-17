using System;
using System.Collections.Generic;

namespace Wardrobe_Program
{
    public class Application
    {
        private bool _running;
        public Dictionary<string, IController> Controllers { get; }

        public IDao<Garment> Database { get; set; }

        public Application() {
            Controllers = new Dictionary<string, IController>();
        }

        public void AddController(string commandTrigger, IController controller) {
            Controllers[commandTrigger] = controller;
        }

        public void RunApplication() {
            _running = true;
            Logger.Instance.Info("Application is starting");
            Logger.Instance.Info("Type list-controllers to see all registered commands");

            while (_running) {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                var userInput = Console.ReadLine();
                Console.ResetColor();
                if (userInput != null) {
                    Command command = new(userInput);
                    if (Controllers.ContainsKey(command.Keyword)) {
                        Controllers[command.Keyword].Handle(command);
                    }
                    else {
                        UserInterface.Instance.Print($"{command.Keyword} is not a recognized command", ConsoleColor.DarkRed);
                        UserInterface.Instance.Print("Type list-controllers to see all recognized commands", ConsoleColor.Cyan);
                    }
                }
            }
        }

        public void Quit() {
            _running = false;
        }
    }
}
