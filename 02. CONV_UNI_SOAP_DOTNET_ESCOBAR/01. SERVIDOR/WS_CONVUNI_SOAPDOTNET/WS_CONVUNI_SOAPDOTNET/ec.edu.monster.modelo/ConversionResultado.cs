using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_CONVUNI_SOAPDOTNET.ec.edu.monster.modelo
{
    public class ConversionResultado
    {
        public double ValorOriginal { get; }
        public double ValorConvertido { get; }
        public string TipoConversion { get; }

        public ConversionResultado(double valorOriginal, double valorConvertido, string tipoConversion)
        {
            ValorOriginal = valorOriginal;
            ValorConvertido = valorConvertido;
            TipoConversion = tipoConversion;
        }
    }
}