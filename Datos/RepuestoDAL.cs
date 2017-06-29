using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Datos
{
    public class RepuestoDAL
    {
        public int Insert(Repuesto repuesto)
        {
            int RepuestoId = 0;
            var result = Utilidades.EjecutarProcedimiento("Repuesto_insert"
                , repuesto.Marca
                , repuesto.Modelo
                , repuesto.Precio
                , repuesto.Nombre
                ,repuesto.Descontinuado
                );
            RepuestoId = Convert.ToInt32(result);
            return RepuestoId;


        }

        public List<Repuesto> GetByFiltros(string nombre, string marca, string modelo, decimal precio)
        {
            var dataSet = Utilidades.EjecutarSelect("Repuesto_getByFiltro"
                                                    ,nombre
                                                    ,marca
                                                    ,modelo
                                                     ,precio
                                                    );
            return Repuesto.DataTableToList(dataSet.Tables[0]);

        }
        public void Update (Repuesto repuesto)
        {
            Utilidades.EjecutarProcedimiento("Repuesto_Update"
                                            , repuesto.RepuestoId
                                            , repuesto.Marca
                                            , repuesto.Modelo
                                            , repuesto.Precio
                                            , repuesto.Nombre
                                            , repuesto.Descontinuado

                                             );


        }
                                                    

    }

}
