using ClosedXML.Excel;
using System;
using System.Data;
using System.Windows.Forms;

namespace Sistema_Inventario.Utilidades
{
    public class ExportarExcel
    {
        public static void Exportar(
            DataGridView dgv,
            string nombreArchivo)
        {
            try
            {
                if (dgv.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "No hay datos para exportar.");

                    return;
                }

                SaveFileDialog save =
                    new SaveFileDialog();

                save.Filter =
                    "Excel Workbook|*.xlsx";

                save.FileName =
                    nombreArchivo + ".xlsx";

                if (save.ShowDialog()
                    == DialogResult.OK)
                {
                    DataTable dt =
                        new DataTable();

                    // =====================================
                    // COLUMNAS
                    // =====================================

                    foreach (DataGridViewColumn columna
                        in dgv.Columns)
                    {
                        dt.Columns.Add(
                            columna.HeaderText);
                    }

                    // =====================================
                    // FILAS
                    // =====================================

                    foreach (DataGridViewRow fila
                        in dgv.Rows)
                    {
                        if (!fila.IsNewRow)
                        {
                            DataRow dr =
                                dt.NewRow();

                            for (int i = 0;
                                i < dgv.Columns.Count;
                                i++)
                            {
                                dr[i] =
                                    fila.Cells[i].Value;
                            }

                            dt.Rows.Add(dr);
                        }
                    }

                    // =====================================
                    // EXCEL
                    // =====================================

                    using (XLWorkbook wb =
                        new XLWorkbook())
                    {
                        wb.Worksheets.Add(
                            dt,
                            "Reporte");

                        wb.SaveAs(
                            save.FileName);
                    }

                    MessageBox.Show(
                        "Reporte exportado correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message);
            }
        }
    }
}