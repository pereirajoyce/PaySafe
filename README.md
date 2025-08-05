Tabela de conteúdos
=================

* [Sobre](#markdown-header-sobre)
* [Diagrama de Arquitetura](#markdown-header-diagrama-de-arquitetura)
* [Fluxo de Solicitações e Dependências](#markdown-header-fluxo-de-solicitacoes-e-dependencias)
* [Responsáveis](#markdown-header-responsaveis)
* [Links](#markdown-header-links)
* [Monitoramento](#markdown-header-monitoramento)
* [Tecnologias](#markdown-header-tecnologias)
* [Guia de Bordo](#markdown-header-guia-de-bordo)
* [FAQ](#markdown-header-faq)

- - -
## Sobre

A documentação de cada serviço deve começar com uma descrição do serviço. Ela deve ser curta, cativante e objetiva. Isso é essencial, pois garante que qualquer pessoa que encontrar a documentação saberá qual o papel desempenhado pelo serviço em nosso ecossistema de aplicações.

## Diagrama de Arquitetura

É quase impossível entender como e por que um serviço funciona apenas lendo o seu código, portanto um diagram de arquitetura bem desenhado é uma descrição visual e um resumo de fácil entendimento de um serviço. Este diagram deve detalhar a arquitetura do serviço, incluindo seus componentes, seus endpoints, o fluxo de solicitações, suas dependências e informações sobre quaisquer databases, caches e message brokers e etc. 

Dê uma olhada neste exemplo:

![Alt text](docs/diagrama-arquitetura.png)

## Fluxo de Solicitações e Dependências

A documentação do fluxo de solicitações pode conter um diagrama dos fluxos de solicitações da aplicação. Qualquer diagrama deve ser acompanhado por uma descrição qualitativa dos tipos de solicitações que são feitas para o serviço e como elas são tratadas.
			
As informações sobre as dependências do serviço podem conter os endpoints relevantes dessas dependências e quaisquer solicitações que o serviço faça a elas, juntos das informações sobre seus SLAs, de quaisquesr alternativas/caches/backups em caso de falha e dos links para sua documentação e seus dashboards.

## Responsáveis

Essa seção deve conter os nomes, os cargos, times e as informações de contato do time responsável pelo serviço. Essas informações são úteis, por exemplo, quando um desenvolvedor tem problemas relativos a uma de suas depedências: saber quem contatar e qual o seu papel na equipe torna a comunicação entre equipes fácil e eficiente.

## Links

Quaisquer informação extras que possam ser úteis para o desenvolvedor devem ser incluídas aqui.

|   | Prod | Hml | Qa  
| ------------- | :-------------: | :-------------: | :-------------: |
| API  | [link]() | [link]() | [link]()
| Jobs  | - | - | [link](https://jobs-qa.autoglass.com.br/sms)
| Kibana | [link](https://logs.autoglass.com.br) | [link](https://logs-hml.autoglass.com.br) | -
| NewRelic | - | - | -
| Jenkins | [link]() | - | - |
| SonarQube | [link]() | - | - |


## Monitoramento

**Eventos de log registrados no Kibana**

index: dotnet-\*-template-dotnetcore-api-\*

| EventoId | Descrição |
| ------ | --------- |
| - | - |
| Exception | Erros com stackatrace que são disparados pela a aplicação|

**Dashboards de monitoramento**

| Dashboard | Link | 
| ------ | --------- |
| - | - |

**Alertas**

| Tipo | Stack | Notifica |  |
| ---- | ----- | -------- | ---- |
| % Erros | NewRelic | Arquitetura de Software | [link]()

## Tecnologias

Lista de tecnologias utilizadas no projeto

## Guia de Bordo

A finalidade desta seção é ajudar um novo desenvolvedor a entrar na equipe, começar a contribuir com código, adicionar recursos ao serviço, introduzir novas alterações no pipeline de deployment e etc.

Veja os exemplos:

**Instalar Cake**
```bash
dotnet tool restore
```

**Build**

```bash
dotnet cake --target buildsolution
```

**Tests**

```bash
# Executando testes unitários (powershell)

dotnet cake --target testrun

# Executando a avaliação da cobertura de testes unitários (powershell)

dotnet cake --target testreport
```

**Docker**

```bash
# Api
docker build -t template-dotnetcore-api . -f Autoglass.Automacao.API\Dockerfile
docker container run -e "ASPNETCORE_ENVIRONMENT=Development" -p 5001:5001 template-dotnetcore-api:latest

# Jobs
docker build -t template-dotnetcore-jobs . -f Autoglass.Automacao.Jobs\Dockerfile
docker container run -e "ASPNETCORE_ENVIRONMENT=Development" -p 60000:60000 template-dotnetcore-jobs :latest
```

**CI**

O projeto possui por padrão os seguintes stages em seu pipeline de integração contínua

build -> testes unitários -> validar cobertura de código (100%) -> análise do SonarQube


## FAQ

Existem duas categorias de perguntas que devem ser respondidas aqui. A primeira envolve as perguntas que os desenvolvedores em outras equipes fazer o serviço. A maneira de saber se essas perguntas devem ser incluídas numa FAQ é simples: se alguém fizer uma pergunta e você achar que ela pode ser feita novamente, acrescente-a à lista FAQ. A segunda categoria engloba as perguntas que vêm dos membros da equipe, e a mesma abordagem pode ser adotada: se houver uma pergunta sobre como ou por que ou quando fazer algo relacionado ao serviço, acrescente-a à lista FAQ. 

Vejam os seguintes exemplos:

**1 - Como posso integrar a minha aplicação com este microservice?**

A integração pode ser realizada através....

**2 - É possível fazer a integração de forma assíncrona?**

Sim. Basta apenas consumir o topic "xpto" no SQS...

