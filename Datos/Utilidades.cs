using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Datos
{
    class Utilidades
    {
        public static object EjecutarProcedimiento(string nombreProcedimientoAlmacenado,params object[] parametros)
        {
            try
            {
                //Clase que se conecta con la base de datos
                using (SqlConnection con = new SqlConnection(""))
                {
                    //clase que ejecuta un comando en la base de datos
                    using (SqlCommand cmd = new SqlCommand(nombreProcedimientoAlmacenado, con))
                    {
                        //abre la conexion con la base de datos
                        con.Open();

                        //Indica que se va a llamar un procedimiento en la base de datps
                        cmd.CommandType = CommandType.StoredProcedure;

                        //Obtiene la lista de parametros que recibe el procedimiento almacenado
                        SqlCommandBuilder.DeriveParameters(cmd);

                        for(int i = 1; i < parametros.Length; i++)
                        {
                            cmd.Parameters[i].Value = parametros[i];
                        }
                        
                        //ejecuta el comando en la base de datos
                        cmd.ExecuteNonQuery();

                        return cmd.Parameters[0].Value;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet EjecutarSelect(string nombreProcedimientoAlmacenado, params object[] parametros)
        {
            try
            {
                DataSet ds = new DataSet();

                //Clase que se conecta con la base de datos
                using (SqlConnection con = new SqlConnection(""))
                {
                    //clase que ejecuta un comando en la base de datos
                    using (SqlCommand cmd = new SqlCommand(nombreProcedimientoAlmacenado, con))
                    {
                        //el adaptar se encarga de traer conjuntos de datos de la base
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            //abre la conexion con la base de datos
                            con.Open();

                            //Indica que se va a llamar un procedimiento en la base de datps
                            cmd.CommandType = CommandType.StoredProcedure;

                            //Obtiene la lista de parametros que recibe el procedimiento almacenado
                            SqlCommandBuilder.DeriveParameters(cmd);

                            for (int i = 1; i < parametros.Length; i++)
                            {
                                cmd.Parameters[i].Value = parametros[i];
                            }

                            //Carga el dataset con lo que devuelve la base de datos
                            adapter.Fill(ds);

                            return ds;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
