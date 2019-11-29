using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            var figures = new List<Figure> {new Circle(10), new Square(20), new Triangle(3, 4, 5)};

            var areaVisitor = new AreaVisitor();
            var colorVisitor = new ColorizeVisitor();
            var drawVisitor = new DrawVisitor();

            foreach (var figure in figures)
            {
                figure.AcceptColorizeVisitor(Color.Blue, colorVisitor);
                figure.AcceptDrawVisitor(0,0, drawVisitor);
                figure.AcceptGetAreaVisitor(areaVisitor);
            }
            //Output:
            //Drawing Circle on position 0, 0
            //Circle's area: 314,159265358979
            //Drawing Square on position 0, 0
            //Square's area: 400
            //Drawing Triangle on position 0, 0
            //Triangle's area: 6
        }
    }
}
