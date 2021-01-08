using Blog.Shared.Entities;
using System;

namespace Domain
{
    public class Comment : Entity
    {
        protected Comment()
        {

        }
        public Comment(string text, User user, Post post)
        {
            Text = text;
            Post = post;
            User = user;

            Validar();
        }

        public string Text { get; private set; }
        public Post Post { get; private set; }
        public Guid PostId { get; set; }
        public User User { get; private set; }
        public Guid UserId { get; set; }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Text))
                throw new Exception("Texto do comentário deve ser informado!");
        }
    }
}
