Executando o projeto

Premissas:
Ter o banco de dados Postgres instalado na versão 13

Dados que são usados para conexão com o banco, no arquivo appsettings.json (na raiz do projeto API):
- "ConnectionStrings": {
    "BlogDB": "Host=localhost;Port=5432;Pooling=true;Database=BLOG;User Id=postgres;Password=root;"
}

Se o seu banco de dados contém, por exemplo, User Id ou Password diferente, fique á vontade para trocar, para que a aplicação funcione.

------------------------------------------------------

1. Criação do banco de dados:
Navegue até a raiz do projeto "API" e execute os seguintes comandos para criar o banco de dados:
- dotnet ef database update

Feito isso, o banco estará criado, basta agora executar o projeto e acessar o swagger (o swagger expõe a API, facilitando o teste dos endpoints).

Você pode criar um usuário no endpoint /user/add, que terá como resposta o ID gerado pelo sistema.

Com o usuário criado, você pode fazer a autenticação no endpoint /user/login. Se o usuário e senha estiverem cadastrados no sistema, o endpoint retornará um token.

Com este token, você poderá criar, consultar e deletar posts e comentários. Vale lembrar que, somente o usuário criador do post ou comentário tem permissão para deletá-lo.
