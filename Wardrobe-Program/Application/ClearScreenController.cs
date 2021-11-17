namespace Wardrobe_Program
{
    public class ClearScreenController : AbstractController
    {
        public override void Handle(Command command) {
            UserInterface.Instance.ClearScreen();
        }

        protected override Command GetAllowedCommandFormat() {
            return new Command();
        }
    }
}