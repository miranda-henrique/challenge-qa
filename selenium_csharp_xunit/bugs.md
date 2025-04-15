# Bugs

- Descrição: Campos "Nome", "Sobrenome", "Nome social", "Qual deficiência?", "Endereço", "Complemento", "Bairro", "Cidade", "Estado" e "País" não possuem nenhuma validação de caracteres, sendo possível, inclusive, inserir queries.
    -
    ```
    Given Acesso a página de preenchimento de dados do candidato
    When Preencho o campo nome com uma string com excesso de caracteres
    Then O número de caracteres do input é limitado
    ```
    - Resultado obtido: campo aceita qualquer número de caracteres.
    - **Severidade: Muito Alta**
    - Formulários e demais campos cujo preenchimento possa resultar na persistência de dados em bancos devem possuir validações e, principalmente, devem ter seu número de caracteres limitado à quantidade estritamente necessária. O motivo disso é que campos abertos se tornam alvos fáceis para tentativas de invasão através de SQL injections, por exemplo.

---

- Descrição: Após o envio dos dados cadastrais, informações de usuário e senha do candidato são exibidas em tela
    -
    ```
    Given Acesso a página de preenchimento de dados do candidato
    And Preencho todos os campos obrigatórios com dados válidos
    When Clico em Avançar
    Then Dados sensíveis não são exibidos
    ```
    - Resultado obtido: nome de usuário e senha são exibidos em tela.
    - **Severidade: Muito alta**
    - Caso o candidato esteja preenchendo o formulário em um espaço que não seja reservado, seus dados de acesso serão imediatamente expostos.

---

- Descrição: Campos "Celular" e "Telefone" aceitam letras e caracteres especiais diferentes de "()" e "-"
    -
    ```
     Given Acesso a página de preenchimento de dados do candidato
     And Preencho os campos celular e telefone com dados inválidos
     When Clico em Avançar
     Then É exibida mensagem de erro no campo indicando dados inválidos
    ```
    - Resultado obtido: cadastro é concluído com sucesso.
    - **Severidade: Alta**
    - Pode resultar em ausência da informação, impedindo que sejam feitos os devidos contatos posteriores com o candidato.

---

- Decrição: Campo "CEP" aceita letras e caracteres especiais diferentes de "-" e "."
    -
    ```
    Given Acesso a página de preenchimento de dados do candidato
    And Preencho o campo CEP com dados inválidos
    When Clico em Avançar
    Then É exibida mensagem de erro no campo indicando dados inválidos
    ```
    - Resultado obtido: cadastro é concluído com sucesso.
    - **Severidade: Alta**
    - É informação imprescindível para que sejam elaboradas estratégias de contato e para que sejam enviadas eventuais correspondências.

---

- Descrição: Tela de login exibe mensagem de "Usuário inválido" caso nome de usuário informado não conste na base.
    -
    ```
    Given Acesso a tela de login da área do candidato
    And Preencho o nome de usuário com um usuário inválido
    Then Não é exibida mensagem de usuário inválido
    ```
    - Resultado obtido: mensagem é exibida.
    - **Severidade: Alta**
    - Permite que sejam feitos ataques de força bruta ao oferecer retorno informando se determinado usuário consta ou não na base.

---

- Descrição: Todos os cursos são listados, independentemente da opção de nível de ensino selecionada.
    -
    ```
    Given Acesso a página inicial
    When Seleciono nível de ensino Graduação
    Then Não são exibidos cursos de mestrado
    And Não são exibidos cursos de especialização
    ```
    - Resultado obtido: São exibidos todos os cursos disponíveis.
    - **Severidade: Média**
    - O fluxo pode ser prejudicial para a experiência de usuário, na medida em que o usuário precisará buscar o curso que deseja dentre todos os disponíveis. Vale considerar também que a listagem não está em ordem alfabética, o que prejudica ainda mais a experiência.

---

- Descrição: Campo "Data de nascimento" é marcado como obrigatório, mas é opcional.
    -
    ```
    Given Acesso a página de preenchimento de dados do candidato
    And Preencho todos os campos obrigatórios com dados válidos
    And Apago as informações do campo data de nascimento
    When Clico em Avançar
    Then É exibida mensagem de erro no campo indicando que é obrigatório
    ```
    - Resultado obtido: cadastro é concluído com sucesso.
    - **Severidade: Média**
    - A informação pode ser extremamente valiosa para análises de dados futuras. Além disso, ela será requisitada em algum momento. Obtê-la durante o cadastro pode trazer uma experiência mais fluida para o candidato.

---

- Descrição: Campo "Data de nascimento" não realiza validações e aceita que seja cadastrada a data atual, data futura e "dd/mm/aaaa".
    -
    ```
    Given Acesso a página de preenchimento de dados do candidato
    And Preencho o campo data de nascimento com data inválida
    When Clico em Avançar
    Then É exibida mensagem de erro no campo indicando data inválida
    ```
    - Resultado obtido: cadastro é concluído com sucesso.
    - **Severidade: Média**
    - Dado inválido pode gerar inconsistências em base de dados e prejudicar análises de dados futuras.

---

- Descrição: Campo de busca da área do candidato não filtra menus.
    -
    ```
    Given Acesso a área do candidato
    When Preencho o campo de busca com um item válido do menu
    Then A lista de itens passa a conter apenas o item pesquisado
    ```
    - Resultado obtido: itens seguem inalterados.
    - **Severidade: Baixa**
    - Pode prejudicar a experiência de usuário.

---

### Melhoria: listar campos "Cidade", "Estado" e "País" ou como dropdown ou como campos pré-preenchidos com base no CEP informado.

### Melhoria: remover borda do checkbox "Possui deficiência", pois ele acaba de comportando da mesma forma como os demais elementos quando estão em cenário de exceção, o que não é o caso para esse campo em específico e pode gerar confusão para o usuário.
