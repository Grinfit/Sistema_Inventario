// IMPORTACION DE LIBRERIAS PARA ENCRIPTACION Y MANEJO DE TEXTO
using System.Security.Cryptography;
using System.Text;

namespace Sistema_Inventario.Logica
{
    // CLASE ENCARGADA DE GENERAR Y VALIDAR HASH DE CONTRASEÑAS
    public class PasswordService
    {
        // METODO PARA GENERAR EL HASH DE UNA CONTRASEÑA
        public string GenerarHash(
            string texto)
        {
            // CREA EL OBJETO SHA256
            using (SHA256 sha256 =
                SHA256.Create())
            {
                // CONVIERTE EL TEXTO A BYTES
                byte[] bytes =
                    Encoding.UTF8.GetBytes(texto);

                // GENERA EL HASH
                byte[] hash =
                    sha256.ComputeHash(bytes);

                // OBJETO PARA CONSTRUIR EL HASH EN TEXTO
                StringBuilder sb =
                    new StringBuilder();

                // RECORRE CADA BYTE DEL HASH
                foreach (byte b in hash)
                {
                    // CONVIERTE EL BYTE A HEXADECIMAL
                    sb.Append(
                        b.ToString("x2"));
                }

                // RETORNA EL HASH GENERADO
                return sb.ToString();
            }
        }

        // METODO PARA VALIDAR EL HASH DE UNA CONTRASEÑA
        public bool VerificarHash(
            string texto,
            string hashGuardado)
        {
            // GENERA UN NUEVO HASH DEL TEXTO INGRESADO
            string nuevoHash =
                GenerarHash(texto);

            // COMPARA EL HASH NUEVO CON EL HASH GUARDADO
            return nuevoHash ==
                   hashGuardado;
        }
    }
}