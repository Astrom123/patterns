using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class AudiFactory : ICarFactory
    {
        public ICarEngine CreateEngine()
        {
            return new AudiEngine();
        }

        public ICarBody CreateBody()
        {
            return new AudiBody();
        }
    }

    public class AudiEngine : ICarEngine
    {
        string ICarEngine.Model => "AudiEngine";
    }

    public class AudiBody : ICarBody
    {
        string ICarBody.Model => "AudiBody";
    }
}
