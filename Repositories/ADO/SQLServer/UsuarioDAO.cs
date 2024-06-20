using bioSyncMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace bioSyncMVC.Repositories.ADO.SQLServer
{
    public class UsuarioDAO 
    {
        private readonly string connectionString;

        public UsuarioDAO(string connectionString)
        {

            this.connectionString = connectionString;
        }

        
        public List<Usuario> getAll() 
        {
            List<Usuario> usuarios = new List<Usuario>();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select id_usuario, nome, celular, cpf, senha, email, cep, id_cidade, bairro, rua, numero, tipo_usuario from tb_usuarios;";
                   


                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())   
                    {
                        Usuario usuario = new Usuario();

                        usuario.IdUsuario = (int)dr["id_usuario"];
                        usuario.Nome = dr["nome"].ToString();
                        usuario.Celular = (string)dr["celular"];
                        usuario.Cpf = (string)dr["cpf"];
                        usuario.Senha = (string)dr["senha"];
                        usuario.Email = (string)dr["email"];
                        usuario.Cep = (int)dr["cep"];
                        usuario.Cidade = (int)dr["id_cidade"];
                        usuario.Bairro = (string)dr["bairro"];
                        usuario.Rua = (string)dr["rua"];
                        usuario.NumeroEnd = (string)dr["numero"];
                        usuario.TipoUsuario = (bool)dr["tipo_usuario"];

                        usuarios.Add(usuario);
                    }
                }

            }

            return usuarios;
        }

        
        public Usuario getByIdUsuario(int idusuario)
        {
            Usuario usuario = new Usuario();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {

                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    
                    command.Connection = connection;
                    command.CommandText = "select id_usuario, nome, celular, cpf, senha, email, cep, id_cidade, bairro, rua, numero, tipo_usuario from tb_usuarios where id_usuario=@id_usuario";
                    //command.Parameters.Add(new SqlParameter("@id_usuario", System.Data.SqlDbType.Int)).Value = idusuario;
                    command.Parameters.Add(new SqlParameter("@id_usuario", System.Data.SqlDbType.Int)).Value = idusuario;

                    SqlDataReader dr = command.ExecuteReader();

                    
                    if (dr.Read())
                    {
                        usuario.IdUsuario = (int)dr["id_usuario"];
                        usuario.Nome = dr["nome"].ToString();
                        usuario.Celular = (string)dr["celular"];
                        usuario.Cpf = (string)dr["cpf"];
                        usuario.Senha = (string)dr["senha"];
                        usuario.Email = (string)dr["email"];
                        usuario.Cep = (int)dr["cep"];
                        usuario.Cidade = (int)dr["id_cidade"];
                        usuario.Bairro = (string)dr["bairro"];
                        usuario.Rua = (string)dr["rua"];
                        usuario.NumeroEnd = (string)dr["numero"];
                        usuario.TipoUsuario = (bool)dr["tipo_usuario"];
                    }
                }
            }
            return usuario; 
        }


        public void update(int id, Usuario usuario)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {

                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;

                    command.CommandText = "UPDATE tb_usuarios SET email=@email, " +
                                          "nome=@nome, " +
                                          "celular=@celular," +
                                          "senha=@senha, " +
                                          "cpf=@cpf, " +
                                          "id_cidade=@id_cidade, " +
                                          "cep=@cep, "+
                                          "bairro=@bairro, "+
                                          "rua=@rua," +
                                          "numero=@numero,"+
                                          "tipo_usuario=@tipo_usuario " +
                                          "WHERE id_usuario=@id_usuario;";
                    command.Parameters.Add(new SqlParameter("@email", System.Data.SqlDbType.VarChar)).Value = usuario.Email;
                    command.Parameters.Add(new SqlParameter("@nome", System.Data.SqlDbType.VarChar)).Value = usuario.Nome;
                    command.Parameters.Add(new SqlParameter("@celular", System.Data.SqlDbType.VarChar)).Value = usuario.Celular;
                    command.Parameters.Add(new SqlParameter("@senha", System.Data.SqlDbType.VarChar)).Value = usuario.Senha;
                    command.Parameters.Add(new SqlParameter("@cpf", System.Data.SqlDbType.VarChar)).Value = usuario.Cpf;
                    command.Parameters.Add(new SqlParameter("@id_cidade", System.Data.SqlDbType.Int)).Value = usuario.Cidade;
                    command.Parameters.Add(new SqlParameter("@cep", System.Data.SqlDbType.Int)).Value = usuario.Cep;
                    command.Parameters.Add(new SqlParameter("@bairro", System.Data.SqlDbType.VarChar)).Value = usuario.Bairro;
                    command.Parameters.Add(new SqlParameter("@rua", System.Data.SqlDbType.VarChar)).Value = usuario.Rua;
                    command.Parameters.Add(new SqlParameter("@numero", System.Data.SqlDbType.VarChar)).Value = usuario.NumeroEnd;
                    command.Parameters.Add(new SqlParameter("@tipo_usuario", System.Data.SqlDbType.Bit)).Value = usuario.TipoUsuario;
                    command.Parameters.Add(new SqlParameter("@id_usuario", System.Data.SqlDbType.Int)).Value = id;

                   
                    command.ExecuteNonQuery();
                }
            }
        }

       
        public void add(Usuario usuario)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
         
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;

                    command.CommandText = "INSERT INTO tb_usuarios (email, nome, celular, senha, cpf, tipo_usuario, id_cidade, cep, bairro, rua, numero) " +
                                          "VALUES (@Email, @Nome, @Celular, @Senha, @Cpf, @TipoUsuario, @Cidade, @Cep, @Bairro, @Rua, @Numero);" +
                                          "SELECT CONVERT(INT,@@IDENTITY) AS ID;;";
                    command.Parameters.Add(new SqlParameter("@Email", System.Data.SqlDbType.VarChar)).Value = usuario.Email;
                    command.Parameters.Add(new SqlParameter("@Nome", System.Data.SqlDbType.VarChar)).Value = usuario.Nome;
                    command.Parameters.Add(new SqlParameter("@Celular", System.Data.SqlDbType.VarChar)).Value = usuario.Celular;
                    command.Parameters.Add(new SqlParameter("@Senha", System.Data.SqlDbType.VarChar)).Value = usuario.Senha;
                    command.Parameters.Add(new SqlParameter("@Cpf", System.Data.SqlDbType.VarChar)).Value = usuario.Cpf;
                    command.Parameters.Add(new SqlParameter("@TipoUsuario", System.Data.SqlDbType.Bit)).Value = usuario.TipoUsuario;
                    command.Parameters.Add(new SqlParameter("@Cidade", System.Data.SqlDbType.Int)).Value = usuario.Cidade;
                    command.Parameters.Add(new SqlParameter("@Cep", System.Data.SqlDbType.Int)).Value = usuario.Cep;
                    command.Parameters.Add(new SqlParameter("@Bairro", System.Data.SqlDbType.VarChar)).Value = usuario.Bairro;
                    command.Parameters.Add(new SqlParameter("@Rua", System.Data.SqlDbType.VarChar)).Value = usuario.Rua;
                    command.Parameters.Add(new SqlParameter("@Numero", System.Data.SqlDbType.VarChar)).Value = usuario.NumeroEnd;

                    usuario.IdUsuario = (int)command.ExecuteScalar();

                } 
            } 
        } 

 
        public void delete(int idusuario)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;

                    command.CommandText = "DELETE FROM tb_usuarios WHERE id_usuario=@id_usuario";
                    command.Parameters.Add(new SqlParameter("@id_usuario", System.Data.SqlDbType.Int)).Value = idusuario;

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
