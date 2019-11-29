using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Visitor
{
    public abstract class Figure
    {
        public string Name { get; set; }
        public Color FigureColor { get; set; }

        public abstract void AcceptGetAreaVisitor(IAreaVisitor visitor);

        public virtual void AcceptDrawVisitor(int x, int y, IDrawVisitor visitor)
        {
            visitor.Visit(this, x, y);
        }

        public virtual void AcceptColorizeVisitor(Color color, IColorizeVisitor visitor)
        {
            visitor.Visit(this, color);
        }
    }

    public class Triangle : Figure
    {
        public readonly int A;
        public readonly int B;
        public readonly int C;

        public Triangle(int a, int b, int c)
        {
            Name = "Triangle";

            A = a;
            B = b;
            C = c;
        }

        public override void AcceptGetAreaVisitor(IAreaVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Square : Figure
    {
        public readonly int A;

        public Square(int a)
        {
            Name = "Square";
            A = a;
        }

        public override void AcceptGetAreaVisitor(IAreaVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Circle : Figure
    {
        public Color Color { get; set; }

        public readonly int R;

        public Circle(int r)
        {
            Name = "Circle";
            R = r;
        }

        public override void AcceptGetAreaVisitor(IAreaVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
