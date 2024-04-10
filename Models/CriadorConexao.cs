using MySql.Data.MySqlClient;

namespace ProjetoPixelPlace.Models
{
    public class CriadorConexao
    {
        public CriadorConexao()
        {
        }

        public static MySqlConnection getConexao()
        {
            
            MySqlConnection conexao = new MySqlConnection(Configuration().GetConnectionString("casa"));

            if (conexao == null) {
                return new MySqlConnection(
                Configuration().GetConnectionString("ConexaoPadrao"));
            }
            return conexao;
        }

        private static IConfigurationRoot Configuration()
        {
            IConfigurationBuilder builder =
                new ConfigurationBuilder().SetBasePath(
                    Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", true, true);

            return builder.Build();
        }
    }
}
