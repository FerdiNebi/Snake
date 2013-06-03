using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySnake
{
    public static class CollisionDetector
    {
        public static bool CheckForCollision(Snake snake, Food food)
        {
            SnakeParticle snakeHead = snake.Body[0];
            if (food.GetPosition() == snakeHead.GetPosition())
            {
                return true;
            }

            return false;
        }

        public static bool CheckForCollision(Snake snake,int screenWidth, int screenHeight)
        {
            SnakeParticle snakeHead = snake.Body[0];
            for (int i = 1; i < snake.Body.Count; i++)
            {
                if (snakeHead.GetPosition() == snake.Body[i].GetPosition())
                {
                    return true;
                }
            }

            if (snakeHead.Position.X < 0 || snakeHead.Position.X >= screenWidth ||
                snakeHead.Position.Y < 0 || snakeHead.Position.Y >= screenHeight)
            {
                return true;
            }

            return false;
        }
    }
}