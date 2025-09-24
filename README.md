# PaySafe

**Sistema de Processamento de Pagamentos Seguro**

## Tabela de Conteúdos

* [Sobre](#sobre)
* [Arquitetura](#arquitetura)
* [Fluxo de Pagamentos](#fluxo-de-pagamentos)
* [Responsáveis](#responsáveis)
* [Links Úteis](#links-úteis)
* [Monitoramento](#monitoramento)
* [Tecnologias](#tecnologias)
* [Guia de Desenvolvimento](#guia-de-desenvolvimento)
* [FAQ](#faq)

---

## Sobre

O **PaySafe** é um serviço de processamento de pagamentos desenvolvido em .NET Core que oferece uma API robusta e segura para gerenciar transações financeiras. O sistema permite que empresas integrem facilmente funcionalidades de pagamento em suas aplicações, oferecendo suporte a diferentes métodos de pagamento e garantindo a segurança e integridade das transações através de um sistema de failback.

### Principais Funcionalidades

- Processamento de pagamentos com múltiplos métodos
- Gerenciamento de transações e empresas
- Sistema de failback para transações
- Validação de dados e tratamento de exceções
- Arquitetura limpa e modular
- API RESTful com documentação automática

## Arquitetura

O PaySafe segue os princípios da **Clean Architecture**, organizando o código em camadas bem definidas:

```
PaySafe/
├── src/
│   ├── PaySafe.API/              # Camada de apresentação (Controllers, Middleware)
│   ├── PaySafe.Application/       # Casos de uso e regras de aplicação
│   ├── PaySafe.Domain/           # Entidades e regras de negócio
│   │   ├── Pagamentos/           # Domínio de pagamentos
│   │   ├── Transacoes/           # Domínio de transações
│   │   └── Empresas/             # Domínio de empresas
│   ├── PaySafe.Infrastructure/   # Acesso a dados e serviços externos
│   ├── PaySafe.CrossCutting/     # Utilitários e cross-cutting concerns
│   └── PaySafe.IoC/             # Configuração de dependências
└── tests/
    └── PaySafe.Domain.Tests/     # Testes unitários
```

### Principais Entidades

- **Pagamento**: Representa um pagamento com método, valor e status
- **Transacao**: Gerencia transações com preço total, taxa, frete e itens
- **Empresa**: Entidade responsável pelas transações

## Fluxo de Pagamentos

### Fluxo Principal

1. **Criação de Empresa** - Cadastro da empresa no sistema
2. **Criação de Transação** - Registro da transação com itens, preços e taxas
3. **Processamento de Pagamento** - Vinculação do pagamento à transação
4. **Validação e Confirmação** - Verificação e atualização do status

### Endpoints Principais

- `POST /api/empresas` - Cadastrar empresa
- `POST /api/transacoes` - Criar transação
- `POST /api/pagamentos` - Processar pagamento

### Métodos de Pagamento Suportados

- Cartão de Crédito
- Cartão de Débito
- PIX
- Boleto Bancário

## Responsáveis

| Função | Nome | Contato |
|--------|------|----------|
| Desenvolvedora | Joyce Pereira | joyce_paiva32@hotmail.com |


## Tecnologias

### Backend
- **.NET 8.0** - Framework principal
- **C#** - Linguagem de programação
- **ASP.NET Core Web API** - API REST
- **Entity Framework Core** - ORM para acesso a dados

### Banco de Dados
- **SQL Server** - Banco principal
- **Redis** - Cache (se aplicável)

### Ferramentas de Build e Deploy
- **Cake** - Build automation
- **Docker** - Containerização
- **Azure** - CI/CD

### Testes e Qualidade
- **xUnit** - Framework de testes
- **SonarQube** - Análise de código
- **Coverlet** - Cobertura de código

### Documentação
- **Swagger/OpenAPI** - Documentação da API

## Guia de Desenvolvimento

### Pré-requisitos

- .NET 8.0 SDK
- Visual Studio 2022 ou VS Code
- SQL Server (LocalDB para desenvolvimento)
- Docker Desktop (opcional)
- Git

### Configuração do Ambiente

1. **Clone o repositório**
```bash
git clone <repository-url>
cd PaySafe
```

2. **Restaure as ferramentas**

```bash
dotnet tool restore
```

3. **Configure a string de conexão** no arquivo `appsettings.Development.json`

### Comandos Úteis

**Build do projeto**
```bash
dotnet cake --target buildsolution
```

**Executar testes**
```bash
# Testes unitários
dotnet cake --target testrun

# Relatório de cobertura
dotnet cake --target testreport
```

**Executar a API localmente**
```bash
dotnet run --project src/Apps/PaySafe.API
```

**Docker**
```bash
# Build da imagem
docker build -t paysafe-api . -f src/Apps/PaySafe.API/Dockerfile

# Executar container
docker run -e "ASPNETCORE_ENVIRONMENT=Development" -p 5001:5001 paysafe-api:latest
```

### Estrutura de Migrations
```bash
# Adicionar migration
dotnet ef migrations add <NomeMigration> --project PaySafe.Infrastructure

# Aplicar migrations
dotnet ef database update --project PaySafe.Infrastructure
```

**CI**

O projeto possui por padrão os seguintes stages em seu pipeline de integração contínua

build -> testes unitários -> validar cobertura de código (100%) -> análise do SonarQube


## FAQ


**1 - Como integrar minha aplicação com o PaySafe?**

A integração é feita através da API REST. Consulte a documentação do Swagger em `/swagger` para ver todos os endpoints disponíveis. É necessário:
- Cadastrar a empresa no sistema
- Criar transações antes de processar pagamentos
- Usar os GUIDs para referenciar entidades

**2 - Quais métodos de pagamento são suportados?**

Atualmente suportamos: Cartão de Crédito, Cartão de Débito, PIX e Boleto Bancário. Novos métodos podem ser adicionados através do enum `MetodoPagamentoEnum`.

**3 - Como funciona o sistema de status?**

Tanto pagamentos quanto transações possuem status que podem ser atualizados ao longo do ciclo de vida. Os status disponíveis estão no enum `StatusEnum`.

**4 - Como tratar erros na integração?**

A API retorna códigos HTTP padronizados e mensagens de erro estruturadas. Verifique os logs no Kibana para detalhes adicionais sobre falhas.

