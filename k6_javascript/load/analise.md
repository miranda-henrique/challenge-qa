## Análise

- Foi realizado um teste de carga que simula um escalonamento de usuário simultâneos nas seguintes fases 0-100-500-1000-0.
- Para 100 e 500 usuários, a API se comportou de maneira esperada e estável. Para o cenário de 1000 usuários, houve diversas falhas nas requisições, com o tempo de resposta chegando ao máximo de 29 segundos, algo que é extremamente prejudicial para a experiência do usuário na ponta e pode resultar em falhas em função de infraestrutura. Vale entender se há algum gargalo de infra que possa ser contornado ou se há alguma melhoria de eficiência no código que possa permitir um processamento mais eficiente em cenários de carga elevada.
- Mesmo assim, as métricas sugerem certa estabilidade no geral, com média, mediana e P90 muito próximos. É possível que, mesmo com as falhas, a experiência no final não seja tão impactada. Contudo, é extremamente válida a análise mencionada no item anterior.
