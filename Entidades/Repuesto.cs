using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Entidades
{
    public class Repuesto
    {
        public int RepuestoId { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public decimal Precio { get; set; }
        public bool Descontinuado { get; set; }

        public Repuesto(DataRow row)
        {
            RepuestoId = row.convert<int>("RepuestoId");
            Nombre = row.convert<string>("Nombre");
            Marca = row.convert<string>("Marca");
            Modelo = row.convert<string>("Modelo");
            Precio = row.convert<decimal>("Precio");
            Descontinuado = row.convert<bool>("Descontinuado");
        }
        public static List<Repuesto> DataTableToList(DataTable dataTable )
        {
            List<Repuesto> Resultado = new List<Repuesto>();
            foreach (DataRow row in dataTable.Rows)
            {
                Repuesto repuesto = new Repuesto(row);
                Resultado.Add(repuesto);
            }

            return Resultado;
        }
        public static DataTable ListToDataTable(List<Repuesto> list, int FacturaId)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("FacturaId");
            dt.Columns.Add("Precio");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Cantidad");

            var algo = list.GroupBy(x => x.RepuestoId).Select(x => new { Nombre = x.First().Nombre, Precio = x.Sum(j => j.Precio), Cantidad = x.Count() }).ToList();

            foreach(Repuesto repuesto in list)
            {
                DataRow dr = dt.NewRow();
                dr["FacturaId"] = FacturaId;
                dr["Precio"] = repuesto.Precio;
                dr["Nombre"] = repuesto.Nombre;
                //dr["Cantidad"] = repuesto.Cantidad;
            }

            return dt;
        }
    }
}
