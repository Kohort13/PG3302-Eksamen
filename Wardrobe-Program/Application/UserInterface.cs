
using System;
using System.Collections.Generic;

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

        public string ReadLine() {
            return Console.ReadLine().Trim();
        }

        public void PrintRainbow(string message, bool skipSpaces) {
            List<ConsoleColor> colours = new()
            {
                ConsoleColor.Red, ConsoleColor.DarkYellow, ConsoleColor.Yellow, ConsoleColor.Green, ConsoleColor.Cyan,
                ConsoleColor.DarkBlue, ConsoleColor.DarkMagenta
            };
            int colourInc = 0;
            for (int i = 0; i < message.Length; i++) {
                if (skipSpaces) {
                    if (message[i] != ' ') {
                        Console.ForegroundColor = colours[colourInc % colours.Count];
                        colourInc++;
                    } 
                } else {
                    Console.ForegroundColor = colours[colourInc % colours.Count];
                    colourInc++;
                }
                Console.Write(message[i]);
            }
            Console.ResetColor();
        }
    }
}
