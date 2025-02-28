# LuminiTeste

## Padrões de código
1. Todo o código, nomes de variáveis etc devem ser escritos em inglês.
2. Utilizar scripts para Migrations verificando se os artefatos de banco já existem sempre.

## Decisoes arquiteturais
1. Aplicação e banco de dados rodando em containeres, incluindo a criação da base de dados. Os artefatos esão na pasta scripts na raiz da aplicação.
2. Centralizei o Dominio e as Interfaces de Repositorio e Service na camada de Domain.
3. Dapper como ORM e DbUp para as Migrations. As pastas para os Scripts estão na Api, dentro de Migrations/Scripts.
4. Testes unitários com XUnit e Nsubstitute para mock.

## Swagger
localhost:4702/docs

## Executando localmente
1. Executar compose
```
docker-compose up
```

## Building Docker image
```
docker build -t back_luminiteste .
```

## Executando os testes
````
cd src/LuminiTeste/LuminiTeste.Tests
dotnet test
````

## Variáveis de ambiente
- ASPNETCORE_ENVIRONMENT=Ambiente de execução (Dev, Prod, QA)
- MSSQL_SA_PASSWORD=Senha do banco
- CONNECTION_STRING=String de conexão no banco no formato: "Data Source=db,1433;Initial Catalog=DB_LUMINI_TESTE;User Id=sa;TrustServerCertificate=true;Password='senha'"
- ASPNETCORE_URLS=URL da aplicação

### Conectando no banco local
Dados da conexão:
SERVIDOR: localhost
PORTA: 1434
USUÁRIO: sa
SENHA: senha_no_env