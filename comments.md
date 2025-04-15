# Comentários

### Detalhes da implementação

Projeto web baseado em: [ReqnrollSelenium](https://github.com/tulavalle/ReqnrollSelenium)

Tecnologias utilizadas:

- Projeto Web: Selenium com C#, XUnit e Reqnroll

Execução:

- Os testes web podem ser executados tanto em navegadores locais, quanto no Selenium Grid. Para alterar entre as modalidades, é necessário alterar o arquivo _appsettings.json_. Nesse arquivo, também é possível selecionar o modelo de navegador que será utilizado, estando disponíveis o chrome, firefox e edge.

```
{
 "driverSettings": {
   "browser": "chrome", -- altere para "firefox" ou "edge", caso deseje
   "baseUrl": "https://developer.grupoa.education/subscription/",
   "environment": "local", -- altere para "grid" p/ execução em selenium grid
   "gridUri": "http://localhost:4444/"
 }
}
```

- O Selenium Grid pode ser executado localmente via docker através do comando _docker-compose up_ executado sobre o seguinte script, sendo número total de instâncias de browsers disponível = max_instances X replicas:

```
version: '3'
services:
   selenium-hub:
       image: selenium/hub:latest
       ports:
           - '4444:4444'

   chrome:
       image: selenium/node-chrome:135.0.7049.85
       depends_on:
           - selenium-hub
       environment:
           - SE_EVENT_BUS_HOST=selenium-hub
           - SE_NODE_MAX_INSTANCES=6
           - SE_NODE_MAX_SESSIONS=6
       deploy:
           replicas: 1

   firefox:
       image: selenium/node-firefox:latest
       depends_on:
           - selenium-hub
       environment:
           - SE_EVENT_BUS_HOST=selenium-hub
           - SE_NODE_MAX_INSTANCES=6
           - SE_NODE_MAX_SESSIONS=6
       deploy:
           replicas: 1

   edge:
       image: selenium/node-edge:135.0.3179.54
       depends_on:
           - selenium-hub
       environment:
           - SE_EVENT_BUS_HOST=selenium-hub
           - SE_NODE_MAX_INSTANCES=6
           - SE_NODE_MAX_SESSIONS=6
       deploy:
           replicas: 1

```

- Pontos que incrementaria com mais tempo:

1. A estruturação do projeto com injeção de dependências utilizando _ScenarioDependencies_ resultou em conflito de versões do xunit. Seria necessário mais tempo para entender se há um contorno ou se é algo inerente ao reqnroll.
2. Implementaria cenários adicionais, incluindo a validação de modo claro/escuro, validando o css do fundo de tela, além de validar o campo de busca da área do candidato e o conteúdo da página da política de privacidade.
3. Há estruturas de lógica no código que se repetem e poderiam ser encapsuladas em um único método. Seria uma refatoração importante mas que, em parte, dependeria do ponto 1.
4. Criaria uma pipeline automatizada e, de preferência, tentaria integrá-la ao azure.
5. Implementaria relatórios com o ExtentRepors ou AllureReports.
