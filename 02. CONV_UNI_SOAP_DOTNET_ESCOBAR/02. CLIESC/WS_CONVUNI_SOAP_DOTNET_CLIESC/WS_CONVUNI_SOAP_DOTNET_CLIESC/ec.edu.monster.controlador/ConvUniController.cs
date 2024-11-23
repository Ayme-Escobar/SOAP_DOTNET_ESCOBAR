using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WS_CONVUNI_SOAP_DOTNET_CLIESC.ConvUniService;
using WS_CONVUNI_SOAP_DOTNET_CLIESC.Modelo;

namespace WS_CONVUNI_SOAP_DOTNET_CLIESC.Controlador
{
    internal class ConvUniController
    {
        private readonly ConversionModel _model;
        ConvUniServicesClient service = new ConvUniServicesClient();

        public ConvUniController()
        {
            _model = new ConversionModel();
        }

        public bool ReadData(TextBox txtCentigrados)
        {
            try
            {
                string input = txtCentigrados.Text.Replace(',', '.');
                _model.Centigrados = Convert.ToDouble(input, CultureInfo.InvariantCulture);
                return true;
            }
            catch
            {
                MessageBox.Show("Ingreso inválido. Por favor ingrese un número válido.");
                _model.Centigrados = 0;
                return false;
            }
        }

        public void InitializeData(TextBox txtCentigrados, TextBox txtResultado)
        {
            txtCentigrados.Text = "";
            txtResultado.Text = "";
        }

        public void centigradoAFarenheit(TextBox txtResultado)
        {
            double resultado = service.CentigradoAFarenheit(_model.Centigrados);
            txtResultado.Text = $"{resultado} °F";
        }

        public void centigradoAKelvin(TextBox txtResultado)
        {
            double resultado = service.CentigradoAKelvin(_model.Centigrados);
            txtResultado.Text = $"{resultado} K";
        }
    }
}
