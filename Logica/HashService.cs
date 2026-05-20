using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Sistema_Inventario.Logica
{
    public class HashService
    {
        public string GenerarSHA256(string archivo)
        {
            using (FileStream stream =
                File.OpenRead(archivo))
            {
                SHA256 sha =
                    SHA256.Create();

                byte[] hash =
                    sha.ComputeHash(stream);

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
    }
}