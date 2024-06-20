namespace bioSyncMVC.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Celular { get; set; }
        public string Cpf { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public int Cep { get; set; }
        public string Estado { get; set; }
        public int Cidade { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string NumeroEnd { get; set; }
        public bool TipoUsuario { get; set; }

        public Usuario(int idUsuario, string nome, string celular, string cpf, string senha, string email, int cep, string estado, int cidade, string bairro, string numeroEnd, bool tipoUsuario)
        {
            IdUsuario = idUsuario;
            Nome = nome;
            Celular = celular;
            Cpf = cpf;
            Senha = senha;
            Email = email;
            Cep = cep;
            Estado = estado;
            Cidade = cidade;
            Bairro = bairro;
            NumeroEnd = numeroEnd;
            TipoUsuario = tipoUsuario;
        }

        public Usuario()
        {
        }
    }
}
