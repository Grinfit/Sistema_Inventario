using System.Security.Cryptography;
using System.Text;

namespace Sistema_Inventario.Logica
{
    public class PasswordService
    {
        // =====================================
        // GENERAR HASH PASSWORD
        // =====================================

        public string GenerarHash(
            string texto)
        {
            using (SHA256 sha256 =
                SHA256.Create())
            {
                byte[] bytes =
                    Encoding.UTF8.GetBytes(texto);

                byte[] hash =
                    sha256.ComputeHash(bytes);

                StringBuilder sb =
                    new StringBuilder();

                foreach (byte b in hash)
                {
                    sb.Append(
                        b.ToString("x2"));
                }

                return sb.ToString();
            }
        }

        // =====================================
        // VALIDAR HASH
        // =====================================

        public bool VerificarHash(
            string texto,
            string hashGuardado)
        {
            string nuevoHash =
                GenerarHash(texto);

            return nuevoHash ==
                   hashGuardado;
        }
    }
}