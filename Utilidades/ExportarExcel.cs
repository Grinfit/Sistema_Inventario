// IMPORTACION DE LIBRERIA PARA MANEJO DE EXCEL
using ClosedXML.Excel;

// IMPORTACION DE LIBRERIAS NECESARIAS
using System;
using System.Data;
using System.Windows.Forms;

namespace Sistema_Inventario.Utilidades
{
    // CLASE ENCARGADA DE EXPORTAR DATOS A EXCEL
    public class ExportarExcel
    {
        // METODO ESTATICO PARA EXPORTAR UN DATAGRIDVIEW A EXCEL
        public static void Exportar(
            DataGridView dgv,
            string nombreArchivo)
        {
            try
            {
                // VERIFICA SI EL GRID TIENE DATOS
                if (dgv.Rows.Count == 0)
                {
                    // MENSAJE SI NO EXISTEN DATOS
                    MessageBox.Show(
                        "No hay datos para exportar.");

                    return;
                }

                // CREACION DEL SAVEFILEDIALOG
                SaveFileDialog save =
                    new SaveFileDialog();

                // FILTRO PARA ARCHIVOS EXCEL
                save.Filter =
                    "Excel Workbook|*.xlsx";

                // NOMBRE DEL ARCHIVO
                save.FileName =
                    nombreArchivo + ".xlsx";

                // VERIFICA SI EL USUARIO GUARDO EL ARCHIVO
                if (save.ShowDialog()
                    == DialogResult.OK)
                {
                    // CREACION DE TABLA TEMPORAL
                    DataTable dt =
                        new DataTable();

                    // =====================================
                    // COLUMNAS
                    // =====================================

                    // RECORRE LAS COLUMNAS DEL DATAGRIDVIEW
                    foreach (DataGridViewColumn columna
                        in dgv.Columns)
                    {
                        // AGREGA LAS COLUMNAS AL DATATABLE
                        dt.Columns.Add(
                            columna.HeaderText);
                    }

                    // =====================================
                    // FILAS
                    // =====================================

                    // RECORRE LAS FILAS DEL DATAGRIDVIEW
                    foreach (DataGridViewRow fila
                        in dgv.Rows)
                    {
                        // VERIFICA QUE NO SEA LA FILA NUEVA
                        if (!fila.IsNewRow)
                        {
                            // CREA UNA NUEVA FILA DEL DATATABLE
                            DataRow dr =
                                dt.NewRow();

                            // RECORRE LAS COLUMNAS
                            for (int i = 0;
                                i < dgv.Columns.Count;
                                i++)
                            {
                                // ASIGNA LOS DATOS DE LAS CELDAS
                                dr[i] =
                                    fila.Cells[i].Value;
                            }

                            // AGREGA LA FILA AL DATATABLE
                            dt.Rows.Add(dr);
                        }
                    }

                    // =====================================
                    // EXCEL
                    // =====================================

                    // CREACION DEL LIBRO DE EXCEL
                    using (XLWorkbook wb =
                        new XLWorkbook())
                    {
                        // AGREGA LA HOJA AL LIBRO
                        wb.Worksheets.Add(
                            dt,
                            "Reporte");

                        // GUARDA EL ARCHIVO EXCEL
                        wb.SaveAs(
                            save.FileName);
                    }

                    // MENSAJE DE EXPORTACION EXITOSA
                    MessageBox.Show(
                        "Reporte exportado correctamente.");
                }
            }
            catch (Exception ex)
            {
                // MUESTRA EL ERROR
                MessageBox.Show(
                    ex.Message);
            }
        }
    }
}