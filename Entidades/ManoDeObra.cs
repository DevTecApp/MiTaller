using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Entidades
{
    public class ManoDeObra
    {
        public int ManoDeObraId { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }


        public ManoDeObra(DataRow row)
        {
            ManoDeObraId = row.convert<int>("ManoDeObraId");
            Descripcion = row.convert<string>("Descripcion");
            Precio = row.convert<decimal>("Precio");
        }

        public static List<ManoDeObra> DataTableToList (DataTable dataTable)
        {
            List<ManoDeObra> Resultado = new List<ManoDeObra>();
            foreach (DataRow row in dataTable.Rows)
            {
                ManoDeObra manodeobra = new ManoDeObra(row);
                Resultado.Add(manodeobra);
            }
            return Resultado;
        }

    }

        
}
