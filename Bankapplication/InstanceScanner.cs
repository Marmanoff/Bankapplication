using StructureMap;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bankapplication
{
    class InstanceScanner : Registry
    {
        public InstanceScanner()
        {
            //Söker efter interface via convention, genom klassnamnet med ett "i" före.
            Scan(c =>
            {
                c.TheCallingAssembly();
                c.WithDefaultConventions();
            });
        }
    }
}
