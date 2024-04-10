using MySql.Data.MySqlClient;
using ProjetoPixelPlace.Entities;
using System.Collections.Generic;

namespace ProjetoPixelPlace.Models
{
    public class UsuarioModel
    {
        public UsuarioModel()
        {
          
        }

        public List<Usuario> getAllUser()
        {
            MySqlConnection con = CriadorConexao.getConexao();
            List < Usuario > users = new List<Usuario>();
            Usuario user = new Usuario(1, "2", "3", "4", "23");
            users.Add(user);

            return users;

            

            /*
                MySqlCommand comando = new MySqlCommand("Select * from usuario", con);
                MySqlDataReader reader = comando.ExecuteReader();
                while(reader.Read())
                {
                    Usuario usuario = new Usuario(int.Parse(reader["idUsuario"].ToString()),
                        reader["NomeUser"].ToString(),
                        reader["UrlImage"].ToString(),
                        reader["Email"].ToString(),
                        reader["Senha"].ToString());

                    users.Add(usuario);
                }
                con.Close();
            }
            */
            
                
               
            
            
        }
    }
}
