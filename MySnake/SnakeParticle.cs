using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySnake
{
    public class SnakeParticle : MovingObject
    {
        public SnakeParticle(Vector position, Vector direction)
        {
            this.Position = position;
            this.Direction = direction;
            this.image = '#';
        }

        public Vector Direction
        {
            get
            {
                return this.direction;
            }
            set
            {
                this.direction = value;
            }
        }

        public Vector Position
        {
            get
            {
                return this.position;
            }
            set
            {
                this.position = value;
            }
        }

        public override void Update()
        {
            this.Position += this.Direction;
        }
    }
}