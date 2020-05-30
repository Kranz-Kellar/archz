using System;
using System.Collections.Generic;
using System.Text;

namespace Archz.core
{
    public class ConsoleUI
    {
        List<ConsoleUIComponent> UIComponents;
        public ConsoleUI()
        {

        }

        static public void WriteInCenterOfTheLine(string message)
        {
            Console.Write(new string(' ', (Console.WindowWidth - message.Length) / 2));
            Console.WriteLine(message);

        }

        static public void SetCursorToTheBottom()
        {
            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            Console.Write(">");
        }



        public void RenderTextArea(ConsoleTextArea textArea)
        {
            Console.SetCursorPosition(textArea.X, textArea.Y);
            DrawSymbol(textArea.BorderSymbol, textArea.Width);
            for(int i = 1; i < textArea.Height - 1; i++)
            {
                Console.SetCursorPosition(textArea.X, textArea.Y + i);
                string line = string.Empty;
                line += textArea.BorderSymbol;

                line += textArea.Text.Substring(textArea.CurrentSymbolToRender, textArea.Width - 2);

                line = CheckLineOnNewLineChar(line, textArea);

                FillLineWithSpaces(line, textArea);

                line += textArea.BorderSymbol;
                Console.Write(line);
                
            }
            Console.SetCursorPosition(textArea.X, textArea.Y + textArea.Height);
            DrawSymbol(textArea.BorderSymbol, textArea.Width);
        }

        private string CheckLineOnNewLineChar(string line, ConsoleTextArea textArea)
        {
            if(line.Contains('\n'))
            {
                var startIndex = textArea.CurrentSymbolToRender;
                textArea.CurrentSymbolToRender += line.IndexOf('\n');
                return line.Substring(startIndex, line.IndexOf('\n'));
            }
            textArea.CurrentSymbolToRender += textArea.Width - 2;
            return line;
        }
        private void FillLineWithSpaces(string line, ConsoleTextArea textArea)
        {
            if (line.Length < textArea.Width - 2)
            {
                int countOfSpaces = (textArea.Width - 2) - line.Length;

                for (int i = 0; i < countOfSpaces; i++)
                {
                    line += " ";
                }
            }
        }

        private void DrawSymbol(char symbol, int numberOfTimes)
        {
            for(int i = 0; i < numberOfTimes; i++)
            {
                Console.Write(symbol);
            }
        }
    }
}
