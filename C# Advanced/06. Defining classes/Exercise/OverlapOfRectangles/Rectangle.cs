using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverlapOfRectangles
{
    class Rectangle
    {
        public Rectangle(string id, int width, int height, int leftPoint, int topPoint)
        {
            Id = id;
            Width = width;
            Height = height;
            LeftPoint = leftPoint;
            TopPoint = topPoint;
        }

        public string Id { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int LeftPoint { get; set; }
        public int TopPoint { get; set; }

    }
}
