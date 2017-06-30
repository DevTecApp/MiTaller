using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Factura
    {
        public int Facturaid { get; set; }
        public Carro Carro { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }
        public decimal DescuentoDecimal { get; set;}
        public List<Repuesto> Repuestos { get; set; }
        public List<ManoDeObra> ManosDeObra { get; set; }
        public bool Anulada { get; set; }
        public DateTime? FechaAnulacion { get; set; }
    }
}
