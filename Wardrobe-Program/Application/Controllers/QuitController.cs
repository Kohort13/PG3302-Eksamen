using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Wardrobe_Program
{
    public class QuitController : AbstractController
    {
        private readonly Application _app;
        public QuitController(Application app) : base("Quits the application") {
            _app = app;
        }

        public override void Handle(Command command) {
            UserInterface.Instance.PrintRainbow($"Thank you for managing your clothes.\n\n{GoodbyeMessage}", true);
            UserInterface.Instance.PrintRainbow($"{ResourceLoader.ReadResource("sad-smiley.txt")}", true);
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
                var contents = ResourceLoader.ReadResource("Goodbye-messages.txt").Split('\n');
                return Utils.PickOne<string>(new Collection<string>(contents));
            }
        }
    }
}