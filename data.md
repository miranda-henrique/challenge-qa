# Sobre a validação do banco de dados

- Embora essa validação seja mais comum em testes de APIs, nada impede que ela também seja feita nos testes web.

Estratégia de testes:

- É essencial que a base disponível no ambiente de testes seja, em termos de configurações e schemas, idêntica à base de produção. Caso contrário, os testes poderão ser inválidos.
- Os dados podem ou não serem replicados de produção. Se sim, é essencial que sejam devidamente anonimizados para que sejam aderentes à LGPD. Considerando a aplicação em questão, dados aleatórios são igualmente úteis e talvez preferíveis dado que o processo de geração das massas será menos custoso.
- É necessário que as massas utilizadas nos cenários, manuais ou automatizados, seja equivalente a estrutura do banco.
- No caso das automações, os dados podem ser inseridos ou manualmente, via tabelas do próprio reqnroll, ou gerados de forma aleatória através da implementação de um _factory_.
- A validação da persistência dos dados pode ser feita de duas formas:

1. Manualmente, através de uma conexão direta com o banco de testes realizada através do _pgadmin_ ou _dbeaver_, por exemplo. A consulta dos dados nesse caso pode ser feita através de uma query.
2. De maneira automatizada, adicionando ao projeto uma dependência que permita a conexão com o banco como, por exemplo o _npgsql_. O ideal é que seja estabelecida uma conexão com o banco em momento anterior ao início do teste e, uma vez concluída a última etapa do cenário automatizado, a informação persistida será buscada no banco e comparada via assert com os dados de entrada do teste.
