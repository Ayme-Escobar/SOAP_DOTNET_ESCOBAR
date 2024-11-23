using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using WS_CONVUNI_SOAP_DOTNET_CLIESC.Modelo;
using WS_CONVUNI_SOAP_DOTNET_CLIESC.Vista;

namespace WS_CONVUNI_SOAP_DOTNET_CLIESC.Controlador
{
    internal class LoginController
    {
        private readonly LoginModel _model;
        private readonly Form _loginForm;

        public LoginController(LoginModel model, Form loginForm)
        {
            _model = model;
            _loginForm = loginForm;
        }

        public bool ValidateCredentials(string username, string password)
        {
            string storedHashedPassword = HashPassword("Monster9");
            return username == "Monster" && HashPassword(password) == storedHashedPassword;
        }

        public void AttemptLogin(TextBox txtUsuario, TextBox txtPassword)
        {
            _model.Username = txtUsuario.Text;
            _model.Password = txtPassword.Text;

            if (ValidateCredentials(_model.Username, _model.Password))
            {
                MessageBox.Show("Inicio de sesión exitoso.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _loginForm.Hide();
                Form1 form1 = new Form1();
                form1.ShowDialog();
                _loginForm.Close();
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas. Por favor, intente de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Text = string.Empty;
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                return BytesToHex(hashBytes);
            }
        }

        private string BytesToHex(byte[] bytes)
        {
            StringBuilder hex = new StringBuilder(bytes.Length * 2);
            foreach (byte b in bytes)
            {
                hex.AppendFormat("{0:x2}", b);
            }
            return hex.ToString();
        }
    }
}
