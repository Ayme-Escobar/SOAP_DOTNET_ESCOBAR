using WS_CONVUNI_SOAP_DOTNET_CLICON.Controllers;

namespace WS_CONVUNI_SOAP_DOTNET_CLICON
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var controlador = new ConversorController();
            controlador.Ejecutar();
        }
    }
}
