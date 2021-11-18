using System;

namespace Wardrobe_Program
{
    public abstract class AbstractController : IController
    {
        public abstract void Handle(Command command);

        public abstract void Help(Command command);

        private protected virtual bool ValidateCommand(Command command) {
            return GetControllerValidator().Validate(command);
        }

        protected abstract ControllerValidator GetControllerValidator();


        protected AbstractController(string description) {
            Description = description;
        }

        public string Description { get; }

        /// <summary>
        /// Helper method for getting an -id value from a command. Make sure to break out of
        /// the Handle()-method if it returns false!
        /// </summary>
        /// <param name="command"></param>
        /// <param name="id">Either the value of id if it was successful, or 0 if not</param>
        /// <returns>True if it was successful, false if not</returns>
        protected bool GetId(Command command, out long id) {
            try {
                id = Convert.ToInt64(command.Parameters["-id"]);
            }
            catch (Exception) {
                UserInterface.Instance.Print("Invalid id...", ConsoleColor.DarkRed);
                id = 0;
                return false;
            }

            return true;
        }
    }
}