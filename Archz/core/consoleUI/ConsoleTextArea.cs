using System;
using System.Collections.Generic;
using System.Text;

namespace Archz.core
{
    public class ConsoleTextArea : ConsoleUIComponent
    {
        public string Text { get; set; }
        public int LengthOfText { get; }
        public int CurrentSymbolToRender { get; set; }
        public int CurrentCursorToTextBuffer { get; set; }
        public char BorderSymbol { get; set; }
        public ConsoleColor BorderColor { get; set; }
        public ConsoleColor TextColor { get; set; }
        public ConsoleTextArea(int x, int y, int width, int height, char borderSymbol, ConsoleColor borderColor, ConsoleColor textColor) : base(x, y, width, height)
        {
            Text = new string(' ', (width - 2) * (height - 2));
            //Text = string.Empty;
            CurrentSymbolToRender = 0;
            CurrentCursorToTextBuffer = 0;
            BorderColor = borderColor;
            TextColor = textColor;
            BorderSymbol = borderSymbol;
            LengthOfText = Text.Length;
        }

        public void WriteText(string text)
        {
            //Text += text;

            Text = Text.Insert(CurrentCursorToTextBuffer, text);
            CurrentCursorToTextBuffer += text.Length;
        }

        public void Render()
        {
            DrawBorders();
            DrawBuffer();
        }

        private void DrawBuffer()
        {
            Console.SetCursorPosition(X + 1, Y + 1);
            string textToRender = Text.Substring(CurrentSymbolToRender, Width - 2);
            textToRender = CutLineIfNewLineChar(textToRender);

        }

        private string CutLineIfNewLineChar(string line)
        {
            if(line.Contains('\n'))
            {
                int positionOfNewLineChar = line.IndexOf('\n');
                string cuttedLine = line.Substring(0, positionOfNewLineChar);
                CurrentSymbolToRender += positionOfNewLineChar + 1;
                return cuttedLine;
            }
            CurrentSymbolToRender += line.Length;
            return line;
        }



        private void DrawHorizontalLine(char symbol, int size)
        {
            string line = string.Empty;
            for(int i = 0; i < size; i++)
            {
                line += symbol;
            }

            Console.Write(line);
        }

        private void DrawVerticalLine(char symbol, int size, int currentXPosition, int currentYPosition)
        {
            
            for(int i = 0; i < size; i++)
            {
                Console.SetCursorPosition(currentXPosition, currentYPosition + i);
                Console.Write(symbol);
            }
        }

        private void ClearTextArea()
        {

        }

        private void DrawBorders()
        {
            DrawTopBorder();
            DrawBottomBorder();
            DrawLeftBorder();
            DrawRightBorder();
        }

        private void DrawTopBorder()
        {
            Console.SetCursorPosition(X, Y);
            DrawHorizontalLine(BorderSymbol, Width);
        }

        private void DrawBottomBorder()
        {
            Console.SetCursorPosition(X, Y + Height);
            DrawHorizontalLine(BorderSymbol, Width);
        }

        private void DrawLeftBorder()
        {
            DrawVerticalLine(BorderSymbol, Height, X, Y);
        }
        private void DrawRightBorder()
        {
            DrawVerticalLine(BorderSymbol, Height, X + Width - 1, Y);
        }

    }
}
