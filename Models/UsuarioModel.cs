using MySql.Data.MySqlClient;
using ProjetoPixelPlace.Entities;
using System.Collections.Generic;

namespace ProjetoPixelPlace.Models
{
    public class UsuarioModel
    {
        //REMODELAR ESSA CLASSE TA HORRIVEL....

        public List<Usuario> getAllUser()
        {

            List<Usuario> users = new List<Usuario>();
            MySqlConnection con;
            byte[] imagem = null; 
            try
            {
                con = CriadorConexao.getConexao("ConexaoPadrao");
                con.Open();

            }
            catch (Exception ex)
            {
                con = CriadorConexao.getConexao("casa");
                con.Open();
            }

            MySqlCommand comando = new MySqlCommand("Select * from usuario", con);
            MySqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {

                if (!reader.IsDBNull(reader.GetOrdinal("imagem"))){
                    imagem = (byte[])reader["imagem"];
                }
                
                Usuario usuario = new Usuario(int.Parse(reader["idUsuario"].ToString()),
                reader["nomeUser"].ToString(),
                imagem,
                reader["Email"].ToString(),
                reader["Senha"].ToString());

                users.Add(usuario);
             
            }
            con.Close();
            return users;
        }


        public string inserirUsuario(Usuario usuario)
        {
            string mensagem = "";
            try
            {
                using (MySqlConnection con = CriadorConexao.getConexao("casa"))
                {
                    con.Open();
                    using (MySqlCommand mySqlCommand = new MySqlCommand("INSERT INTO usuario(nomeUser, email, senha) VALUES (@nome, @email, @senha)", con))
                    {
                        mySqlCommand.Parameters.AddWithValue("@nome", usuario.NomeUsuario);
                        mySqlCommand.Parameters.AddWithValue("@email", usuario.Email);
                        mySqlCommand.Parameters.AddWithValue("@senha", usuario.Senha);
                        int rowsAffected = mySqlCommand.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            mensagem = "Usuário cadastrado com sucesso";
                        }
                        else
                        {
                            mensagem = "Falha ao cadastrar usuário";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                mensagem = "Ocorreu um erro ao cadastrar o usuário: " + ex.Message;
            }
            return mensagem;
        }
        public Usuario ValidaUser(string email, string senha)
        {
            Usuario user;
            byte[] imagem = null;
            MySqlConnection con;
            try
            {
                con = CriadorConexao.getConexao("ConexaoPadrao");
                con.Open();
                con.Close();

            }
            catch (Exception ex)
            {
                con = CriadorConexao.getConexao("casa");
                con.Open();
            }



            MySqlCommand command = new MySqlCommand("SELECT * FROM USUARIO WHERE email = @email AND senha = @senha", con);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@senha", senha);
            MySqlDataReader reader = command.ExecuteReader();

            //caso encontre algo
            while (reader.Read())
            {

                if (!reader.IsDBNull(reader.GetOrdinal("imagem")))
                {
                    imagem = (byte[])reader["imagem"];
                }

                int idUsuario = (int)reader["idUsuario"];
                string NomeUsuario = (string)reader["nomeUser"];
                string emailUser = (string)reader["email"];
                string senhaU = (string)reader["senha"];

                user = new Usuario(idUsuario, NomeUsuario, imagem, emailUser, senhaU);

                return user;
            }
            return null;
        }
    }  
}
