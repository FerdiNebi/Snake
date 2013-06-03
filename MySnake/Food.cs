using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySnake
{
    public class Food : StaticObject
    {
        public Food(Vector position)
        {
            this.position = position;
            this.image = '@';
        }

        public virtual int Points
        {
            get { return 50; }
        }

        public void ChangePosition(Vector position)
        {
            this.position = position;
        }
    }
}
