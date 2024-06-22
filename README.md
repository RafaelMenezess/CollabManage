# Aplicação de Gerenciamento de Colaboradores e Empresa

## Descrição
Esta aplicação web permite o gerenciamento de colaboradores e informações da empresa, facilitando a listagem, adição, edição e exclusão de colaboradores, bem como o registro e edição das informações da empresa.

## Tecnologias Utilizadas
- **Backend**: ASP.NET Core (C#)
- **Banco de Dados**: MySQL
- **ORM**: Entity Framework Core
- **Padrões Arquiteturais**: CQRS, Event Sourcing, DDD
- **Boas Práticas**: Clean Code, SOLID, TDD, BDD

## Funcionalidades
1. **Listagem de Colaboradores**
   - Exibe todos os colaboradores cadastrados.
   - Ordena os colaboradores por nome em ordem alfabética.

2. **Gerenciamento de Colaboradores**
   - Adiciona um novo colaborador.
   - Edita informações de um colaborador existente.
   - Realiza a exclusão lógica de colaboradores.

3. **Informações da Empresa**
   - Registra informações sobre a empresa (nome, endereço, telefone).
   - Permite a edição dessas informações.

## Requisitos
  - **.NET Core SDK**: Versão 5.0 ou superior
  - **MySQL**: Versão 5.7 ou superior

## Configuração e Execução
## Passo 1: Clonar o Repositório
  - git clone https://github.com/RafaelMenezess/CollabManage.git

## Passo 2: Configurar Variáveis de Ambiente
  - Configurar a String de Conexão no appsettings.json
  - Executar as migrations
    - No Package Manager Console execute o comando Update-Database 

## Passo 3: Compilar a Aplicação
  - dotnet build

## Passo 4: Executar a Aplicação Localmente
  - dotnet run


