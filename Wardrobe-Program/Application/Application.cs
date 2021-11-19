using System;
using System.Collections.Generic;
using System.Threading;

namespace Wardrobe_Program
{
    public class Application
    {
        private bool _running;
        public Dictionary<string, IController> Controllers { get; }

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
                if (userInput == null) continue;
                Command command = new(userInput);
                UserInterface.Instance.ClearScreen();

                if (Controllers.ContainsKey(command.Keyword)) {
                    var controller = Controllers[command.Keyword];
                    if (command.Parameters.ContainsKey("-h")) {
                        if (typeof(IHelpController).IsAssignableFrom(typeof(AbstractController))) continue;
                        var helpController = (IHelpController)controller;
                        helpController.Help(command);
                        continue;
                    }
                        
                    Controllers[command.Keyword].Handle(command);
                    continue;
                }
                UserInterface.Instance.Print($"{command.Keyword} is not a recognized command", ConsoleColor.DarkRed);
            } while (_running);
        }

        public void Quit() {
            _running = false;
        }

        private Timer _timer;

        private static void SayHello(object state) {
            Logger.Instance.Log("Hello!");
        }

        public void StartTimer() {
            _timer?.Dispose(); //Make sure we dispose of any running timer before starting a new one
            _timer = new Timer(SayHello, null, 1000, 2000);
            _timerRunning = true;
        }

        public void StopTimer() {
            _timer.Dispose();
            _timerRunning = false;
        }

        private bool _timerRunning = false;
        public bool IsTimerRunning => _timerRunning;
    }
}
