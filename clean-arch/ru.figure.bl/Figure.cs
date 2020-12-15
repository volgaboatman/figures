using System;

namespace ru.figure.bl
{
    public abstract class Figure
    {
        public Guid Id { get; set; }

        public abstract Double Area();
    }

    public class Circle: Figure
    {
        public int Radius { get; set; }

        public override double Area()
        {
            return Math.PI * Radius * Radius;
        }
    }

    public class Triangle: Figure
    {
        public int A { get; set; }
        public int B { get; set; }
        public int Angle { get; set; }

        public override double Area()
        {
            return Math.Sin(Math.PI* Angle / 180) * A * B;
        }
    }
}
