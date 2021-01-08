Executando o projeto

Premissas:
Ter o banco de dados Postgres instalado na versão 13


------------------------------------------------------

1. Criação do banco de dados:
Navegue até a raiz do projeto "API" e execute os seguintes comandos para criar o banco de dados:
- dotnet ef migrations add InitialCreate
- dotnet ef database update

Feito isso, o banco estará criado, basta agora executar o projeto e acessar o swagger (o swagger expõe a API, facilitando o teste dos endpoints).

Você pode criar um usuário, que terá como resposta um token. Com este token, você poderá criar, consultar e deletar posts. Vale lembrar que, somente o usuário criador do post tem permissão para deletá-lo.
