using System;
using System.Globalization;
using WS_CONVUNI_SOAP_DOTNET_CLICON.ConvUniService;

namespace WS_CONVUNI_SOAP_DOTNET_CLICON.ec.edu.monster.prueba
{
    class ConvUniTest
    {
        static void Main(string[] args)
        {
            try
            {                
                ConvUniServicesClient serviceClient = new ConvUniServicesClient();
                
                Console.WriteLine("Probando conversión de Celsius a Fahrenheit...");
                double valorCelsius = 25;
                double resultadoFahrenheit = serviceClient.CentigradoAFarenheit(valorCelsius);
                Console.WriteLine($"{valorCelsius} °C = {resultadoFahrenheit.ToString("0.######", CultureInfo.InvariantCulture)} °F");
                
                Console.WriteLine("Probando conversión de Celsius a Kelvin...");
                double resultadoKelvin = serviceClient.CentigradoAKelvin(valorCelsius);
                Console.WriteLine($"{valorCelsius} °C = {resultadoKelvin.ToString("0.######", CultureInfo.InvariantCulture)} K");
                
                Console.WriteLine("Todo Bien.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al probar el servicio SOAP: {ex.Message}");
            }
            finally
            {                
                Console.WriteLine("\nPresione cualquier tecla para salir...");
                Console.ReadKey();
            }
        }
    }
}
