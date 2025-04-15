## Análise

- Foram avaliados três cenários: 100, 500 e 1000 usuários simultâneos realizando tantas requisições quanto possível durante 1 minuto.
- Nenhum dos três cenários apresentou falha em requisições.
- Para o cenário de 100 usuário, média e mediana foram bastante próximas, indicando consistência nos dados. Corrobora isso o fato do P90 estar ligeiramente acima de ambas, mas bastante abaixo do valor máximo de tempo de resposta, sugerindo que o máximo é um outlier e não representa o comportamento normal da API.
- Para o cenário de 500 usuários, embora não tenha havido falhas nas reuquisições, os tempos de resposta são substancialmente superiores ao cenário de 100VUs. Discrepância entre as métricas sugere não apenas que houve ocorrência de outliers, mas, também, que a API, no geral, se comportou substancialmente mais lenta neste cenários.
- Para o cenário de 1000 usuários, o comportamento foi muito semelhante ao de 100VUs e apresenta estabilidade. Houve ocorrência de outliers, mas que não prejudicam o resultado geral.
