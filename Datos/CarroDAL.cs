using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class CarroDAL
    {
        public int Insert(Carro carro)
        {
            int CarroId = 0;
            var result = Utilidades.EjecutarProcedimiento("Carro_insert"
                , carro.ClienteId
                , carro.Placa
                , carro.Marca
                , carro.Color
                , carro.Modelo
                );
            CarroId = Convert.ToInt32(result);
            return CarroId;
        }

        public List<Carro> GetByFiltros(string marca, string placa, string modelo, int clienteId)
        {
            var dataSet = Utilidades.EjecutarSelect("Carro_getByFiltros"
                                                      ,marca
                                                      ,placa
                                                      ,modelo
                                                      ,clienteId
                                                     );
            return Carro.DataTableToList(dataSet.Tables[0]);        }

        public void Update(Carro carro)
        {
            Utilidades.EjecutarProcedimiento("Carro_Update"
                                            , carro.CarroId
                                            , carro.Color
                                            , carro.Placa
                                            , carro.Modelo
                                            );
        }
    }
}
