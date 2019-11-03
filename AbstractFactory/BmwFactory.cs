using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class BmwFactory : ICarFactory
    {
        public ICarEngine CreateEngine()
        {
            return new BmwEngine();
        }

        public ICarBody CreateBody()
        {
            return new BmwBody();
        }
    }

    public class BmwEngine : ICarEngine
    {
        string ICarEngine.Model => "BmwEngine";
    }

    public class BmwBody : ICarBody
    {
        string ICarBody.Model => "BmwBody";
    }
}
