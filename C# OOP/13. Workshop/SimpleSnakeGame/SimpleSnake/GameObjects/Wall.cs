using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Wall : Point
    {
        public Wall(int leftX, int topY) 
            : base(leftX, topY)
        {
            InitializeWallBorders();
        }

        private void InitializeWallBorders()
        {
            this.SetHorizontalLine(0);
            this.SetHorizontalLine(this.TopY);

            this.SetVerticalLine(0);
            this.SetVerticalLine(this.LeftX);
        }

        public void SetHorizontalLine(int top)
        {
            for (int leftX = 0; leftX <= this.LeftX; leftX++)
            {
                this.Draw(leftX, top, '■');
            }
        }

        public void SetVerticalLine(int left)
        {
            for (int topY = 0; topY <= this.TopY; topY++)
            {
                this.Draw(left, topY, '■');
            }
        }

    }
}
