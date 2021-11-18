namespace Wardrobe_Program
{
    public class ClearScreenController : AbstractController
    {
        public override void Handle(Command command) {
            UserInterface.Instance.ClearScreen();
        }

        protected override ControllerValidator GetControllerValidator() {
            return new ControllerValidator
            {
                AvailableKeys = new()
            };
        }

        public ClearScreenController() : base("Clears the screen") {
        }

        public override void Help(Command command) {
            UserInterface.Instance.Print("No Params, it just clears the screen");
        }
    }
}