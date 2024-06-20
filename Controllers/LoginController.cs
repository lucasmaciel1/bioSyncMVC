using bioSyncMVC.Models;
using bioSyncMVC.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bioSyncMVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly Repositories.ADO.SQLServer.LoginDAO repository;
        private readonly Services.ISessao sessao;

        public LoginController(IConfiguration configuration, ISessao sessao)
        {
            this.repository = new Repositories.ADO.SQLServer.LoginDAO(configuration.GetConnectionString(Configurations.Appsettings.getKeyConnectionString()));
            this.sessao = sessao;
        }

        public IActionResult Login()
        {
            // Se o usuário não estiver logado retorna a View() senão retorna para a página de início.
            return this.sessao.getTokenLogin() == null ? View() : RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Login login)
        {
            #region "Login com controle de sessão.(INUTILIZADO)"
            /*if (!string.IsNullOrEmpty(login.Usuario) && !string.IsNullOrEmpty(login.Senha))
            {
                if (this.repository.check(login))
                {
                    var loginResultado = repository.getTipo(login);
                    this.sessao.addTokenLogin(login);

                    if (loginResultado.TipoUsuario == "admin")
                        return RedirectToAction("Index", "Admin"); // Redireciona para o local do usuário Admin.
                    return RedirectToAction("Index", "Home"); // Redireciona para outro local(usuário comum).
                }
                ModelState.AddModelError(string.Empty, "Usuário e/ou Senha Inválidos!");
            }
            return View();*/
            #endregion

            #region "Login sem controle de sessão."

            if (!string.IsNullOrEmpty(login.Usuario) && !string.IsNullOrEmpty(login.Senha))
            {
                if (this.repository.check(login))
                    return RedirectToAction("Index", "Home");
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Error = "Usuário e/ou Senha Inválidos!";
            return View();

            #endregion
        }

        public IActionResult Logout()
        {
            this.sessao.deleteTokenLogin();
            return RedirectToAction("Index", "Home");
        }

    }















    /*public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }*/
}
