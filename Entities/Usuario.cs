namespace ProjetoPixelPlace.Entities
{
    public class Usuario
    {
        private int? idUsuario;
        private string nomeUsuario;
        private string email;
        private string senha;
        private byte[] image;


        public Usuario(int? idUsuario, string nomeUsuario, byte[] image, string email, string senha)
        {
            this.idUsuario = idUsuario;
            this.nomeUsuario = nomeUsuario;
            this.image = image;
            this.email = email;
            this.senha = senha;
        }

      

        public string NomeUsuario { get => nomeUsuario; set => nomeUsuario = value; }
        public byte[] UrlImage { get => image; set => image = value; }
        public string Email { get => email; set => email = value; }
        public string Senha { get => senha; set => senha = value; }
        public int? IdUsuario { get => idUsuario; }

    }
}
