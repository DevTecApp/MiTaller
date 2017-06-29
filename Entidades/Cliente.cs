using System;
using System.Collections.Generic;
using System.Data;

namespace Entidades
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public TipoIdentificacion TipoIdentificacion { get; set; }
        public string NumeroIdentificacion { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string RazonSocial { get; set; }
        public string Celular { get; set; }

        public Cliente(DataRow row)
        {
            ClienteId = row.convert<int>("ClienteId");
            Nombre = row.convert<string>("Nombre");
            Apellido = row.convert<string>("Apellido");
            TipoIdentificacion = new TipoIdentificacion(row);
            NumeroIdentificacion = row.convert<string>("NumeroIdentificacion");
            Telefono = row.convert<string>("telefono");
            FechaCreacion = row.convert<DateTime>("FechaCreacion");
            RazonSocial = row.convert<string>("RazonSocial");
            Celular = row.convert<string>("Celular");
        }

        public static List<Cliente> DataTableToList(DataTable dataTable)
        {
            List<Cliente> Resultado = new List<Cliente>();
            foreach (DataRow row in dataTable.Rows)
            {
                Cliente cliente = new Cliente(row);
                Resultado.Add(cliente);
            }

            return Resultado;

        }


           




    }
}
