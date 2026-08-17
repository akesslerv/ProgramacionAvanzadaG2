using System.Web.Mvc;
using AP.MVC.Models;
using AP.MVC.Services;

namespace AP.MVC.Controllers
{
    //SOLID: SRP - controla autenticacion
    //DP: MVC - controller
    public class LoginController : Controller
    {
        private readonly UserService _userService = new UserService();

        // login
        [HttpGet]
        public ActionResult Index()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = _userService.ValidateLogin(model.Username, model.Password);

            if (user != null)
            {
                Session["User"] = user.Username;
                return RedirectToAction("Index", "Home");
            }

            model.ErrorMessage = "Usuario o contraseña incorrectos";
            return View(model);
        }

        // olvide pwd
        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                ViewBag.Error = "Debe ingresar un usuario";
                return View();
            }

            if (!_userService.UserExists(username))
            {
                ViewBag.Error = "El usuario no existe";
                return View();
            }

            TempData["username"] = username;
            return RedirectToAction("ResetPassword");
        }

        // resetear pwd
        [HttpGet]
        public ActionResult ResetPassword()
        {
            if (TempData["username"] == null)
                return RedirectToAction("ForgotPassword");

            ViewBag.Username = TempData["username"].ToString();
            return View();
        }

        [HttpPost]
        public ActionResult ResetPassword(string username, string newPassword)
        {
            if (string.IsNullOrWhiteSpace(newPassword))
            {
                ViewBag.Error = "Debe ingresar una contraseña";
                ViewBag.Username = username;
                return View();
            }

            var result = _userService.ChangePassword(username, newPassword);

            if (result)
                return RedirectToAction("Index");

            ViewBag.Error = "No se pudo cambiar la contraseña";
            ViewBag.Username = username;
            return View();
        }

        // LOGOUT
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }

        // Registro

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Register(string name, string email, string password)
        {
            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password))
            {
                ViewBag.Error = "Todos los campos son obligatorios";
                return View();
            }


            var result = _userService.RegisterUser(name, email, password);


            if (!result)
            {
                ViewBag.Error = "El correo ya está registrado";
                return View();
            }


            return RedirectToAction("Index");
        }
    }
}