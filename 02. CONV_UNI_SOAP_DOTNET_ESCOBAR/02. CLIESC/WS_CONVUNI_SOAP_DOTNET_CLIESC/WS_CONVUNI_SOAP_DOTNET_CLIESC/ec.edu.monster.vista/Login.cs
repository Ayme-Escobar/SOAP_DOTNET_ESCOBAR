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
using WS_CONVUNI_SOAP_DOTNET_CLIESC.Modelo;

namespace WS_CONVUNI_SOAP_DOTNET_CLIESC.Vista
{
    public partial class Login : Form
    {
        private readonly LoginController _controller;
        public Login()
        {
            InitializeComponent();
            var model = new LoginModel();
            _controller = new LoginController(model, this);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            _controller.AttemptLogin(txtUsuario, txtPassword);
        }
    }
}
