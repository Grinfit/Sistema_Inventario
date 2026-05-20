// IMPORTACION DE LIBRERIAS NECESARIAS
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Sistema_Inventario.Utilidades;
using FontAwesome.Sharp;
using Sistema_Inventario.Datos;
using Sistema_Inventario.Utilidades;

namespace Sistema_Inventario.Presentacion
{
    // FORMULARIO DE PRODUCTOS
    public partial class FrmProductos : Form
    {
        // OBJETO DE CONEXION
        Conexion cn = new Conexion();

        // OBJETO LOGGER
        Logger log = new Logger();

        // VARIABLE PARA ID DEL PRODUCTO
        int IdProducto = 0;

        // CONSTRUCTOR DEL FORMULARIO
        public FrmProductos()
        {
            InitializeComponent();

            // APLICA LOS ESTILOS
            AplicarEstilos();
        }

        // METODO PARA APLICAR ESTILOS
        private void AplicarEstilos()
        {
            // CONFIGURA BOTON NUEVO
            ConfigurarBoton(btnNuevo,
                Color.FromArgb(52, 152, 219));

            // CONFIGURA BOTON GUARDAR
            ConfigurarBoton(btnGuardar,
                Color.FromArgb(46, 204, 113));

            // CONFIGURA BOTON EDITAR
            ConfigurarBoton(btnEditar,
                Color.FromArgb(241, 196, 15));

            // CONFIGURA BOTON ELIMINAR
            ConfigurarBoton(btnEliminar,
                Color.FromArgb(231, 76, 60));

            // CONFIGURA BOTON BUSCAR
            ConfigurarBoton(btnBuscar,
                Color.FromArgb(11, 31, 58));

            // CONFIGURA EL GRID
            ConfigurarGrid();
        }

        // METODO PARA CONFIGURAR BOTONES
        private void ConfigurarBoton(
            IconButton btn,
            Color color)
        {
            // COLOR DE FONDO
            btn.BackColor = color;

            // COLOR DEL TEXTO
            btn.ForeColor = Color.White;

            // ESTILO DEL BOTON
            btn.FlatStyle = FlatStyle.Flat;

            // BORDE DEL BOTON
            btn.FlatAppearance.BorderSize = 0;

            // FUENTE DEL BOTON
            btn.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold);

            // COLOR DEL ICONO
            btn.IconColor = Color.White;

            // TAMAÑO DEL ICONO
            btn.IconSize = 24;

            // RELACION TEXTO E IMAGEN
            btn.TextImageRelation =
                TextImageRelation.ImageBeforeText;

            // ALINEACION DE IMAGEN
            btn.ImageAlign =
                ContentAlignment.MiddleLeft;

            // PADDING DEL BOTON
            btn.Padding =
                new Padding(12, 0, 0, 0);

            // CURSOR DEL BOTON
            btn.Cursor =
                Cursors.Hand;

            // EVENTO MOUSE ENTER
            btn.MouseEnter +=
                (s, e) =>
                {
                    btn.BackColor =
                        ControlPaint.Dark(color);
                };

            // EVENTO MOUSE LEAVE
            btn.MouseLeave +=
                (s, e) =>
                {
                    btn.BackColor = color;
                };
        }

        // METODO PARA CONFIGURAR GRID
        private void ConfigurarGrid()
        {
            // BORDE DEL GRID
            dgvProductos.BorderStyle =
                BorderStyle.None;

            // COLOR DE FONDO
            dgvProductos.BackgroundColor =
                Color.White;

            // DESHABILITA ESTILOS VISUALES
            dgvProductos.EnableHeadersVisualStyles =
                false;

            // BORDE DE HEADERS
            dgvProductos.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;

            // COLOR HEADER
            dgvProductos.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(11, 31, 58);

            // COLOR TEXTO HEADER
            dgvProductos.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            // FUENTE HEADER
            dgvProductos.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Bold);

            // ALTURA HEADER
            dgvProductos.ColumnHeadersHeight = 45;

            // FUENTE FILAS
            dgvProductos.DefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    10F);

            // COLOR SELECCION
            dgvProductos.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(52, 152, 219);

            // COLOR TEXTO SELECCION
            dgvProductos.DefaultCellStyle.SelectionForeColor =
                Color.White;

            // COLOR FILAS
            dgvProductos.RowsDefaultCellStyle.BackColor =
                Color.White;

            // COLOR FILAS ALTERNAS
            dgvProductos.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(245, 247, 250);

            // ALTURA FILAS
            dgvProductos.RowTemplate.Height = 38;

            // AJUSTE AUTOMATICO COLUMNAS
            dgvProductos.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            // SELECCION COMPLETA
            dgvProductos.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            // DESHABILITA MULTISELECT
            dgvProductos.MultiSelect = false;

            // OCULTA HEADERS DE FILAS
            dgvProductos.RowHeadersVisible = false;

            // COLOR GRID
            dgvProductos.GridColor =
                Color.LightGray;
        }

        // EVENTO LOAD DEL FORMULARIO
        private void FrmProductos_Load(
            object sender,
            EventArgs e)
        {
            // MUESTRA LOS PRODUCTOS
            MostrarProductos();
        }

        // METODO PARA MOSTRAR PRODUCTOS
        private void MostrarProductos()
        {
            try
            {
                // ADAPTADOR DE DATOS
                SqlDataAdapter da =
                    new SqlDataAdapter(
                        "sp_MostrarProductos",
                        cn.AbrirConexion());

                // DEFINE STORED PROCEDURE
                da.SelectCommand.CommandType =
                    CommandType.StoredProcedure;

                // TABLA TEMPORAL
                DataTable dt =
                    new DataTable();

                // LLENA LA TABLA
                da.Fill(dt);

                // MUESTRA LOS DATOS
                dgvProductos.DataSource = dt;

                // CIERRA LA CONEXION
                cn.CerrarConexion();
            }
            catch (Exception ex)
            {
                // MUESTRA ERROR
                MessageBox.Show(ex.Message);

                // REGISTRA EL ERROR
                log.RegistrarLog(
                    "ERROR PRODUCTOS",
                    SesionUsuario.Usuario,
                    ex.Message);
            }
        }

        // METODO PARA LIMPIAR CAMPOS
        private void LimpiarCampos()
        {
            // LIMPIA NOMBRE
            txtNombre.Clear();

            // LIMPIA CATEGORIA
            txtCategoria.Clear();

            // LIMPIA PRECIO
            txtPrecio.Clear();

            // LIMPIA STOCK
            txtStock.Clear();

            // ENVIA EL FOCO
            txtNombre.Focus();
        }

        // EVENTO BOTON GUARDAR
        private void btnGuardar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                // COMANDO SQL
                SqlCommand cmd =
                    new SqlCommand(
                        "sp_InsertarProducto",
                        cn.AbrirConexion());

                // DEFINE STORED PROCEDURE
                cmd.CommandType =
                    CommandType.StoredProcedure;

                // PARAMETRO NOMBRE
                cmd.Parameters.AddWithValue(
                    "@Nombre",
                    txtNombre.Text);

                // PARAMETRO CATEGORIA
                cmd.Parameters.AddWithValue(
                    "@Categoria",
                    txtCategoria.Text);

                // PARAMETRO PRECIO
                cmd.Parameters.AddWithValue(
                    "@Precio",
                    txtPrecio.Text);

                // PARAMETRO STOCK
                cmd.Parameters.AddWithValue(
                    "@Stock",
                    txtStock.Text);

                // EJECUTA EL COMANDO
                cmd.ExecuteNonQuery();

                // MENSAJE DE CONFIRMACION
                MessageBox.Show(
                    "Producto guardado correctamente");

                // REGISTRA LOG
                log.RegistrarLog(
                    "PRODUCTO_CREATE",
                    SesionUsuario.Usuario,
                    "Producto agregado: " + txtNombre.Text);

                // ACTUALIZA EL GRID
                MostrarProductos();

                // LIMPIA LOS CAMPOS
                LimpiarCampos();

                // CIERRA LA CONEXION
                cn.CerrarConexion();
            }
            catch (Exception ex)
            {
                // MUESTRA ERROR
                MessageBox.Show(ex.Message);
            }
        }

        // EVENTO CLICK GRID
        private void dgvProductos_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            try
            {
                // VALIDA FILA
                if (e.RowIndex >= 0)
                {
                    // OBTIENE EL ID
                    IdProducto =
                        Convert.ToInt32(
                            dgvProductos.Rows[e.RowIndex]
                            .Cells[0].Value);

                    // ASIGNA NOMBRE
                    txtNombre.Text =
                        dgvProductos.Rows[e.RowIndex]
                        .Cells[1].Value.ToString();

                    // ASIGNA CATEGORIA
                    txtCategoria.Text =
                        dgvProductos.Rows[e.RowIndex]
                        .Cells[2].Value.ToString();

                    // ASIGNA PRECIO
                    txtPrecio.Text =
                        dgvProductos.Rows[e.RowIndex]
                        .Cells[3].Value.ToString();

                    // ASIGNA STOCK
                    txtStock.Text =
                        dgvProductos.Rows[e.RowIndex]
                        .Cells[4].Value.ToString();
                }
            }
            catch
            {

            }
        }

        // EVENTO BOTON EDITAR
        private void btnEditar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                // COMANDO SQL
                SqlCommand cmd =
                    new SqlCommand(
                        "sp_EditarProducto",
                        cn.AbrirConexion());

                // DEFINE STORED PROCEDURE
                cmd.CommandType =
                    CommandType.StoredProcedure;

                // PARAMETRO ID
                cmd.Parameters.AddWithValue(
                    "@IdProducto",
                    IdProducto);

                // PARAMETRO NOMBRE
                cmd.Parameters.AddWithValue(
                    "@Nombre",
                    txtNombre.Text);

                // PARAMETRO CATEGORIA
                cmd.Parameters.AddWithValue(
                    "@Categoria",
                    txtCategoria.Text);

                // PARAMETRO PRECIO
                cmd.Parameters.AddWithValue(
                    "@Precio",
                    txtPrecio.Text);

                // PARAMETRO STOCK
                cmd.Parameters.AddWithValue(
                    "@Stock",
                    txtStock.Text);

                // EJECUTA EL COMANDO
                cmd.ExecuteNonQuery();

                // MENSAJE DE CONFIRMACION
                MessageBox.Show(
                    "Producto actualizado");

                // REGISTRA LOG
                log.RegistrarLog(
                    "PRODUCTO_UPDATE",
                    SesionUsuario.Usuario,
                    "Producto actualizado: " + txtNombre.Text);

                // ACTUALIZA EL GRID
                MostrarProductos();

                // LIMPIA LOS CAMPOS
                LimpiarCampos();

                // CIERRA LA CONEXION
                cn.CerrarConexion();
            }
            catch (Exception ex)
            {
                // MUESTRA ERROR
                MessageBox.Show(ex.Message);
            }
        }

        // EVENTO BOTON ELIMINAR
        private void btnEliminar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                // VARIABLE RESULTADO
                DialogResult resultado;

                // MENSAJE DE CONFIRMACION
                resultado =
                    MessageBox.Show(
                        "¿Desea eliminar este producto?",
                        "Confirmar",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                // VALIDA RESPUESTA
                if (resultado ==
                    DialogResult.Yes)
                {
                    // COMANDO SQL
                    SqlCommand cmd =
                        new SqlCommand(
                            "sp_EliminarProducto",
                            cn.AbrirConexion());

                    // DEFINE STORED PROCEDURE
                    cmd.CommandType =
                        CommandType.StoredProcedure;

                    // PARAMETRO ID
                    cmd.Parameters.AddWithValue(
                        "@IdProducto",
                        IdProducto);

                    // EJECUTA EL COMANDO
                    cmd.ExecuteNonQuery();

                    // MENSAJE DE CONFIRMACION
                    MessageBox.Show(
                        "Producto eliminado");

                    // REGISTRA LOG
                    log.RegistrarLog(
                        "PRODUCTO_DELETE",
                        SesionUsuario.Usuario,
                        "Producto eliminado: " + txtNombre.Text);

                    // ACTUALIZA EL GRID
                    MostrarProductos();

                    // LIMPIA LOS CAMPOS
                    LimpiarCampos();

                    // CIERRA LA CONEXION
                    cn.CerrarConexion();
                }
            }
            catch (Exception ex)
            {
                // MUESTRA ERROR
                MessageBox.Show(ex.Message);
            }
        }

        // EVENTO BOTON BUSCAR
        private void btnBuscar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                // ADAPTADOR DE DATOS
                SqlDataAdapter da =
                    new SqlDataAdapter(
                        "sp_BuscarProducto",
                        cn.AbrirConexion());

                // DEFINE STORED PROCEDURE
                da.SelectCommand.CommandType =
                    CommandType.StoredProcedure;

                // PARAMETRO BUSQUEDA
                da.SelectCommand.Parameters.AddWithValue(
                    "@Texto",
                    txtBuscar.Text);

                // TABLA TEMPORAL
                DataTable dt =
                    new DataTable();

                // LLENA LA TABLA
                da.Fill(dt);

                // MUESTRA LOS DATOS
                dgvProductos.DataSource = dt;

                // CIERRA LA CONEXION
                cn.CerrarConexion();
            }
            catch (Exception ex)
            {
                // MUESTRA ERROR
                MessageBox.Show(ex.Message);
            }
        }

        // EVENTO BOTON NUEVO
        private void btnNuevo_Click(
            object sender,
            EventArgs e)
        {
            // LIMPIA LOS CAMPOS
            LimpiarCampos();

            // ACTUALIZA EL GRID
            MostrarProductos();

            // RESETEA EL ID
            IdProducto = 0;
        }

        // EVENTO BOTON EXPORTAR
        private void btnExportar_Click(
            object sender,
            EventArgs e)
        {
            // EXPORTA LOS DATOS A EXCEL
            ExportarExcel.Exportar(
                dgvProductos,
                "Reporte_Productos");
        }
    }

}