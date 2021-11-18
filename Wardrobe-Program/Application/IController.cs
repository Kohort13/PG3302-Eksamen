namespace Wardrobe_Program
{
    public interface IController
    {
        public void Handle(Command command);
        public void Help(Command command);
        public string Description { get; }
    }
}
