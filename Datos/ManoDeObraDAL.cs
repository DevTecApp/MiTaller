using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;


namespace Datos
{
    public class ManoDeObraDAL
    {
        public int Insert(ManoDeObra manodeobra)
        {

            int ManoDeObraId = 0;
            var result = Utilidades.EjecutarProcedimiento("ManoDeObra_insert"
                , manodeobra.ManoDeObraId
                , manodeobra.Descripcion
                , manodeobra.Precio
                );
            ManoDeObraId = Convert.ToInt32(result);
            return ManoDeObraId;
        }
        public List<ManoDeObra>GetByFiltros(decimal precio,string descripcion)
        {
            var dataSet = Utilidades.EjecutarSelect("ManoDeObra_getByFiltro"
                                                           ,precio
                                                           ,descripcion
                                                            );

            return ManoDeObra.DataTableToList(dataSet.Tables[0]);
        }
        public void Update (ManoDeObra manodeobra)
        {

            Utilidades.EjecutarProcedimiento("ManoDeObra_Update"
                                             ,manodeobra.ManoDeObraId
                                             ,manodeobra.Precio
                                             ,manodeobra.Precio
                                             );

        }

    }
}
