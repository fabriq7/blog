using Blog.Shared.Entities;
using System;

namespace Domain
{
    public class User : Entity
    {
        public User(string username, string password)
        {
            Login = username;
            Password = password;

            Validar();
        }

        protected User()
        {

        }

        public string Login { get; private set; }
        public string Password { get; private set; }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Login))
                throw new Exception("Login deve ser informado!");

            if (string.IsNullOrEmpty(Password))
                throw new Exception("Senha deve ser informada!");
        }
    }
}
