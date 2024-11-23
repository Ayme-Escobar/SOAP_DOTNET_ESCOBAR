using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WS_CONVUNI_SOAP_DOTNET_CLIESC.Controlador;
using WS_CONVUNI_SOAP_DOTNET_CLIESC.Vista;

namespace WS_CONVUNI_SOAP_DOTNET_CLIESC
{
    public partial class Form1 : Form
    {
        private ConvUniController objControlador = new ConvUniController();
        public Form1()
        {
            InitializeComponent();
            comboUnidad.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnConvertir_Click(object sender, EventArgs e)
        {
            if (objControlador.ReadData(txtCentigrados))
            {
                if (comboUnidad.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor, seleccione una unidad de conversión.");
                }
                else
                {
                    string selectedValue = comboUnidad.SelectedItem.ToString();
                    if (selectedValue == "Farenheit")
                    {
                        objControlador.centigradoAFarenheit(txtResultado);
                    }
                    else if (selectedValue == "Kelvin")
                    {
                        objControlador.centigradoAKelvin(txtResultado);
                    }                    
                }
            }
            else
            {
                txtResultado.Text = "";
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtCentigrados.Text = "";
            txtResultado.Text = "";
            comboUnidad.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();            
            this.Close();
        }
    }
}
