﻿namespace ProjetoPixelPlace.Entities
{
    public class Jogo
    {
        string? idJogo;
        string nome;
        string urlCapa;
        string descricao;
        string categoria;
        double preco;
        double desconto;
        string data;

        public Jogo(string? idJogo, string nome, string urlCapa, string descricao, string categoria, double preco, double desconto, string data)
        {
            this.idJogo = idJogo;
            this.nome = nome;
            this.urlCapa = urlCapa;
            this.descricao = descricao;
            this.categoria = categoria;
            this.preco = preco;
            this.desconto = desconto;
            this.data = data;
        }

        public string? IdJogo { get => idJogo; set => idJogo = value; }
        public string Nome { get => nome; set => nome = value; }
        public string UrlCapa { get => urlCapa; set => urlCapa = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public string Categoria { get => categoria; set => categoria = value; }
        public double Preco { get => preco; set => preco = value; }
        public double Desconto { get => desconto; set => desconto = value; }
        public string Data { get => data; set => data = value; }
    }
}
