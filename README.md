# Sobre o AspNetCoreAPI

O AspNetCoreAPI é uma API simples feita em **ASP.NET CORE 3.1** utilizando o **Entity Framework** como ORM, o projeto foi feito para fins de aprendizado. Conceitos como métodos http, migrations, CLI do dotnet, validações com base no modelo, padrão de CodeFirst, e SQL Server hospedado no AZURE foram aplicados de forma prática nesta solução.

# Entidades
O AspNetCoreAPI consiste em uma entidade de categorias e uma entidade de produtos onde possui a seguinte estrutura:

 - Category
	 - iD : Chave primária da entidade (int)
	 - Title: Título da categoria (string)
 - Product
	 - iD : Chave primária da entidade (int)
	 - Title: Título do produto (string)
	 - Description: Descrição do produto (string)
	 - Price: Preço do produto (decimal)
	 - CategoryID : Id da categoria a quem pertence o produto (int)

# Funções
O AspNetCoreAPI consiste em algumas funções, atendendo ao CRUD:

 - Adicionar Categoria
 - Listar Categorias

 - Adicionar Produto
 - Listar Produtos
 - Listar Produto pelo ID
 - Listar Produtos pelo ID da categoria
 - Atualizar Produto especificado pelo ID
 - Deletar Produto especificado pelo ID

# Conceitos aplicados
No desenvolvimento do AspNetCoreAPI alguns conceitos foram colocados em prática:
	
 - ASP.NET CORE MVC 3.1 API
 	- Sistema de roteamento por controllers e por métodos HTTP
	- Validações com base em Model
	- Padrão REST API
- CLI do dotnet
```dotnet
dotnet new webapi -o aspnetcoreapi
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 3.1.5
dotnet run
```
 - Entity Framework (code-first)
 	- Migrations para construção do banco de dados (pasta Migrations)
 - Conexão ao banco de dados utilizando SQL Server em nuvem (Senha da connection string já modificada no servidor)
 - Conceito MVC
 	- Models de entidade (Pasta Models)
 	- Controladores de entidade (Pasta Controlers)
 - CRUD utilizando um ORM (Entity Framework)


