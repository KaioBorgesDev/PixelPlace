using MySql.Data.MySqlClient;
using ProjetoPixelPlace.Entities;

namespace ProjetoPixelPlace.Models
{
    public class JogoModel
    {
        private MySqlConnection con;
        public JogoModel()
        {
        }

        public List<Jogo> getAllJogos()
        {
            List<Jogo> jogoList = new List<Jogo>(); 
            try
            {
                con = CriadorConexao.getConexao("ConexaoPadrao");
                con.Open();
            }
            catch (Exception ex) {
                con = CriadorConexao.getConexao("casa");
                con.Open();
            }

            MySqlCommand query = new MySqlCommand("Select * from jogo", con);
            MySqlDataReader reader = query.ExecuteReader();

            while(reader.Read()) {
                Jogo jogo = new Jogo(int.Parse(reader["idJogo"].ToString()),
                    reader["nome"].ToString(),
                    reader["urlCapa"].ToString(),
                    reader["descricao"].ToString(),
                    reader["categoria"].ToString(),
                    Double.Parse(reader["preco"].ToString()),
                    Double.Parse(reader["desconto"].ToString()),
                    DateTime.Parse(reader["data"].ToString()));
                 
                jogoList.Add(jogo);
                
            }
            con.Close();
            return jogoList;
        }
        public string inserirJogo(Jogo jogo)
        {
            string mensagem = "";
            try
            {
                using (MySqlConnection con = CriadorConexao.getConexao("ConexaoPadrao"))
                {
                    con.Open();
                    using (MySqlCommand mySqlCommand = new MySqlCommand("INSERT INTO Jogo(nome, urlCapa, descricao, categoria,preco,desconto,data) VALUES (@nome, @urlCapa, @descricao,@categoria,@preco,@desconto,@data)", con))
                    {
                        mySqlCommand.Parameters.AddWithValue("@nome", jogo.Nome);
                        mySqlCommand.Parameters.AddWithValue("@urlCapa", jogo.UrlCapa);
                        mySqlCommand.Parameters.AddWithValue("@descricao", jogo.Descricao);
                        mySqlCommand.Parameters.AddWithValue("@categoria", jogo.Categoria);
                        mySqlCommand.Parameters.AddWithValue("@preco", jogo.Preco);
                        mySqlCommand.Parameters.AddWithValue("@desconto", jogo.Desconto);
                        mySqlCommand.Parameters.AddWithValue("@data", jogo.Data);

                        int rowsAffected = mySqlCommand.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            mensagem = "Jogo cadastrado com sucesso";
                        }
                        else
                        {
                            mensagem = "Falha ao cadastrar jogo";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                mensagem = "Ocorreu um erro ao cadastrar o jogo: " + ex.Message;
            }
            return mensagem;
        }
    }
}
