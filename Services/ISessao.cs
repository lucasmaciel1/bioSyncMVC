using bioSyncMVC.Models;

namespace bioSyncMVC.Services
{
    public interface ISessao
    {
        void addTokenLogin(Login login);

        Login getTokenLogin();

        // Adicionar na Classe Sessão (Sessao.cs) todos os métodos que estarão protegidos pela sessão.
        // Por exemplo: void update() do CarroController.
        void deleteTokenLogin();
    }
}
