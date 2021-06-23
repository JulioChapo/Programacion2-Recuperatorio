using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Resultado
    {

        public string ID { get; set; }
        public bool Ok { get; set; }
        public string Error { get; set; }

        public Resultado(string error, bool ok)
        {
            this.Ok = ok;
            this.Error = error;
        }

        public Resultado(bool ok,string id)
        {
            this.Ok = ok;
            this.ID = id;
        }
    }
}
