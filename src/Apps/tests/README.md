# PaySafe Domain Layer Tests

Este projeto contém os testes unitários para a camada de domínio do PaySafe.

## Estrutura

```
PaySafe.Domain.Tests/
├── ValueObjects/           # Testes para value objects (Email, Cpf, etc.)
├── Entities/              # Testes para entidades do domínio
├── Services/              # Testes para serviços de domínio
└── PaySafe.Domain.Tests.csproj
```

## Tecnologias Utilizadas

- **xUnit**: Framework de testes
- **FluentAssertions**: Biblioteca para assertions mais legíveis
- **Moq**: Framework para criação de mocks
- **.NET 9.0**: Target framework

## Como Executar

### Via CLI
```bash
dotnet test PaySafe.Domain.Tests.sln
```

### Via Visual Studio
1. Abra a solution `PaySafe.Domain.Tests.sln`
2. Execute os testes através do Test Explorer

## Estrutura dos Testes

### Value Objects
Testam a validação e comportamento dos value objects como Email, Cpf, etc.

### Entities
Testam as regras de negócio e validações das entidades de domínio.

### Services
Testam os serviços de domínio utilizando mocks para as dependências (repositories, outros services).

## Padrões Adotados

- **AAA Pattern**: Arrange, Act, Assert
- **Naming Convention**: `MethodName_Scenario_ExpectedResult`
- **Test Categories**: Uso de Theory/InlineData para testes parametrizados
- **Mocking**: Uso do Moq para simular dependências