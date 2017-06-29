using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Entidades
{
    public class TipoIdentificacion
    {
        public int TipoIdentificacionId { get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; }

        public TipoIdentificacion(DataRow row)
        {
            TipoIdentificacionId = row.convert<int>("TipoIdentificaconId");
            Descripcion = row.convert<string>("Descripcion");
            Codigo = row.convert<string>("codigo");
        }
    }
}
