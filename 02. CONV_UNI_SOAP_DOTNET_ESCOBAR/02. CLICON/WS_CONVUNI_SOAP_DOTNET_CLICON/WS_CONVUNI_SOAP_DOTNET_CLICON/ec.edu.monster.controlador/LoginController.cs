using System;
using System.Security.Cryptography;
using System.Text;
using WS_CONVUNI_SOAP_DOTNET_CLICON.Modelo;
using WS_CONVUNI_SOAP_DOTNET_CLICON.Views;

namespace WS_CONVUNI_SOAP_DOTNET_CLICON.Controllers
{
    public class LoginController
    {
        private readonly LoginModel _model;
        private readonly LoginView _view;

        public LoginController()
        {
            _model = new LoginModel();
            _view = new LoginView();
        }

        public bool IniciarSesion()
        {
            _view.MostrarBienvenida();

            _model.Username = _view.SolicitarUsuario();
            _model.Password = _view.SolicitarContraseña();

            string hashedPassword = HashPassword(_model.Password);

            if (_model.Username == "Monster" && hashedPassword == HashPassword("Monster9"))
            {
                _view.MostrarMensajeExitoso();
                return true;
            }
            else
            {
                _view.MostrarError("Credenciales incorrectas. Intente de nuevo.");
                return false;
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
