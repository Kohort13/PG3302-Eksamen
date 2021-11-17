namespace Wardrobe_Program
{
    public abstract class AbstractController : IController
    {
        public abstract void Handle(Command command);

        public virtual void Help(Command command) {
            throw new System.NotImplementedException();
        }

        private protected virtual bool ValidateCommand(Command command) {
            foreach (var parametersKey in command.Parameters.Keys) {
                bool isValidKey = false;
                foreach (var allowedKeys in GetAllowedCommandFormat().Parameters.Keys) {
                    if (parametersKey == allowedKeys) {
                        isValidKey = true;
                    }
                }
                if (!isValidKey) {
                    Logger.Instance.Error("Incorrect format of command");
                    return false;
                }
            }

            return true;
        }

        protected abstract Command GetAllowedCommandFormat();
    }
}