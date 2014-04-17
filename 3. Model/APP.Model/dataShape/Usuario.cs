using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Model.dataShape
{
    public class Usuario : DataShape<Usuario>
    {
        public double iid { get; set; }
        public string login { get; set; }
        public string senha { get; set; }

    }
}
