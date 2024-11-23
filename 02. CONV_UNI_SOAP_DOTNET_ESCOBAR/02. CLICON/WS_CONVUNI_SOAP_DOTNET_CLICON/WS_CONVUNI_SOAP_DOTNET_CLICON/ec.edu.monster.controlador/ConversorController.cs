using System.Globalization;
using WS_CONVUNI_SOAP_DOTNET_CLICON.ConvUniService;
using WS_CONVUNI_SOAP_DOTNET_CLICON.Modelo;
using WS_CONVUNI_SOAP_DOTNET_CLICON.Views;

namespace WS_CONVUNI_SOAP_DOTNET_CLICON.Controllers
{
    public class ConversorController
    {
        private readonly ConversorModelo _model;
        private readonly ConversorView _view;
        private readonly ConvUniServicesClient _service;
        private readonly LoginController _loginController;

        public ConversorController()
        {
            _model = new ConversorModelo();
            _view = new ConversorView();
            _service = new ConvUniServicesClient();
            _loginController = new LoginController();
        }

        public void Ejecutar()
        {            
            bool loginExitoso = false;
            while (!loginExitoso)
            {
                loginExitoso = _loginController.IniciarSesion();
            }
            
            _view.MostrarBienvenida();

            bool entradaValida = false;
            double valorCelsius = 0;

            while (!entradaValida)
            {
                string input = _view.SolicitarEntrada();

                if (string.IsNullOrWhiteSpace(input))
                {
                    _view.MostrarError("La entrada no puede estar vacía.");
                }
                else if (!_model.ValidarEntrada(input, out valorCelsius) || !_model.TieneUnSoloPuntoDecimal(input))
                {
                    _view.MostrarError("Ingrese un número válido.");
                }
                else
                {
                    entradaValida = true;
                }
            }

            int opcion;
            do
            {
                opcion = _view.MostrarMenu();

                switch (opcion)
                {
                    case 1:
                        double resultadoFahrenheit = _service.CentigradoAFarenheit(valorCelsius);
                        _view.MostrarResultado($"{valorCelsius} °C = {resultadoFahrenheit.ToString("0.######", CultureInfo.InvariantCulture)} °F");
                        break;

                    case 2:
                        double resultadoKelvin = _service.CentigradoAKelvin(valorCelsius);
                        _view.MostrarResultado($"{valorCelsius} °C = {resultadoKelvin.ToString("0.######", CultureInfo.InvariantCulture)} K");
                        break;

                    case 3:
                        _view.MostrarDespedida();
                        break;

                    default:
                        _view.MostrarError("Opción no válida. Por favor, intente de nuevo.");
                        break;
                }
            } while (opcion != 3);
        }
    }
}
