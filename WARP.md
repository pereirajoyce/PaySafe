# WARP.md

This file provides guidance to WARP (warp.dev) when working with code in this repository.

## Project Overview

PaySafe is a multi-broker payment checkout system built with .NET 9 using Clean Architecture principles. The system manages companies (Empresas), subscription plans (Planos), and users (Usuarios) with payment processing capabilities.

## Architecture

The project follows Clean Architecture with clear separation of concerns:

- **PaySafe.Domain**: Core business entities, value objects, commands, and domain services
- **PaySafe.Application**: Application services, DTOs, and use cases
- **PaySafe.Infrastructure**: Data access using NHibernate ORM, external service integrations
- **PaySafe.CrossCutting**: Cross-cutting concerns and shared utilities
- **PaySafe.IoC**: Dependency injection configuration using native .NET DI
- **PaySafe.API**: RESTful API endpoints and controllers

### Key Patterns Used

- **Repository Pattern**: Data access abstraction with NHibernate
- **Command Pattern**: For creating/updating entities (EmpresaCommand, PlanoCommand, etc.)
- **Value Objects**: For domain primitives (Cnpj, Cpf, Email)
- **Domain Services**: Business logic encapsulation
- **Dependency Injection**: Native .NET container with Scrutor for auto-registration

## Development Commands

### Build and Run
```powershell
# Build the entire solution
dotnet build PaySafe.sln

# Run the API (defaults to port 1901 with /paysafe-api path base)
dotnet run --project src/Apps/PaySafe.API/PaySafe.API.csproj

# Build in Release mode
dotnet build PaySafe.sln --configuration Release
```

### Testing
```powershell
# Run all tests
dotnet test

# Run tests with coverage
dotnet test --collect:"XPlat Code Coverage"

# Run specific test project
dotnet test tests/PaySafe.Domain.Tests/PaySafe.Domain.Tests.csproj
```

### Database
```powershell
# Execute database scripts in order (MySQL/MariaDB):
# 1. CONFIGURACAO.sql
# 2. PLANO.sql
# 3. EMPRESA.sql
# 4. USUARIO.sql
# 5. GATEWAY.sql
# 6. GATEWAY_PARAMETROS.sql
# 7. TRANSACAO.sql
# 8. TRANSACAO_PAGAMENTO.sql
```

## Core Domain Concepts

### Entities
- **Empresa**: Company with subscription plan, identified by CNPJ
- **Plano**: Subscription plan with pricing, volume limits, and user/group restrictions
- **Usuario**: System users associated with companies

### Value Objects
- **Cnpj**: Brazilian company identifier with validation
- **Cpf**: Brazilian personal identifier with validation  
- **Email**: Email address with validation

### Key Business Rules
- Companies must have a valid subscription plan
- Plans define monthly fees, transaction volumes, and user limits
- All entities use GUIDs for public identification while using integers internally
- Domain entities enforce invariants through setter methods with validation

## API Structure

The API follows RESTful conventions:
- GET `/api/empresas/{guid}` - Retrieve company
- POST `/api/empresas` - Create company
- PUT `/api/empresas/{guid}` - Update company
- DELETE `/api/empresas/{guid}` - Delete company

Similar patterns for `/api/planos` and `/api/usuarios`.

## Configuration

### Application Settings
- API runs on port 1901 by default
- Path base: `/paysafe-api`
- Configuration in `appsettings.json` under "Application" section

### Key Dependencies
- .NET 9.0
- NHibernate for ORM
- Swagger/OpenAPI for documentation
- Mapster for object mapping
- xUnit for testing
- JWT Bearer authentication support

## Development Guidelines

### Adding New Features
1. Start with domain entities in `PaySafe.Domain`
2. Create command/filter objects for data transfer
3. Implement repository interfaces and domain services
4. Add application services in `PaySafe.Application`
5. Implement infrastructure in `PaySafe.Infrastructure`
6. Register dependencies in `PaySafe.IoC`
7. Create API controllers in `PaySafe.API`
8. Add corresponding database scripts

### Testing Strategy
- Domain tests focus on entity behavior and business rules
- Use xUnit framework
- Test projects follow naming convention: `{ProjectName}.Tests`

### Database Integration
- Uses NHibernateRepository for data access
- Repository pattern with async/await support
- Transaction management handled automatically
- Entity mapping through NHibernate conventions