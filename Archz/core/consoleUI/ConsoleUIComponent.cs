using System;
using System.Collections.Generic;
using System.Text;

namespace Archz.core
{
    public class ConsoleUIComponent
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsSelected { get; set; }

        public ConsoleUIComponent(int x, int y, int width, int height)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            IsEnabled = true;
        }
    }
}
