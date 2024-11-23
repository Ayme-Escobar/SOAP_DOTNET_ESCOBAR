using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WS_CONVUNI_SOAP_DOTNET_CLIWEB.ServicioConvUni;
using System.Globalization;
using WS_CONVUNI_SOAP_DOTNET_CLIWEB.Models;

namespace WS_CONVUNI_SOAP_DOTNET_CLIWEB.Controllers
{
    [Authorize]
    public class ConvUniController : Controller
    {
        // GET: ConvUni
        ConvUniServicesClient services = new ConvUniServicesClient();
        public ActionResult Index()
        {
            return View();
        }

        // GET: ConvUni/ConvertirAFahrenheit
        public ActionResult ConvertirAFahrenheit()
        {
            return View();
        }

        // POST: ConvUni/ConvertirAFahrenheit
        [HttpPost]
        public ActionResult ConvertirAFahrenheit(string celsius)
        {
            var model = new ConversionModel();
            try
            {
                double valorCelsius;
                if (double.TryParse(celsius.Replace(",", "."), NumberStyles.Float, CultureInfo.InvariantCulture, out valorCelsius))
                {
                    model.Celsius = valorCelsius;
                    model.Resultado = services.CentigradoAFarenheit(valorCelsius);
                    ViewBag.Resultado = $"{celsius} °C = {model.Resultado} °F";                    
                    //double resultado = services.CentigradoAFarenheit(valorCelsius);
                    //ViewBag.Resultado = $"{celsius} °C = {resultado} °F";
                }
                else
                {
                    ViewBag.Error = "Ingrese un valor numérico válido.";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Error al convertir: {ex.Message}";
            }

            return View(model);
        }

        // GET: ConvUni/ConvertirAKelvin
        public ActionResult ConvertirAKelvin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ConvertirAKelvin(string celsius)
        {
            var model = new ConversionModel();
            try
            {
                double valorCelsius;
                if (double.TryParse(celsius.Replace(",", "."), NumberStyles.Float, CultureInfo.InvariantCulture, out valorCelsius))
                {
                    model.Celsius = valorCelsius;
                    model.Resultado = services.CentigradoAKelvin(valorCelsius);
                    ViewBag.Resultado = $"{celsius} °C = {model.Resultado} K";
                    //double resultado = services.CentigradoAKelvin(valorCelsius);
                    //ViewBag.Resultado = $"{celsius} °C = {resultado} K";
                }
                else
                {
                    ViewBag.Error = "Ingrese un valor numérico válido.";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Error al convertir: {ex.Message}";
            }

            return View();
        }

    }
}
