Feature: Seleção de curso

Scenario: Selecionar curso de graduação
	Given Acesso a página de seleção de curso
	And Seleciono nível de ensino graduação
	And Seleciono o curso "Administração"
	When Clico em Avançar
	Then Sou redirecionado para a tela de cadastro

Scenario: Selecionar curso de pós-graduação
	Given Acesso a página de seleção de curso
	And Seleciono nível de ensino pós-graduação
	And Seleciono o curso "Mestrado em Engenharia de Software"
	When Clico em Avançar
	Then Sou redirecionado para a tela de cadastro


Scenario: Avançar sem preencher curso
	Given Acesso a página de seleção de curso
	And Seleciono nível de ensino graduação
	When Clico em Avançar
	Then É exibida mensagem de erro de seleção de curso

