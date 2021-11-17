using System.Collections.Generic;

namespace Wardrobe_Program
{
    public class QuitController : AbstractController
    {
        private readonly Application _app;
        public QuitController(Application app) {
            _app = app;
        }

        public override void Handle(Command command) {
            _app.Quit();
        }

        protected override ControllerValidator GetControllerValidator() {
            return new ControllerValidator
            {
                AvailableKeys = new()
            };
        }
    }
}