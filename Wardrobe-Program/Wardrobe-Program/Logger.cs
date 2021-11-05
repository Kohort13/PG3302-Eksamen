using System;

namespace Wardrobe_Program
{
    /// <summary>
    /// A singleton logger class. Usage: Logger.Instance.MethodName() 
    /// </summary>
    public class Logger
    {
        #region Singleton logic
        public static Logger Instance { get { return Nested._instance; } }

        private class Nested
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested() {
            }

            // ReSharper disable once InconsistentNaming
            internal static readonly Logger _instance = new ();
        }
        #endregion


        public bool IsActive { get; set; } = true;
        /// <summary>
        /// Outputs a yellow warning message
        /// </summary>
        /// <param name="message"></param>
        public void Warning(string message) {
            Print(message, ConsoleColor.Yellow);
        }

        /// <summary>
        /// Outputs a red error message
        /// </summary>
        /// <param name="message"></param>
        public void Error(string message) {
            Print(message, ConsoleColor.DarkRed);
        }

        /// <summary>
        /// Outputs a cyan info message. Use this if you just want to highlight something
        /// </summary>
        /// <param name="message"></param>
        public void Info(string message) {
            Print(message, ConsoleColor.DarkCyan);
        }

        /// <summary>
        /// Outputs a standard white message
        /// </summary>
        /// <param name="message"></param>
        public void Log(string message) {
            Print(message);
        }

        private void Print(string message, ConsoleColor color) {
            if (IsActive)
            {
                Console.ForegroundColor = color;
                Console.WriteLine(message);
                Console.ResetColor();
            }
        }

        private void Print(string message) {
            Console.ResetColor();
            Print(message, Console.ForegroundColor);
        }
    }
}