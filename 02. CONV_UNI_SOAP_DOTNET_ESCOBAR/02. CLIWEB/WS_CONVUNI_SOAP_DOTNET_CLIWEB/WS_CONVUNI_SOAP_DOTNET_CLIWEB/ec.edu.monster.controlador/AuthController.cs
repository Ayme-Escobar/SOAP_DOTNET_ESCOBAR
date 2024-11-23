using System;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using System.Web.Security;

namespace WS_CONVUNI_SOAP_DOTNET_CLIWEB.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Auth/Login
        [HttpPost]
        public ActionResult Login(string username, string password)
        {            
            string storedHashedPassword = HashPassword("Monster9");

            if (username == "Monster" && HashPassword(password) == storedHashedPassword)
            {
                // Iniciar sesión
                Session["User"] = username;
                FormsAuthentication.SetAuthCookie(username, false);
                return RedirectToAction("Index", "ConvUni");
            }
            else
            {
                ViewBag.Error = "Credenciales inválidas.";
                return View();
            }
        }

        // GET: Auth/Logout
        public ActionResult Logout()
        {
            // Cerrar sesión
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        // Método para generar un hash SHA-256 de la contraseña
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
