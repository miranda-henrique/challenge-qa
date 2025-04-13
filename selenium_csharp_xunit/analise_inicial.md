Aplicação Base: Portal de Inscrições - Grupo A
<br>
URL: https://developer.grupoa.education/subscription/

### Descrição:

- Aplicação consiste em um portal para que candidatos possam realizar o cadastro de seus dados pessoais após a seleção de um dos cursos disponíveis.

### Fluxo principal:

- Candidato seleciona nível de ensino
    - Graduação
    - Pós-graduação
- Candidato seleciona curso
    - É fornecido um dropdown com os cursos disponíveis.
    - OBS.: Cursos de graduação e de pós-graduação são listados de forma única, ou seja, não importa se a opção escolhida no passo anterior foi "Graduação" ou "Pós-graduação", todos os cursos serão exibidos. Provável bug.
- Candidato preenche dados pessoais
    - Dados solicitados
        - CPF
        - Nome e Sobrenome
        - Nome social
        - Data de nascimento
        - Dados sobre deficiência
        - Dados de contato (email, celular, telefone)
        - Dados de endereço (CEP, endereço, complemento, bairro, cidade, estado, país)
    - Dados marcados como obrigatórios:
        - CPF, Nome, Sobrenome, Dada de nascimento, Email, Celular, CEP, Endereço, Bairro, Cidade, Estado, País
    - OBS.:
        - Campo "Possui alguma deficiência?", embora não seja marcado como obrigatório, é exigido. Provável bug.
        - Campo "Data de nascimento", embora marcado como obrigatório, não é exigido. Bug.
        - Campo "Data de nascimento" não realiza validação da data inserida e aceita a data atual (que já vem preenchida), data futura ou "dd/mm/aaaa". Bug
        - Campos "Celular" e "Telefone" aceitam letras e caracteres quaisquer. Bug
        - Campo "CEP" aceita letras e caracteres quaisquer. Bug
        - Campos "Cidade", "Estado" e "País" são campos abertos, porém, dado que essas informações são limitadas, ou seja, são pré-estabelecidas, é interessante que sejam fornecidas via dropdown ou preenchidas com base no CEP.
        - Campos "Nome", "Sobrenome", "Nome social", "Qual deficiência?", "Endereço", "Complemento", "Bairro", "Cidade", "Estado" e "País" não possuem nenhuma validação de caracteres, sendo possível, inclusive, inserir queries. Bug
- Feito o preenchimento dos dados, candidato é enviado para tela "Sua jornada começa aqui!". São informados seu nome de usuário e senha. Por se tratarem de dados sensíveis, deveriam ser enviados para o email informado. Bug
- Candidato é então enviado para a tela de login para acesso à área do candidato. É possível enviar solicitações de recuperação de nome de usuário e senha nessa tela.
    - Ao tentar realizar login com um usuário que não existe, é exibida a mensagem "Usuário inválido". Pode ser interessante exibir uma mensagem mais genérica, como "Falha na autenticação", de modo a evitar expor a informação de que determinado usuário consta ou não na base. Bug
- Feito o login, usuário é direcionado para a área do candidato, onde pode consultar informações através dos menus "Minhas inscrições" e "Financeiro"

    - Campo de busca não funciona. Bug

- #### Dados gerais:
    - Há um ícone no canto superior direito que oferece a funcionalidade de alternar entre modos claro e escuro
    - Há uma aba "Privacidade", na qual consta a política de privacidade
    - Menu "Home" e ícone da empresa no canto superior esquerdo redirecionam o usuário para a tela inicial de seleção de nível de ensino
