using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Entidades
{
     public class  Carro
    {
        public int CarroId { get; set; }
        public string Marca { get; set; }
        public string Placa { get; set;}
        public string Color { get; set; }
        public string Modelo { get; set;}
        public int ClienteId { get; set; }


        public Carro(DataRow row)
        {
            CarroId = row.convert<int>("CarroId");
            Marca = row.convert<string>("Marca");
            Placa = row.convert<string>("Placa");
            Color = row.convert<string>("Color");
            Modelo = row.convert<string>("Modelo");
            ClienteId = row.convert<int>("ClienteId");
        }
        public static List<Carro> DataTableToList(DataTable dataTable)
        {
            List<Carro> Resultado = new List<Carro>();
            foreach (DataRow row in dataTable.Rows)
            {
                Carro carro = new Carro(row);
                Resultado.Add(carro);
            }

            return Resultado;

        }







    }


}
