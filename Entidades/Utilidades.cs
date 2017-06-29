using System;
using System.Data;

namespace Entidades
{
    public static class Utilidades
    {
        public static T convert<T>(this DataRow row, string nombreColumna)
        {
            Type t = typeof(T);
            t = Nullable.GetUnderlyingType(t) ?? t;
            T result = default(T);

            if (row.Table.Columns.Contains(nombreColumna))
            {
                try
                {
                    if (t == typeof(bool))
                    {
                        string dato = row[nombreColumna].ToString();
                        bool resultado = dato.Equals("1") || dato.ToLower().Equals("true");
                        result = (T)Convert.ChangeType(resultado, t);
                    }
                    else
                    {
                        result = (T)Convert.ChangeType(row[nombreColumna], t);
                    }
                }
                catch
                {
                    result = default(T);
                }
            }
            else
            {
                //throw new ArgumentException(string.Format("La columna {0} no pertenece a la tabla", nombreColumna));
                result = default(T);
            }
            return result;
        }
    }
}
