using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_CONVUNI_SOAPDOTNET.ec.edu.monster.controlador
{    
    using WS_CONVUNI_SOAPDOTNET.ec.edu.monster.modelo;

    public class ConversionControlador
    {
        private readonly ConvUniServices _servicio = new ConvUniServices();

        public ConversionResultado ConvertirAFarenheit(double c)
        {
            double resultado = _servicio.CentigradoAFarenheit(c);
            return new ConversionResultado(c, resultado, "Centígrados a Farenheit");
        }

        public ConversionResultado ConvertirAKelvin(double c)
        {
            double resultado = _servicio.CentigradoAKelvin(c);
            return new ConversionResultado(c, resultado, "Centígrados a Kelvin");
        }
    }
}