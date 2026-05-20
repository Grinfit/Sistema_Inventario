// IMPORTACION DE LIBRERIAS NECESARIAS
using Sistema_Inventario.Datos;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Sistema_Inventario.Logica;

namespace Sistema_Inventario.Presentacion
{
    // FORMULARIO ENCARGADO DE LA GESTION DE USUARIOS
    public partial class FrmUsuarios : Form
    {
        // OBJETO DE CONEXION A LA BASE DE DATOS
        Conexion cn = new Conexion();

        // OBJETO PARA EL MANEJO DE CONTRASEÑAS
        PasswordService passwordService =
    new PasswordService();

        // VARIABLE PARA GUARDAR EL ID DEL USUARIO
        int idUsuario = 0;

        // CONSTRUCTOR DEL FORMULARIO
        public FrmUsuarios()
        {
            // INICIALIZA LOS COMPONENTES
            InitializeComponent();

            // CONFIGURA EL GRID
            ConfigurarGrid();

            // CARGA LOS USUARIOS
            CargarUsuarios();

            // CARGA LOS ROLES
            CargarRoles();

            // CARGA LOS EVENTOS
            Eventos();
        }

        // =========================================
        // EVENTOS
        // =========================================

        // METODO PARA REGISTRAR LOS EVENTOS
        private void Eventos()
        {
            // EVENTO DEL BOTON NUEVO
            btnNuevo.Click += BtnNuevo_Click;

            // EVENTO DEL BOTON GUARDAR
            btnGuardar.Click += BtnGuardar_Click;

            // EVENTO DEL BOTON EDITAR
            btnEditar.Click += BtnEditar_Click;

            // EVENTO DEL BOTON ELIMINAR
            btnEliminar.Click += BtnEliminar_Click;

            // EVENTO DOBLE CLICK DEL GRID
            dgvUsuarios.CellDoubleClick +=
                DgvUsuarios_CellDoubleClick;

            // EVENTO DEL TEXTBOX BUSCAR
            txtBuscar.TextChanged +=
                TxtBuscar_TextChanged;
        }

        // =========================================
        // CONFIG GRID
        // =========================================

        // METODO PARA CONFIGURAR EL DATAGRIDVIEW
        private void ConfigurarGrid()
        {
            // DESHABILITA ESTILOS VISUALES
            dgvUsuarios.EnableHeadersVisualStyles =
                false;

            // COLOR DEL HEADER
            dgvUsuarios.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(11, 31, 58);

            // COLOR DEL TEXTO DEL HEADER
            dgvUsuarios.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            // FUENTE DEL HEADER
            dgvUsuarios.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    11,
                    FontStyle.Bold);

            // FUENTE DE LAS CELDAS
            dgvUsuarios.DefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    10);

            // COLOR DE SELECCION
            dgvUsuarios.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(59, 130, 246);

            // COLOR DEL TEXTO SELECCIONADO
            dgvUsuarios.DefaultCellStyle.SelectionForeColor =
                Color.White;

            // ALTURA DE LAS FILAS
            dgvUsuarios.RowTemplate.Height = 35;
        }

        // =========================================
        // CARGAR USUARIOS
        // =========================================

        // METODO PARA CARGAR LOS USUARIOS
        private void CargarUsuarios()
        {
            try
            {
                // ABRE LA CONEXION
                SqlConnection conexion =
                    cn.AbrirConexion();

                // CONSULTA SQL PARA OBTENER LOS USUARIOS
                SqlDataAdapter da =
                    new SqlDataAdapter(
                        @"SELECT
                            U.IdUsuario,
                            U.Usuario,
                            R.Nombre AS Rol,
                            U.Estado,
                            U.FechaRegistro
                        FROM Usuarios U
                        INNER JOIN Roles R
                            ON U.IdRol = R.IdRol
                        ORDER BY U.IdUsuario DESC",
                        conexion);

                // TABLA TEMPORAL
                DataTable dt =
                    new DataTable();

                // LLENA LA TABLA
                da.Fill(dt);

                // ASIGNA LOS DATOS AL GRID
                dgvUsuarios.DataSource = dt;

                // CIERRA LA CONEXION
                cn.CerrarConexion();

                // ANCHO DE COLUMNAS
                dgvUsuarios.Columns["IdUsuario"].Width = 80;

                dgvUsuarios.Columns["Usuario"].Width = 180;

                dgvUsuarios.Columns["Rol"].Width = 180;

                dgvUsuarios.Columns["Estado"].Width = 80;

                dgvUsuarios.Columns["FechaRegistro"].Width = 180;
            }
            catch (Exception ex)
            {
                // MUESTRA EL ERROR
                MessageBox.Show(
                    ex.Message);
            }
        }

        // =========================================
        // CARGAR ROLES
        // =========================================

        // METODO PARA CARGAR LOS ROLES
        private void CargarRoles()
        {
            try
            {
                // ABRE LA CONEXION
                SqlConnection conexion =
                    cn.AbrirConexion();

                // CONSULTA SQL PARA OBTENER LOS ROLES ACTIVOS
                SqlDataAdapter da =
                    new SqlDataAdapter(
                        @"SELECT
                            IdRol,
                            Nombre
                        FROM Roles
                        WHERE Estado = 1",
                        conexion);

                // TABLA TEMPORAL
                DataTable dt =
                    new DataTable();

                // LLENA LA TABLA
                da.Fill(dt);

                // ASIGNA LOS DATOS AL COMBOBOX
                cboRoles.DataSource = dt;

                // CAMPO A MOSTRAR
                cboRoles.DisplayMember =
                    "Nombre";

                // CAMPO DEL VALOR
                cboRoles.ValueMember =
                    "IdRol";

                // CIERRA LA CONEXION
                cn.CerrarConexion();
            }
            catch (Exception ex)
            {
                // MUESTRA EL ERROR
                MessageBox.Show(
                    ex.Message);
            }
        }

        // =========================================
        // NUEVO
        // =========================================

        // EVENTO DEL BOTON NUEVO
        private void BtnNuevo_Click(
            object sender,
            EventArgs e)
        {
            // LIMPIA LOS CAMPOS
            Limpiar();
        }

        // =========================================
        // GUARDAR
        // =========================================

        // EVENTO DEL BOTON GUARDAR
        private void BtnGuardar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                // VALIDA SI EL USUARIO ESTA VACIO
                if (txtUsuario.Text.Trim() == "")
                {
                    MessageBox.Show(
                        "Ingrese usuario");

                    return;
                }

                // VALIDA SI LA CONTRASEÑA ESTA VACIA
                if (txtClave.Text.Trim() == "")
                {
                    MessageBox.Show(
                        "Ingrese contraseña");

                    return;
                }

                // VALIDA SI LAS CONTRASEÑAS COINCIDEN
                if (txtClave.Text !=
                    txtConfirmar.Text)
                {
                    MessageBox.Show(
                        "Las contraseñas no coinciden");

                    return;
                }

                // ABRE LA CONEXION
                SqlConnection conexion =
                    cn.AbrirConexion();

                // CONSULTA SQL PARA INSERTAR USUARIOS
                SqlCommand cmd =
                    new SqlCommand(
                        @"INSERT INTO Usuarios
                        (
                            Usuario,
                            Clave,
                            Rol,
                            IdRol,
                            Estado
                        )
                        VALUES
                        (
                            @Usuario,
                            @Clave,
                            @Rol,
                            @IdRol,
                            @Estado
                        )",
                        conexion);

                // PARAMETRO USUARIO
                cmd.Parameters.AddWithValue(
                    "@Usuario",
                    txtUsuario.Text);

                // PARAMETRO CONTRASEÑA ENCRIPTADA
                cmd.Parameters.AddWithValue(
    "@Clave",
    passwordService.GenerarHash(
        txtClave.Text));

                // PARAMETRO ROL
                cmd.Parameters.AddWithValue(
                    "@Rol",
                    cboRoles.Text);

                // PARAMETRO ID ROL
                cmd.Parameters.AddWithValue(
                    "@IdRol",
                    cboRoles.SelectedValue);

                // PARAMETRO ESTADO
                cmd.Parameters.AddWithValue(
                    "@Estado",
                    chkEstado.Checked);

                // EJECUTA LA CONSULTA
                cmd.ExecuteNonQuery();

                // CIERRA LA CONEXION
                cn.CerrarConexion();

                // MENSAJE DE EXITO
                MessageBox.Show(
                    "Usuario guardado correctamente");

                // RECARGA EL GRID
                CargarUsuarios();

                // LIMPIA LOS CAMPOS
                Limpiar();
            }
            catch (Exception ex)
            {
                // MUESTRA EL ERROR
                MessageBox.Show(
                    ex.Message);
            }
        }

        // =========================================
        // EDITAR
        // =========================================

        // EVENTO DEL BOTON EDITAR
        private void BtnEditar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                // VALIDA SI HAY USUARIO SELECCIONADO
                if (idUsuario == 0)
                {
                    MessageBox.Show(
                        "Seleccione un usuario");

                    return;
                }

                // ABRE LA CONEXION
                SqlConnection conexion =
                    cn.AbrirConexion();

                // CONSULTA SQL PARA ACTUALIZAR USUARIO
                SqlCommand cmd =
                    new SqlCommand(
                        @"UPDATE Usuarios
                        SET
                            Usuario = @Usuario,
                            Clave = @Clave,
                            Rol = @Rol,
                            IdRol = @IdRol,
                            Estado = @Estado
                        WHERE IdUsuario = @IdUsuario",
                        conexion);

                // PARAMETRO USUARIO
                cmd.Parameters.AddWithValue(
                     "@Usuario",
                     txtUsuario.Text);

                // PARAMETRO CONTRASEÑA ENCRIPTADA
                cmd.Parameters.AddWithValue(
                    "@Clave",
                    passwordService.GenerarHash(
                        txtClave.Text));

                // PARAMETRO ROL
                cmd.Parameters.AddWithValue(
                    "@Rol",
                    cboRoles.Text);

                // PARAMETRO ID ROL
                cmd.Parameters.AddWithValue(
                    "@IdRol",
                    cboRoles.SelectedValue);

                // PARAMETRO ESTADO
                cmd.Parameters.AddWithValue(
                    "@Estado",
                    chkEstado.Checked);

                // PARAMETRO ID USUARIO
                cmd.Parameters.AddWithValue(
                    "@IdUsuario",
                    idUsuario);

                // EJECUTA LA CONSULTA
                cmd.ExecuteNonQuery();

                // CIERRA LA CONEXION
                cn.CerrarConexion();

                // MENSAJE DE EXITO
                MessageBox.Show(
                    "Usuario actualizado");

                // RECARGA LOS USUARIOS
                CargarUsuarios();

                // LIMPIA LOS CAMPOS
                Limpiar();
            }
            catch (Exception ex)
            {
                // MUESTRA EL ERROR
                MessageBox.Show(
                    ex.Message);
            }
        }

        // =========================================
        // ELIMINAR
        // =========================================

        // EVENTO DEL BOTON ELIMINAR
        private void BtnEliminar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                // VALIDA SI HAY USUARIO SELECCIONADO
                if (idUsuario == 0)
                {
                    MessageBox.Show(
                        "Seleccione un usuario");

                    return;
                }

                // MENSAJE DE CONFIRMACION
                DialogResult resultado =
                    MessageBox.Show(
                        "¿Desea eliminar el usuario?",
                        "Confirmar",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                // VERIFICA SI EL USUARIO CONFIRMO
                if (resultado ==
                    DialogResult.Yes)
                {
                    // ABRE LA CONEXION
                    SqlConnection conexion =
                        cn.AbrirConexion();

                    // CONSULTA SQL PARA ELIMINAR
                    SqlCommand cmd =
                        new SqlCommand(
                            @"DELETE FROM Usuarios
                            WHERE IdUsuario = @IdUsuario",
                            conexion);

                    // PARAMETRO ID USUARIO
                    cmd.Parameters.AddWithValue(
                        "@IdUsuario",
                        idUsuario);

                    // EJECUTA LA CONSULTA
                    cmd.ExecuteNonQuery();

                    // CIERRA LA CONEXION
                    cn.CerrarConexion();

                    // MENSAJE DE EXITO
                    MessageBox.Show(
                        "Usuario eliminado");

                    // RECARGA LOS USUARIOS
                    CargarUsuarios();

                    // LIMPIA LOS CAMPOS
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                // MUESTRA EL ERROR
                MessageBox.Show(
                    ex.Message);
            }
        }

        // =========================================
        // DOBLE CLICK GRID
        // =========================================

        // EVENTO DOBLE CLICK DEL DATAGRIDVIEW
        private void DgvUsuarios_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            try
            {
                // VERIFICA QUE LA FILA SEA VALIDA
                if (e.RowIndex >= 0)
                {
                    // OBTIENE LA FILA SELECCIONADA
                    DataGridViewRow fila =
                        dgvUsuarios.Rows[e.RowIndex];

                    // OBTIENE EL ID DEL USUARIO
                    idUsuario =
                        Convert.ToInt32(
                            fila.Cells["IdUsuario"].Value);

                    // CARGA EL USUARIO
                    txtUsuario.Text =
                        fila.Cells["Usuario"].Value.ToString();

                    // CARGA EL ROL
                    cboRoles.Text =
                        fila.Cells["Rol"].Value.ToString();

                    // CARGA EL ESTADO
                    chkEstado.Checked =
                        Convert.ToBoolean(
                            fila.Cells["Estado"].Value);

                    // LIMPIA LA CONTRASEÑA
                    txtClave.Text = "";

                    // LIMPIA LA CONFIRMACION
                    txtConfirmar.Text = "";
                }
            }
            catch (Exception ex)
            {
                // MUESTRA EL ERROR
                MessageBox.Show(
                    ex.Message);
            }
        }

        // =========================================
        // BUSCAR
        // =========================================

        // EVENTO DEL TEXTBOX BUSCAR
        private void TxtBuscar_TextChanged(
            object sender,
            EventArgs e)
        {
            try
            {
                // ABRE LA CONEXION
                SqlConnection conexion =
                    cn.AbrirConexion();

                // CONSULTA SQL PARA BUSCAR USUARIOS
                SqlDataAdapter da =
                    new SqlDataAdapter(
                        @"SELECT
                            U.IdUsuario,
                            U.Usuario,
                            R.Nombre AS Rol,
                            U.Estado,
                            U.FechaRegistro
                        FROM Usuarios U
                        INNER JOIN Roles R
                            ON U.IdRol = R.IdRol
                        WHERE U.Usuario LIKE @Buscar",
                        conexion);

                // PARAMETRO DE BUSQUEDA
                da.SelectCommand.Parameters.AddWithValue(
                    "@Buscar",
                    "%" + txtBuscar.Text + "%");

                // TABLA TEMPORAL
                DataTable dt =
                    new DataTable();

                // LLENA LA TABLA
                da.Fill(dt);

                // ASIGNA LOS DATOS AL GRID
                dgvUsuarios.DataSource = dt;

                // CIERRA LA CONEXION
                cn.CerrarConexion();
            }
            catch (Exception ex)
            {
                // MUESTRA EL ERROR
                MessageBox.Show(
                    ex.Message);
            }
        }

        // =========================================
        // LIMPIAR
        // =========================================

        // METODO PARA LIMPIAR LOS CAMPOS
        private void Limpiar()
        {
            // RESETEA EL ID
            idUsuario = 0;

            // LIMPIA EL USUARIO
            txtUsuario.Clear();

            // LIMPIA LA CONTRASEÑA
            txtClave.Clear();

            // LIMPIA LA CONFIRMACION
            txtConfirmar.Clear();

            // LIMPIA LA BUSQUEDA
            txtBuscar.Clear();

            // ACTIVA EL ESTADO
            chkEstado.Checked = true;

            // VALIDA SI EXISTEN ROLES
            if (cboRoles.Items.Count > 0)
            {
                // SELECCIONA EL PRIMER ROL
                cboRoles.SelectedIndex = 0;
            }

            // ENVIA EL FOCO AL USUARIO
            txtUsuario.Focus();
        }
    }
}