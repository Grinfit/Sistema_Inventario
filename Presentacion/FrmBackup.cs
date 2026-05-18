using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.IO;

using Sistema_Inventario.Datos;
using Sistema_Inventario.Utilidades;

namespace Sistema_Inventario.Presentacion
{
    public partial class FrmBackup : Form
    {
        Conexion cn = new Conexion();

        Logger log = new Logger();

        string rutaBackup = "";

        public FrmBackup()
        {
            InitializeComponent();
        }

        private void btnRuta_Click(
            object sender,
            EventArgs e)
        {
            FolderBrowserDialog carpeta =
                new FolderBrowserDialog();

            if (carpeta.ShowDialog() == DialogResult.OK)
            {
                rutaBackup = carpeta.SelectedPath;

                txtRuta.Text = rutaBackup;
            }
        }

        private void btnBackup_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                if (rutaBackup == "")
                {
                    MessageBox.Show(
                        "Seleccione una ruta");

                    return;
                }

                string nombreBackup =
                    "Inventario_" +
                    DateTime.Now.ToString(
                        "yyyyMMdd_HHmmss") +
                    ".bak";

                string rutaCompleta =
                    rutaBackup + "\\" + nombreBackup;

                string query =
                    "BACKUP DATABASE Inventario " +
                    "TO DISK = '" + rutaCompleta + "'";

                SqlCommand cmd = new SqlCommand(
                    query,
                    cn.AbrirConexion());

                cmd.ExecuteNonQuery();

                txtUltimoBackup.Text =
                    DateTime.Now.ToString();

                MessageBox.Show(
                    "Backup generado correctamente");

                log.RegistrarLog(
                    "BACKUP",
                    "admin",
                    "Backup generado correctamente");

                cn.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                log.RegistrarLog(
                    "ERROR BACKUP",
                    "admin",
                    ex.Message);
            }
        }

        private void btnRestore_Click(
            object sender,
            EventArgs e)
        {
            OpenFileDialog abrir =
                new OpenFileDialog();

            abrir.Filter =
                "Backup (*.bak)|*.bak";

            if (abrir.ShowDialog() ==
                DialogResult.OK)
            {
                try
                {
                    DateTime inicio =
                        DateTime.Now;

                    string query =
                        "USE master " +
                        "ALTER DATABASE Inventario " +
                        "SET SINGLE_USER WITH ROLLBACK IMMEDIATE " +

                        "RESTORE DATABASE Inventario " +
                        "FROM DISK='" + abrir.FileName + "' " +
                        "WITH REPLACE " +

                        "ALTER DATABASE Inventario " +
                        "SET MULTI_USER";

                    SqlCommand cmd = new SqlCommand(
                        query,
                        cn.AbrirConexion());

                    cmd.ExecuteNonQuery();

                    DateTime fin =
                        DateTime.Now;

                    TimeSpan rto =
                        fin - inicio;

                    MessageBox.Show(
                        "Base restaurada correctamente\n\n" +
                        "RTO: " +
                        rto.TotalSeconds +
                        " segundos");

                    log.RegistrarLog(
                        "RESTORE",
                        "admin",
                        "Base restaurada correctamente");

                    cn.CerrarConexion();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                    log.RegistrarLog(
                        "ERROR RESTORE",
                        "admin",
                        ex.Message);
                }
            }
        }
    }
}