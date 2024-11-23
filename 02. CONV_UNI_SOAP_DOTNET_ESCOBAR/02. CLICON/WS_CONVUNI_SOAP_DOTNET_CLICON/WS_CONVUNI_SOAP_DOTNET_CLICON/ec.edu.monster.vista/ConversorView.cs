using System;

namespace WS_CONVUNI_SOAP_DOTNET_CLICON.Views
{
    public class ConversorView
    {
        public void MostrarBienvenida()
        {
            Console.WriteLine("¡Bienvenido al Conversor de Unidades!");
        }

        public string SolicitarEntrada()
        {
            Console.Write("Ingrese un valor en grados Celsius: ");
            return Console.ReadLine();
        }

        public int MostrarMenu()
        {
            Console.WriteLine("\n----------------------------- MENÚ PRINCIPAL -----------------------------");
            Console.WriteLine("1. Convertir de Celsius a Fahrenheit");
            Console.WriteLine("2. Convertir de Celsius a Kelvin");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");

            int opcion;
            int.TryParse(Console.ReadLine(), out opcion);
            return opcion;
        }

        public void MostrarResultado(string resultado)
        {
            Console.WriteLine(resultado);
        }

        public void MostrarError(string mensaje)
        {
            Console.WriteLine($"Error: {mensaje}");
        }

        public void MostrarDespedida()
        {
            Console.WriteLine("Saliendo del programa. ¡Adiós!");
        }
    }
}
