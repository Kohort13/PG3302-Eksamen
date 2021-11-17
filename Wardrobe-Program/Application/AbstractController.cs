namespace Wardrobe_Program
{
    public abstract class AbstractController : IController
    {
        public virtual void Handle(Command command) {
            if (!ValidateCommand(command)) {
                Logger.Instance.Error("Incorrect format of command");
            }
        }

        public virtual void Help(Command command) {
            throw new System.NotImplementedException();
        }

        private bool ValidateCommand(Command command) {
            foreach (var parametersKey in command.Parameters.Keys) {
                bool isValidKey = false;
                foreach (var allowedKeys in GetAllowedCommandFormat().Parameters.Keys) {
                    if (parametersKey == allowedKeys) {
                        isValidKey = true;
                    }
                }
                if (!isValidKey) {
                    return false;
                }
            }

            return true;
        }

        protected abstract Command GetAllowedCommandFormat();
    }
}