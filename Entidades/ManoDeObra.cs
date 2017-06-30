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

        public static DataTable ListToDataTable(List<ManoDeObra> list, int FacturaId)
        {
            DataTable dt = new DataTable(); //Crea una tabla vacia

            //Agrega nombres de columnas a la tabla
            dt.Columns.Add("Descripcion");
            dt.Columns.Add("Precio");
            dt.Columns.Add("FacturaId");

            //Por cada objeto de mano de obra en la lista, inserta un registro en la tabla
            foreach (ManoDeObra man in list)
            {
                DataRow dr = dt.NewRow(); //crea un registro
                dr["Descripcion"] = man.Descripcion; //pone la descripcion en la columna de descripcion.
                dr["Precio"] = man.Precio; //pone el precio en la columna de precio
                dr["FacturaId"] = FacturaId; //pone el id de la factura

                dt.Rows.Add(dr); //agrega el registro a la tabla
            }

            return dt;
        }

    }

        
}
