using Blog.Shared.Entities;
using System;

namespace Domain
{
    public class Post : Entity
    {
        protected Post()
        {

        }
        public Post(string text, string image, string link, User user)
        {
            Text = text;
            Image = image;
            Link = link;
            User = user;

            Validar();
        }

        public string Text { get; private set; }
        public string Image { get; private set; }
        public string Link { get; private set; }
        public User User { get; private set; }
        public Guid UserId { get; set; }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Text))
                throw new Exception("Texto da postagem deve ser informado!");

            if (string.IsNullOrEmpty(Image))
                throw new Exception("Imagem da postagem deve ser informada!");

            if (string.IsNullOrEmpty(Link))
                throw new Exception("Link da postagem deve ser informado!");
        }
    }
}
