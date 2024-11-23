using System;
using System.Text;

namespace WS_CONVUNI_SOAP_DOTNET_CLICON.Views
{
    public class LoginView
    {
        public void MostrarBienvenida()
        {
            Console.WriteLine("¡Bienvenido! Por favor, inicie sesión.");
        }

        public string SolicitarUsuario()
        {
            Console.Write("Ingrese su usuario: ");
            return Console.ReadLine();
        }

        public string SolicitarContraseña()
        {
            Console.Write("Ingrese su contraseña: ");
            return LeerContraseñaOculta();
        }

        public void MostrarMensajeExitoso()
        {
            Console.WriteLine("Inicio de sesión exitoso.");
            Console.WriteLine("\n--------------------------------------------------------------------------");
        }

        public void MostrarError(string mensaje)
        {
            Console.WriteLine($"Error: {mensaje}");
        }

        // Método para ocultar la contraseña mientras se escribe
        private string LeerContraseñaOculta()
        {
            StringBuilder passwordBuilder = new StringBuilder();
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine(); 
                    break;
                }
                else if (keyInfo.Key == ConsoleKey.Backspace && passwordBuilder.Length > 0)
                {
                    passwordBuilder.Remove(passwordBuilder.Length - 1, 1);
                    Console.Write("\b \b"); 
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    passwordBuilder.Append(keyInfo.KeyChar);
                    Console.Write("*"); 
                }
            }
            return passwordBuilder.ToString();
        }
    }
}
