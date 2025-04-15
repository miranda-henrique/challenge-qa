Feature: Cadastro do Aluno

Scenario: Cadastro com sucesso
	Given Acesso a página de cadastro
	And Preencho todos os campos obrigatórios com as informações
	| Key            | Value                      |
	| CPF            | 14471971433                |
	| Nome           | Erick                      |
	| Sobrenome      | Mota                       |
	| DataNascimento | 14/03/1952                 |
	| Email          | erick-damota85@ygui.com.br |
	| Celular        | 68993384576                |
	| CEP            | 69905244                   |
	| Endereco       | Rua Alercio Dias           |
	| Bairro         | Orla                       |
	| Cidade         | Rio Branco                 |
	| Estado         | AC                         |
	| Pais           | Brasil                     |
	When Clico em Avançar Cadastro
	Then Sou redirecionado para tela de cadastro com sucesso

Scenario: Cadastro sem campos obrigatórios
	Given Acesso a página de cadastro
	When Clico em Avançar Cadastro
	Then É exibido erro em campos obrigatórios

