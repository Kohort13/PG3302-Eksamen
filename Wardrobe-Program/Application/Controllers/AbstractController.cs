namespace Wardrobe_Program
{
    public abstract class AbstractController : IController
    {
        public abstract void Handle(Command command);

        public virtual void Help(Command command) {
            throw new System.NotImplementedException();
        }

        private protected virtual bool ValidateCommand(Command command) {
            return GetControllerValidator().Validate(command);
        }

        protected abstract ControllerValidator GetControllerValidator();

        protected readonly string _Description;

        protected AbstractController(string description) {
            _Description = description;
        }

        public string Description { get => _Description; }
    }
}