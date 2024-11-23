using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace WS_CONVUNI_SOAPDOTNET
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ConvUniServices" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ConvUniServices.svc o ConvUniServices.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ConvUniServices : IConvUniServices
    {
        public double CentigradoAFarenheit(double c)
        {
            return (c * 9.0 / 5.0) + 32;
        }

        public double CentigradoAKelvin(double c)
        {
            return c + 273.15;
        }
    }
}
