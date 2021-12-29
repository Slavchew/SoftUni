using System;
using System.Collections.Generic;
using System.Text;

namespace BoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get
            {
                return this.length;
            }
            private set
            {
                this.ValidateSide(value, nameof(Length));
                this.length = value;
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                this.ValidateSide(value, nameof(Width));
                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                this.ValidateSide(value, nameof(Height));
                this.height = value;
            }
        }

        public double CalculateSurfaceArea()
        {
            return (2 * this.Length * this.Width) + CalculateLateralSurfaceArea(); 
        }
        public double CalculateLateralSurfaceArea()
        {
            return (2 * this.Length * this.Height) + (2 * this.Width * this.Height);
        }
        public double CalculateVolume()
        {
            return this.Length * this.Width * this.Height;
        }
        private void ValidateSide(double side, string paramName)
        {
            if (side <= 0)
            {
                throw new ArgumentException($"{paramName} cannot be zero or negative.");
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Surface Area - {this.CalculateSurfaceArea():f2}");
            sb.AppendLine($"Lateral Surface Area - {this.CalculateLateralSurfaceArea():f2}");
            sb.AppendLine($"Volume - {this.CalculateVolume():f2}");

            return sb.ToString().TrimEnd();
        }

    }
}
