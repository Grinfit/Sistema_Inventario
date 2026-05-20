// IMPORTACION DE LIBRERIAS PARA EL MANEJO DE ARCHIVOS, HASH Y TEXTO
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Sistema_Inventario.Logica
{
    // CLASE ENCARGADA DE GENERAR HASH SHA256
    public class HashService
    {
        // METODO PARA GENERAR EL HASH SHA256 DE UN ARCHIVO
        public string GenerarSHA256(string archivo)
        {
            // ABRE EL ARCHIVO EN MODO LECTURA
            using (FileStream stream =
                File.OpenRead(archivo))
            {
                // CREA EL OBJETO SHA256
                SHA256 sha =
                    SHA256.Create();

                // GENERA EL HASH DEL ARCHIVO
                byte[] hash =
                    sha.ComputeHash(stream);

                // OBJETO PARA CONSTRUIR EL HASH EN TEXTO
                StringBuilder sb =
                    new StringBuilder();

                // RECORRE CADA BYTE DEL HASH
                foreach (byte b in hash)
                {
                    // CONVIERTE EL BYTE A FORMATO HEXADECIMAL
                    sb.Append(
                        b.ToString("x2"));
                }

                // RETORNA EL HASH GENERADO
                return sb.ToString();
            }
        }
    }
}