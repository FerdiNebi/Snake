using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySnake
{
    public class GameEngine
    {
        private const int SleepTimeInMS = 100;
        private Keyboard keyboard;
        private Snake snake;
        private Food food;
        private ConsoleRenderer renderer;
        private readonly int WorldWidth;
        private readonly int WorldHeight;
        private bool[,] occupiedCells;
        private int score;

        public GameEngine(Snake snake, Keyboard keyboard,Food food, ConsoleRenderer renderer,
            int WorldWidth, int WorldHeight)
        {
            this.snake = snake;
            this.keyboard = keyboard;
            this.food = food;
            this.renderer = renderer;
            this.WorldWidth = WorldWidth;
            this.WorldHeight = WorldHeight;
            this.occupiedCells = new bool[WorldWidth + 2, WorldHeight + 2];
            this.score = 0;
        }

        private void RenderObjects()
        {
            renderer.ClearQueue();
            foreach (SnakeParticle particle in snake.Body)
            {
                renderer.EnqueuForRendering(particle);
            }

            renderer.EnqueuForRendering(food);
            renderer.PrintScore(this.score);
            renderer.Render();
        }

        private void UpdateObjects()
        {
            this.snake.Move();
        }

        /// <summary>
        /// Determines whether a cell is occupied or not.
        /// </summary>
        private void UpdateCellsInfo()
        {
            List<SnakeParticle> snakeBody = this.snake.Body;
            int headX = snakeBody[0].Position.X;
            int headY = snakeBody[0].Position.Y;
            this.occupiedCells[headX + 1, headY + 1] = true;

            int tailIndex = snakeBody.Count - 1;
            int tailX = snakeBody[tailIndex].Position.X;
            int tailY = snakeBody[tailIndex].Position.Y;
            this.occupiedCells[tailX + 1, tailY + 1] = false;
        }

        /// <summary>
        /// Checks for collisions and makes necessary changes if a collision is found.
        /// </summary>
        private void CheckForCollisions()
        {
            if (CollisionDetector.CheckForCollision(this.snake,this.food))
            {
                this.snake.Grow();
                ChangeFoodPosition(this.food);
                this.score += food.Points;
            }

            if (CollisionDetector.CheckForCollision(this.snake,this.WorldWidth,this.WorldHeight))
            {
                throw new InvalidOperationException("Game Over");
            }
        }

        /// <summary>
        /// Changes food's position to a not occupied cell.
        /// </summary>
        /// <param name="food"></param>
        private void ChangeFoodPosition(Food food)
        {
            Random rand = new Random();
            int startX = rand.Next(1, this.WorldWidth);
            int startY = rand.Next(1, this.WorldHeight);

            for (int xPos = (startX + 1) % this.WorldWidth; xPos != startX; xPos = (xPos + 1) % this.WorldWidth)
            {
                for (int yPos = (startY + 1) % this.WorldHeight; yPos != startY; yPos = (yPos + 1) % this.WorldHeight)
                {
                    if (!this.occupiedCells[xPos + 1, yPos + 1])
                    {
                        food.ChangePosition(new Vector { X = xPos, Y = yPos });
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Game loop.
        /// </summary>
        public void Run()
        {
            try
            {
                while (true)
                {
                    keyboard.ProcessInput();
                    UpdateObjects();
                    CheckForCollisions();
                    UpdateCellsInfo();
                    RenderObjects();
                    System.Threading.Thread.Sleep(SleepTimeInMS);
                }
            }
            catch (InvalidOperationException)
            {
                renderer.PrintGameOver(this.score);
            }
        }
    }
}