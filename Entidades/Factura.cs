using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Factura
    {
        int Facturaid { get; set; }
        Carro Carro { get; set; }
        decimal Total { get; set; }
        DateTime Fecha { get; set; }
        decimal DescuentoDecimal { get; set;}
        List<Repuesto> Repuestos { get; set; }
        List<ManoDeObra> ManosDeObra { get; set; }
        bool Anulada { get; set; }
        DateTime? FechaAnulacion { get; set; }
    }
}
