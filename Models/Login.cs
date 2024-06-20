using System.ComponentModel.DataAnnotations;

namespace bioSyncMVC.Models
{
    public class Login
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Usuário é obrigatório!", AllowEmptyStrings = false)]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Mínimo de 3 e máximo de 10 caracteres.")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "Campo Senha é obrigatório!", AllowEmptyStrings = false)]
        public string Senha { get; set; }

        public string TipoUsuario { get; set; }

        public Login()
        {
            this.Id = 0;
            this.Usuario = "";
            this.Senha = string.Empty;
            this.TipoUsuario = string.Empty;
        }
    }   






    /*public class Login
    {
        public string Email { get; set; }
        public string Senha { get; set; }

        public Login(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }

        public void ValidarLogin()
        {

        }
    }*/
}
