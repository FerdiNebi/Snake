using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySnake
{
    public class ConsoleRenderer
    {
        private readonly char[,] gameWorld;
        private int offset = 1;

        public ConsoleRenderer(int worldWidth, int worldHeight)
        {
            this.gameWorld = new char[worldWidth + 2 * offset, worldHeight + 2 * offset];
            DrawBoundaries();
            Console.CursorVisible = false;
        }

        public void EnqueuForRendering(IRenderable obj)
        {
            Vector objectPosition = obj.GetPosition();
            char objectImage = obj.GetImage();

            if (objectPosition.X >= 0 && objectPosition.X < gameWorld.GetLength(0) - 2 * offset &&
                objectPosition.Y >= 0 && objectPosition.Y < gameWorld.GetLength(1) - 2 * offset)
            {
                this.gameWorld[objectPosition.X + offset, objectPosition.Y + offset] = objectImage;
            }
        }

        //Note to self:
        //[X,Y] swapped
        //In game logic X means horizontal, but here X means vertical
        public void Render()
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < gameWorld.GetLength(1); i++)
            {
                for (int j = 0; j < gameWorld.GetLength(0); j++)
                {
                    Console.Write(gameWorld[j, i]);
                }
                Console.WriteLine();
            }
            this.ClearQueue();
        }

        public void ClearQueue()
        {
            for (int i = offset; i < gameWorld.GetLength(1) - offset; i++)
            {
                for (int j = offset; j < gameWorld.GetLength(0) - offset; j++)
                {
                    this.gameWorld[j, i] = ' ';
                }
            }
        }

        public void PrintScore(int score)
        {
            int cursorLeft = gameWorld.GetLength(0) + 5;
            int cursorTop = 3;

            Console.SetCursorPosition(cursorLeft, cursorTop);
            Console.Write("Score: {0:d6}", score);
        }
        public void PrintGameOver(int score)
        {
            Console.Clear();
            Console.WriteLine("Game over! Score: {0}", score);
            System.Threading.Thread.Sleep(2000);
        }

        private void DrawBoundaries()
        {
            int width = gameWorld.GetLength(0);
            int height = gameWorld.GetLength(1);

            for (int i = 0; i < width; i++)
            {
                gameWorld[i, 0] = '+';
                gameWorld[i, height - 1] = '+';
            }

            for (int i = 0; i < height; i++)
            {
                gameWorld[0, i] = '+';
                gameWorld[width - 1, i] = '+';
            }
        }
    }
}