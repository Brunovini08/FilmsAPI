API de Filmes em C#/.NET com Camada de Serviço
Descrição
Esta é uma API de filmes desenvolvida em C# utilizando o framework ASP.NET Core, Entity Framework Core para interação com um banco de dados MySQL e uma camada de serviço para melhorar a modularidade e organização do código. O projeto segue os princípios SOLID para garantir uma arquitetura robusta e escalável. AutoMapper é usado para mapeamento de entidades e DTOs.

project-root/
|-- src/
|   |-- Controllers/
|       |-- AddressController.cs
|       |-- FilmController.cs
|       |-- MovieTheaterController.cs
|       |-- SectionController.cs
|   |-- Database/
|       |-- FilmContext.cs
|       |-- Migrations
|   |-- Dtos/
|       |-- AddressDto.cs
|       |-- FilmDto.cs
|       |-- MovieTheaterDto.cs
|       |-- SectionDto.cs
|-- Models/
|       |-- Address.cs
|       |-- Film.cs
|       |-- MovieTheater.cs
|       |-- Section.cs
|   |-- Profiles/
|       |-- MappingProfiles.cs
|-- Services/
|       |-- AddressService.cs
|       |-- FilmService.cs
|       |-- MovieThaterService.cs
|       |-- SectionService.cs
|-- appsettings.json
|-- .env
|-- Program.cs

Funcionalidades Principais
Address:

Cadastrar, visualizar, atualizar e excluir endereços.
Film:

Cadastrar, visualizar, atualizar e excluir filmes.
Associar filmes a cinemas e sessões.
MovieTheater:

Cadastrar, visualizar, atualizar e excluir cinemas.
Associar cinemas a filmes e sessões.
Section:

Cadastrar, visualizar, atualizar e excluir sessões.
Associar sessões a cinemas e filmes.
Configuração do Ambiente
Instale o .NET SDK:

Certifique-se de ter o .NET SDK instalado na sua máquina.
Configurações do Banco de Dados:

Configure a string de conexão com o banco de dados MySQL no arquivo .env. Exemplo:
env
Copy code
CONNECTION_STRING=MinhaStringDeConexaoDoBancoDeDados
Executando a Aplicação:

Execute a aplicação usando o comando:
bash
Copy code
dotnet run
Documentação da API:

Acesse a documentação da API gerada automaticamente ao executar a aplicação em http://localhost:5000/swagger.
Contribuindo
Sinta-se à vontade para contribuir! Abra uma issue ou envie um pull request.

Licença
Este projeto está licenciado sob a MIT License.
