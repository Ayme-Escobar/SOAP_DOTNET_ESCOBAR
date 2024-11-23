using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace WS_CONVUNI_SOAP_DOTNET_CLIWEB.Pruebas
{
    public class AuthControllerTest
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Iniciando pruebas de hashing SHA-256...\n");
            
            string contraseñaCorrecta = "Monster9";
            string contraseñaIncorrecta = "Monster8";
            
            string hashCorrecto = HashPassword(contraseñaCorrecta);
            string hashIncorrecto = HashPassword(contraseñaIncorrecta);
            
            bool caso1 = hashCorrecto == HashPassword(contraseñaCorrecta);
            Console.WriteLine($"Caso 1 (hash consistente para la misma contraseña): {caso1}");
            
            bool caso2 = hashCorrecto != hashIncorrecto;
            Console.WriteLine($"Caso 2 (hash diferente para contraseñas diferentes): {caso2}");
            
            Console.WriteLine("\nHashes generados:");
            Console.WriteLine($"Hash contraseña correcta ('{contraseñaCorrecta}'): {hashCorrecto}");
            Console.WriteLine($"Hash contraseña incorrecta ('{contraseñaIncorrecta}'): {hashIncorrecto}");
           
            if (caso1 && caso2)
            {
                Console.WriteLine("\nTodas las pruebas han pasado correctamente.");
            }
            else
            {
                Console.WriteLine("\nAlgunas pruebas han fallado.");
            }

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }
        
        private static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                return BytesToHex(hashBytes);
            }
        }

        // Método auxiliar para convertir bytes a una cadena hexadecimal
        private static string BytesToHex(byte[] bytes)
        {
            StringBuilder hex = new StringBuilder(bytes.Length * 2);
            foreach (byte b in bytes)
            {
                hex.AppendFormat("{0:x2}", b); // Convertir cada byte a formato hexadecimal
            }
            return hex.ToString();
        }
    }
}