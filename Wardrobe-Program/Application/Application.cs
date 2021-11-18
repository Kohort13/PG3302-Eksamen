﻿using System;
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
                UserInterface.Instance.Print("Type list-controllers to see all registered commands");
                Console.ForegroundColor = UserInterface.Instance.InputColor;
                var userInput = Console.ReadLine();
                Console.ResetColor();
                if (userInput != null)
                {
                    Command command = new(userInput);
                    if (Controllers.ContainsKey(command.Keyword))
                    {
                        UserInterface.Instance.ClearScreen();
                        Controllers[command.Keyword].Handle(command);
                    }
                    else
                    {
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
