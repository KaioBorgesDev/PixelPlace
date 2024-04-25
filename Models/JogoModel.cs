using ProjetoPixelPlace.Entities;

namespace ProjetoPixelPlace.Models
{
    public class JogoModel
    {
        public JogoModel()
        {
        }

        public List<Jogo> getAllJogos()
        {

            List<Jogo> jogos = new List<Jogo>();
            var jogo1 = new Jogo(null, "Gta V", "null", "Jogo de Tiro", "RPG", 400.00, 5.00, "2021/12/12");
            jogos.Add(jogo1);

            return jogos;
        }
    }
}
