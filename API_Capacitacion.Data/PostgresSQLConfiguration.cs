using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Capacitacion.Data
{
    public class PostgresSQLConfiguration
    {
        public string Connection {  get; set; }

        public PostgresSQLConfiguration(string connection) => Connection = connection;
    }
}
