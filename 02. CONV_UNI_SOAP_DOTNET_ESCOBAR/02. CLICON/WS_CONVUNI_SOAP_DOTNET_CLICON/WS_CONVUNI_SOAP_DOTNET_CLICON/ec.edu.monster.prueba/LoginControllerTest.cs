using System;
using WS_CONVUNI_SOAP_DOTNET_CLICON.Controllers;

namespace WS_CONVUNI_SOAP_DOTNET_CLICON.ec.edu.monster.prueba
{
    public class LoginControllerTest
    {
        public static void Main(string[] args)
        {            
            LoginController loginController = new LoginController();

            Console.WriteLine("Iniciando pruebas de hash...");

            string passwordCorrecta = "Monster9";
            string passwordIncorrecta = "Monster8";
            
            string hashOriginal = GenerarHashDesdeControlador(loginController, passwordCorrecta);
            bool caso1 = hashOriginal == GenerarHashDesdeControlador(loginController, passwordCorrecta);
            Console.WriteLine($"Caso 1 (hash consistente para la misma contraseña): {caso1}");
            
            string hashIncorrecto = GenerarHashDesdeControlador(loginController, passwordIncorrecta);
            bool caso2 = hashOriginal != hashIncorrecto;
            Console.WriteLine($"Caso 2 (hash diferente para contraseñas diferentes): {caso2}");

            // Resultado final
            if (caso1 && caso2)
            {
                Console.WriteLine("Todas las pruebas de hash han pasado correctamente.");
            }
            else
            {
                Console.WriteLine("Algunas pruebas de hash fallaron.");
            }
            
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }
        
        private static string GenerarHashDesdeControlador(LoginController controller, string password)
        {
            // Usamos reflexión para acceder al método privado HashPassword
            var hashPasswordMethod = typeof(LoginController).GetMethod("HashPassword", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            return (string)hashPasswordMethod.Invoke(controller, new object[] { password });
        }
    }
}
