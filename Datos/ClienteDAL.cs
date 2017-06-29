using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace Datos
{
    public class ClienteDAL
    {
        public int Insert(Cliente cliente)
        {
            int ClienteId = 0;
            var result = Utilidades.EjecutarProcedimiento("Cliente_Insert"
                                            , cliente.TipoIdentificacion.TipoIdentificacionId
                                            , cliente.NumeroIdentificacion
                                            , cliente.Apellido
                                            , cliente.RazonSocial
                                            , cliente.Telefono
                                            , cliente.Celular
                                            );
            ClienteId = Convert.ToInt32(result);
            return ClienteId;
        }

        public List<Cliente> GetByFiltros(DateTime fechaInicial, DateTime fechaFinal, string NombreApellidoRazon, string Identificacion)
        {
            var dataSet = Utilidades.EjecutarSelect("Cliente_getByFiltros"
                                                    , fechaInicial
                                                    , fechaFinal
                                                    , NombreApellidoRazon
                                                    , Identificacion
                                                    );
            return Cliente.DataTableToList(dataSet.Tables[0]);
        }

        public void Update(Cliente cliente)
        {
            Utilidades.EjecutarProcedimiento("Cliente_Update"
                                            , cliente.ClienteId
                                            , cliente.TipoIdentificacion.TipoIdentificacionId
                                            , cliente.NumeroIdentificacion
                                            , cliente.Apellido
                                            , cliente.RazonSocial
                                            , cliente.Telefono
                                            , cliente.Celular
                                            );
        }
    }
}
