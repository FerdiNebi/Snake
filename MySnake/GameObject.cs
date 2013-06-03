using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySnake
{
    public abstract class GameObject : IRenderable
    {
        protected Vector position;
        protected char image;

        public virtual void Update()
        {
        }

        public virtual Vector GetPosition()
        {
            return this.position;
        }

        public virtual char GetImage()
        {
            return this.image;
        }
    }
}