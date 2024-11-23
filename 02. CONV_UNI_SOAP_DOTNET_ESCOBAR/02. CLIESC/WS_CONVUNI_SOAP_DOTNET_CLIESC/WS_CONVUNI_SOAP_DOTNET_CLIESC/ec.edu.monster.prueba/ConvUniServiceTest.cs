using System;
using WS_CONVUNI_SOAP_DOTNET_CLIESC.ConvUniService;

namespace WS_CONVUNI_SOAP_DOTNET_CLIESC.Pruebas
{
    public class ConvUniServiceTest
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Iniciando prueba del servicio de conversión...\n");
            
            ConvUniServicesClient service = new ConvUniServicesClient();

            try
            {                
                Console.WriteLine("Ingrese la temperatura en grados Celsius:");
                string input = Console.ReadLine();

                // Validar entrada
                if (double.TryParse(input, out double celsius))
                {
                    // Convertir a Fahrenheit
                    double fahrenheit = service.CentigradoAFarenheit(celsius);
                    Console.WriteLine($"\nResultado: {celsius} °C = {fahrenheit} °F");

                    // Convertir a Kelvin
                    double kelvin = service.CentigradoAKelvin(celsius);
                    Console.WriteLine($"Resultado: {celsius} °C = {kelvin} K");
                }
                else
                {
                    Console.WriteLine("❌ Entrada inválida. Por favor ingrese un número válido.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Ocurrió un error al intentar usar el servicio: {ex.Message}");
            }

            Console.WriteLine("\nPrueba finalizada. Presione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
