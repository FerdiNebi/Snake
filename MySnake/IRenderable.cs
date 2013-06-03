using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySnake
{
    public interface IRenderable
    {
        Vector GetPosition();
        char GetImage();
    }
}