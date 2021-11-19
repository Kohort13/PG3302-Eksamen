namespace Wardrobe_Program
{
    public interface IController
    {
        public void Handle(Command command);
        public string Description { get; }
    }

    public interface IHelpController : IController
    {
        public void Help();
    }
}
