namespace Wardrobe_Program
{
    public class SayHelloController : AbstractController, IHelpController
    {
        private readonly Application _app;
        public SayHelloController(Application app) : base("Starts saying 'Hello' on a new thread") {
            _app = app;
        }

        public override void Handle(Command command) {
            if (command.Parameters.Keys.Count == 0) {
                if (_app.IsTimerRunning) {
                    _app.StopTimer();
                }
                else {
                    _app.StartTimer();
                }
                return;
            }

            if (command.Parameters.ContainsKey("-start")) {
                _app.StartTimer();
            } else if (command.Parameters.ContainsKey("-stop")) {
                _app.StopTimer();
            }
        }

        public void Help(Command command) {
            UserInterface.Instance.Print("Starts saying hello every two seconds. We know, it's pretty useless, but at least it's multithreaded!");
        }

        protected override ControllerValidator GetControllerValidator() {
            return new ControllerValidator()
            {
                AvailableKeys =
                {
                    { "-start", (false, false) },
                    { "-stop", (false, false) }
                }
            };
        }
    }
}