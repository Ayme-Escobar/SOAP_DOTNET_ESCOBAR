using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS_CONVUNI_SOAP_DOTNET_CLICON.Modelo
{
    internal class ConversorModelo
    {
        public double ValorCelsius { get; set; }

        public bool ValidarEntrada(string input, out double valor)
        {
            input = input.Replace(",", ".");
            return double.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out valor);
        }

        public bool TieneUnSoloPuntoDecimal(string input)
        {
            int cantidadPuntos = 0;
            foreach (char c in input)
            {
                if (c == '.') cantidadPuntos++;
            }
            return cantidadPuntos <= 1;
        }
    }
}