using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Excel = Microsoft.Office.Interop.Excel;
using ImportarData.Models;
using System.Globalization;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data;

namespace ImportarData.BL
{
    public class Encargos
    {
        Context.Context db = new Context.Context();
        public bool validaArchivo(HttpPostedFileBase file)
        {
            string filePath = string.Empty;
            var exte = string.Empty;
            if (file != null)
            {
                exte = Path.GetExtension(file.FileName);
            }
            return extension(exte);
        }

        public bool extension(string extension)
        {
            bool valido = false;
            switch (extension)
            {
                case ".xls": //Excel 97-03.
                    valido = true;
                    break;
                case ".xlsx": //Excel 07 and above.
                    valido = true;
                    break;
            }
            return valido;
        }
        public void Savefile(HttpPostedFileBase file, int fComienzo)
        {
            string path = HttpContext.Current.Server.MapPath("~/Uploads/" + file.FileName);
            if (System.IO.File.Exists(path))
            {
                Excel.Application application = new Excel.Application();
                Excel.Workbook workbook = application.Workbooks.Open(path);
                workbook.Close();
                System.IO.File.Delete(path);
            }
            else
            {
                file.SaveAs(path);
                cargarData(path, fComienzo);
            }

        }
        public void cargarData(string path, int fComienzo)
        {
            int buenos = 0;
            int malos = 0;
            Excel.Application application = new Excel.Application();
            Excel.Workbook workbook = application.Workbooks.Open(path);
            Excel.Worksheet worksheet = workbook.ActiveSheet;
            Excel.Range range = worksheet.UsedRange;

            NameColums c = new NameColums();

            int columnPosition = 1;
            bool tamanoValido = false;
            int sonBuenos = 0;
            int sonMalos = 0;

            int fila = 1;

            foreach (Excel.Range item in range.Rows)
            {
                if (fila >= 2)
                {
                    Models.Encargos e = new Models.Encargos();

                    e.albaran = dataValida(((Excel.Range)item.Cells[1]).Text, maxLengColumn(NameColums.column.albaran));
                    e.destinatario = dataValida(((Excel.Range)item.Cells[2]).Text, maxLengColumn(NameColums.column.destinatario));
                    e.direccion = dataValida(((Excel.Range)item.Cells[3]).Text, maxLengColumn(NameColums.column.direccion));
                    e.poblacion = dataValida(((Excel.Range)item.Cells[4]).Text, maxLengColumn(NameColums.column.poblacion));
                    e.cp = dataValida(((Excel.Range)item.Cells[5]).Text, maxLengColumn(NameColums.column.cp));
                    e.provincia = dataValida(((Excel.Range)item.Cells[6]).Text, maxLengColumn(NameColums.column.provincia));
                    e.telefono = dataValida(((Excel.Range)item.Cells[7]).Text, maxLengColumn(NameColums.column.telefono));
                    e.observacviones = dataValida(((Excel.Range)item.Cells[8]).Text, maxLengColumn(NameColums.column.observacviones));
                    //if (c.validaFecha(((Excel.Range)item.Cells[9]).Text))
                    e.fecha =((Excel.Range)item.Cells[9]).Text;

                    foreach (Excel.Range column in item.Columns)
                    {
                        string value = Convert.ToString(column.Value);
                        string colmunName = c.getColumnName(columnPosition);
                        tamanoValido = maxLengthValido(colmunName, value);
                        sonBuenos = (tamanoValido) ? sonBuenos++ : 0;
                        sonMalos = (!tamanoValido) ? sonMalos++ : 0;
                        e.registroBuenos = sonMalos;
                        e.registrosMalos = sonMalos;
                        columnPosition++;
                    }
                    db.Encargos.Add(e);
                }
                fila++;
            }
            workbook.Close();
            db.SaveChanges();
        }
        public bool maxLengthValido(string columName, string columnValue)
        {
            int b = 0;
            bool esValido = false;
            if (!string.IsNullOrEmpty(columName) && !string.IsNullOrEmpty(columnValue))
            {
                int max = maxLengColumn(columName);
                esValido = ((max >= columnValue.Length));
            }
            return esValido;
        }

        public int maxLengColumn(string column)
        {
            int maxLength = 0;
            switch (column)
            {
                case BL.NameColums.column.albaran:
                    maxLength = BL.NameColums.maxLeng.albaran;
                    break;
                case BL.NameColums.column.destinatario:
                    maxLength = BL.NameColums.maxLeng.destinatario;
                    break;
                case BL.NameColums.column.direccion:
                    maxLength = BL.NameColums.maxLeng.direccion;
                    break;
                case BL.NameColums.column.poblacion:
                    maxLength = BL.NameColums.maxLeng.poblacion;
                    break;
                case BL.NameColums.column.cp:
                    maxLength = BL.NameColums.maxLeng.cp;
                    break;
                case BL.NameColums.column.provincia:
                    maxLength = BL.NameColums.maxLeng.provincia;
                    break;
                case BL.NameColums.column.telefono:
                    maxLength = BL.NameColums.maxLeng.telefono;
                    break;
                case BL.NameColums.column.observacviones:
                    maxLength = BL.NameColums.maxLeng.observacviones;
                    break;
            }
            return maxLength;
        }
        public string dataValida(string text, int maxLength)
        {
            return text.Length > maxLength ? text.Substring(0, maxLength) : text != string.Empty ?  text:"N/A";
        }

    }
}
