using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySnake
{
    public class Snake
    {
        private readonly List<SnakeParticle> body;

        public Snake(Vector snakeHeadPosition, Vector direction)
        {
            body = new List<SnakeParticle>();
            body.Add(new SnakeParticle(snakeHeadPosition, direction));
            body.Add(new SnakeParticle(snakeHeadPosition - direction, direction));
            body.Add(new SnakeParticle(snakeHeadPosition - 2 * direction, direction));
        }

        public List<SnakeParticle> Body
        {
            get
            {
                return this.body;
            }
        }

        public void Move()
        {
            foreach (SnakeParticle particle in this.body)
            {
                particle.Update();
            }

            //Update directions for every particle
            for (int i = this.body.Count - 1; i > 0; i--)
            {
                this.body[i].Direction = this.body[i - 1].Direction;
            }
        }

        public void ChangeDirection(Vector newDirection)
        {
            SnakeParticle headOfTheSnake = this.body[0];

            if (headOfTheSnake.Direction != newDirection &&
                headOfTheSnake.Direction != newDirection.GetOpposite())
            {
                headOfTheSnake.Direction = newDirection;
            }
        }

        public void Grow()
        {
            SnakeParticle tail = this.body[this.body.Count - 1];
            body.Add(new SnakeParticle(tail.Position - tail.Direction, tail.Direction));
        }
    }
}