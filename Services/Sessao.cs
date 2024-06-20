using bioSyncMVC.Models;
using Newtonsoft.Json;

namespace bioSyncMVC.Services
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly string tokenSessao;

        public Sessao(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.tokenSessao = "login";
        }

        public void addTokenLogin(Login login)
        {
            string loginTokenJson = JsonConvert.SerializeObject(login);
            this.httpContextAccessor.HttpContext.Session.SetString(this.tokenSessao, loginTokenJson);
        }
        public Login getTokenLogin()
        {
            string loginTokenJson = this.httpContextAccessor.HttpContext.Session.GetString(this.tokenSessao);
            return loginTokenJson != null ? JsonConvert.DeserializeObject<Login>(loginTokenJson) : null;
        }

        public void deleteTokenLogin()
        {
            this.httpContextAccessor.HttpContext.Session.Remove(this.tokenSessao);
        }
    }
}
