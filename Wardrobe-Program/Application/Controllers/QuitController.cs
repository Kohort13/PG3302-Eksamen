using System;
using System.Collections.ObjectModel;

namespace Wardrobe_Program
{
    public class QuitController : AbstractController
    {
        private readonly Application _app;
        public QuitController(Application app) : base("Quits the application") {
            _app = app;
        }

        public override void Handle(Command command) {
            UserInterface.Instance.Print($"Thank you for managing your clothes.\n\n{GoodbyeMessage}", ConsoleColor.DarkCyan);
            _app.Quit();
        }

        protected override ControllerValidator GetControllerValidator() {
            return new ControllerValidator
            {
                AvailableKeys = new()
            };
        }

        private static string GoodbyeMessage {
            get {
                string[] options =
                {
                    "Goodbye!",
                    "Ciao!",
                    "Adiós!",
                    "Don't forget to be awesome!",
                    "Have a profoundly mediocre day!",
                    "I don't blame you..."
                };
                return Utils.PickOne<string>(new Collection<string>(options));
            }
        }
    }
}