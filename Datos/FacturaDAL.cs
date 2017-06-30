using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Datos
{
    public class FacturaDAL
    {
        public int Insert(Factura factura)
        {
            int FacturaId = 0;
            var result = Utilidades.EjecutarProcedimiento("Factura_insert"
                 ,factura.Carro.CarroId
                 ,factura.Total
                 ,factura.DescuentoDecimal
                 );
            FacturaId = Convert.ToInt32(result);
            return FacturaId;

        }




    }
}
