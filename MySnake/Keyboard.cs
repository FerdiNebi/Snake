using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySnake
{
    public class Keyboard
    {
        public event EventHandler OnLeftKeyPressed;
        public event EventHandler OnUpKeyPressed;
        public event EventHandler OnRightKeyPressed;
        public event EventHandler OnDownKeyPressed;

        public void ProcessInput()
        {
            if (Console.KeyAvailable)
            {
                var keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    this.OnLeftKeyPressed(null, new EventArgs());
                }
                else if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    this.OnUpKeyPressed(null, new EventArgs());
                }
                else if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    this.OnRightKeyPressed(null, new EventArgs());
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    this.OnDownKeyPressed(null, new EventArgs());
                }
            }
        }
    }
}