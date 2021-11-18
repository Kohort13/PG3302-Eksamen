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
            UserInterface.Instance.Print("Welcome to the wardrobe manager!", ConsoleColor.DarkGreen);

            do {
                UserInterface.Instance.Print("Type --help to see all registered commands", ConsoleColor.Cyan);
                Console.ForegroundColor = UserInterface.Instance.InputColor;
                string userInput = UserInterface.Instance.ReadLine();
                Console.ResetColor();
                if (userInput != null)
                {
                    Command command = new(userInput);
                    UserInterface.Instance.ClearScreen();

                    if (Controllers.ContainsKey(command.Keyword) && command.Parameters.ContainsKey("-h")) {
                        try {
                            //TODO - This works, but technically shouldn't be Application's responsibility to call help...
                            Controllers[command.Keyword].Help(command);
                        }
                        catch (NotImplementedException) {
                            Logger.Instance.Warning($"NOT IMPLEMENTED! - Should list available params for command: {command.Keyword}");
                        }
                    }
                    else if (Controllers.ContainsKey(command.Keyword)) {
                        Controllers[command.Keyword].Handle(command);
                    } else {
                        UserInterface.Instance.Print($"{command.Keyword} is not a recognized command", ConsoleColor.DarkRed);
                    }
                }
            } while (_running);
        }

        public void Quit() {
            _running = false;
        }
    }
}
