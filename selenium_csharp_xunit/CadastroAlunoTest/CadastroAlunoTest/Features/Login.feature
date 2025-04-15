Feature: Login

Scenario: Login com sucesso
	Given Acesso a página de login
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
	And Preencho campo usuário com "candidato"
	And Preencho campo senha com "subscription"
	When Clico em Login
	Then Sou redirecionado para a área do candidato

Scenario: Login sem preencher dados
	Given Acesso a página de login
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
	When Clico em Login
	Then Recebo mensagem de que campos são obrigatórios





