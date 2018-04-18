using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImportarData.BL
{
    public class NameColums
    {
        public class column
        {
            public const string albaran = "albaran";
            public const string destinatario = "destinatario";
            public const string direccion = "direccion";
            public const string poblacion = "poblacion";
            public const string cp = "cp";
            public const string provincia = "provincia";
            public const string telefono = "telefono";
            public const string observacviones = "observacviones";
            public const string fecha = "fecha";
        }
        public class maxLeng
        {
            public const int albaran = 10;
            public const int destinatario = 28;
            public const int direccion = 250;
            public const int poblacion = 10;
            public const int cp = 5;
            public const int provincia = 20;
            public const int telefono = 10;
            public const int observacviones = 500;

        }
        public class ColumnPostion
        {
            public const int albaran = 1;
            public const int destinatario = 2;
            public const int direccion = 3;
            public const int poblacion = 4;
            public const int cp = 5;
            public const int provincia = 6;
            public const int telefono = 7;
            public const int observacviones = 8;
            public const int fecha = 9;
        }

        public string getColumnName(int postionColumn)
        {
            string columnName = string.Empty;
            switch (postionColumn)
            {
                case ColumnPostion.albaran:
                    columnName = column.albaran;
                    break;
                case ColumnPostion.destinatario:
                    columnName = column.destinatario;
                    break;
                case ColumnPostion.direccion:
                    columnName = column.direccion;
                    break;
                case ColumnPostion.poblacion:
                    columnName = column.poblacion;
                    break;
                case ColumnPostion.cp:
                    columnName = column.cp;
                    break;
                case ColumnPostion.provincia:
                    columnName = column.provincia;
                    break;
                case ColumnPostion.telefono:
                    columnName = column.telefono;
                    break;
                case ColumnPostion.fecha:
                    columnName = column.fecha;
                    break;
            }
            return columnName;
        }
        public bool validaFecha(string fecha)
        {
            bool esValido = false;
            string[] format = new string[] { "dd-mm-YYY" };
            DateTime datetime;
            esValido =(DateTime.TryParseExact(fecha, format, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.NoCurrentDateDefault, out datetime)) ;
            return esValido;
        }
    }
}
