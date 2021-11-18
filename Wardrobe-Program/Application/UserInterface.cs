
using System;

namespace Wardrobe_Program
{
    public class UserInterface
    {
        #region Singleton logic
        public static UserInterface Instance { get { return Nested._instance; } }
        public ConsoleColor InputColor => ConsoleColor.Gray;

        private class Nested
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested() {
            }

            // ReSharper disable once InconsistentNaming
            internal static readonly UserInterface _instance = new();
        }
        #endregion

        public void Print(string message, ConsoleColor color) {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void Print(string message) {
            Console.ResetColor();
            Print(message, Console.ForegroundColor);
        }

        public void ClearScreen() {
            Console.Clear();
        }
    }
}
