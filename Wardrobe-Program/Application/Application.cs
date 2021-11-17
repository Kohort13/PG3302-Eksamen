﻿using System;
using System.Collections.Generic;

namespace Wardrobe_Program
{
    public class Application
    {
        public Dictionary<string, IController> Controllers { get; }

        public List<Garment> MockDatabase { get; }

        public Application() {
            Controllers = new();
            MockDatabase = new();
        }

        public void AddController(string commandTrigger, IController controller) {
            Controllers[commandTrigger] = controller;
        }

        public void RunApplication() {
            Logger.Instance.Info("Application is starting");
            Logger.Instance.Info("Type list-controllers to see all registered commands");

            while (true) {
                var userInput = Console.ReadLine();
                if (userInput != null) {
                    Command command = new(userInput);
                    if (Controllers.ContainsKey(command.Keyword)) {
                        Controllers[command.Keyword].Handle(command);
                    }
                }
            }
        }
    }
}
