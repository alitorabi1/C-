using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooSimple
{
    class Animal
    {
        public string Species { get; set; }
        public int Age { get; set; }

        // long version - usually not worth using
        private string _Name;
        public string Name {
            get { return _Name; }
            set { _Name = value; }
        }

        public double Weight { get; set; }
    }
}
