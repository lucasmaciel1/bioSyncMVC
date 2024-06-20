using Microsoft.Data.SqlClient;
using bioSyncMVC.Models;

namespace bioSyncMVC.Repositories.ADO.SQLServer;

    public class LoginDAO
    {
        private readonly string connectionString;

        public LoginDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        // Criar o método de validação do Login do Usuário.
        public bool check(Login login)
        {
            bool result = false;

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                // Abrir a conexão do banco de dados: CarroDB
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT id_usuario FROM tb_usuarios WHERE email=@email AND senha=@senha;";
                    command.Parameters.Add(new SqlParameter("@email", System.Data.SqlDbType.VarChar)).Value = login.Usuario;
                    command.Parameters.Add(new SqlParameter("@senha", System.Data.SqlDbType.VarChar)).Value = login.Senha;

                    // Executa o comando da SQL: "SELECT". 
                    SqlDataReader dr = command.ExecuteReader();

                    // Se encontrado o usuário, result é verdadeiro (result = true;),
                    // caso contrário, result se mantém como falso (result = false;).
                    result = dr.Read();
                }
            }
            // retorna o valor de result (true ou false).
            return result;
        }

        public LoginResultado getTipo(Login login)
        {
            LoginResultado result = new LoginResultado();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                // Abrir a conexão do banco de dados: CarroDB
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT id_usuario FROM tb_usuarios WHERE email=@email AND senha=@senha";
                    command.Parameters.Add(new SqlParameter("@email", System.Data.SqlDbType.VarChar)).Value = login.Usuario;
                    command.Parameters.Add(new SqlParameter("@senha", System.Data.SqlDbType.VarChar)).Value = login.Senha;

                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        result.Sucesso = dr.Read();

                        if (result.Sucesso)
                        {
                            result.Id = (int)dr["id"];
                            result.TipoUsuario = dr["tipo"].ToString();

                            login.Id = result.Id;
                            login.TipoUsuario = result.TipoUsuario;
                        } // encerra if.
                    } // encerra using SqlDataReader.

                } // encerra using SqlCommand.
                
                //...executar códigos dentro da sessão durante o login do usuário efetuado com sucesso.

            } // encerra using SqlConnection.

            return result;
        } // encerra o método getTipo de LoginResultado.
    }