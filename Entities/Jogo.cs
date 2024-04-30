namespace ProjetoPixelPlace.Entities
{
    public class Jogo
    {
        int? idJogo;
        string nome;
        byte[] image;
        string descricao;
        string categoria;
        double preco;
        double desconto;
        DateTime data;

        public Jogo(int? idJogo, string nome, byte[] urlCapa, string descricao, string categoria, double preco, double desconto, DateTime data)
        {
            this.idJogo = idJogo;
            this.nome = nome;
            this.image = urlCapa;
            this.descricao = descricao;
            this.categoria = categoria;
            this.preco = preco;
            this.desconto = desconto;
            this.data = data;
        }

        public int? IdJogo { get => idJogo; set => idJogo = value; }
        public string Nome { get => nome; set => nome = value; }
        public byte[] UrlCapa { get => image; set => image = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public string Categoria { get => categoria; set => categoria = value; }
        public double Preco { get => preco; set => preco = value; }
        public double Desconto { get => desconto; set => desconto = value; }
        public DateTime Data { get => data; set => data = value; }
    }
}
