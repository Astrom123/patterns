using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    public interface IVisitorBase
    {
        string OperationName { get; }
    }

    public interface IAreaVisitor : IVisitorBase
    {
        void Visit(Triangle figure);
        void Visit(Circle figure);
        void Visit(Square figure);
    }

    public interface IDrawVisitor : IVisitorBase
    {
        void Visit(Figure figure, int x, int y);
    }

    public interface IColorizeVisitor : IVisitorBase
    {
        void Visit(Figure figure, Color color);
    }

    public class AreaVisitor : IAreaVisitor
    {
        public string OperationName => "GetArea";

        public void Visit(Triangle figure)
        {
            var halfPerimeter = (figure.A + figure.B + figure.C) / 2;
            Console.WriteLine("Triangle's area: " + Math.Sqrt(halfPerimeter * (halfPerimeter - figure.A) * (halfPerimeter - figure.B) *
                             (halfPerimeter - figure.C)));
        }

        public void Visit(Circle figure)
        {
            Console.WriteLine("Circle's area: " + Math.PI * Math.Pow(figure.R, 2));
        }

        public void Visit(Square figure)
        {
            Console.WriteLine("Square's area: " + Math.Pow(figure.A, 2));
        }
    }

    public class DrawVisitor : IDrawVisitor
    {
        public string OperationName => "Drawing";

        public void Visit(Figure figure, int x, int y)
        {
            Console.WriteLine($"Drawing {figure.Name} on position {x}, {y}");
        }
    }

    public class ColorizeVisitor : IColorizeVisitor
    {
        public string OperationName => "Coloring";

        public void Visit(Figure figure, Color color)
        {
            figure.FigureColor = color;
        }
    }
};

