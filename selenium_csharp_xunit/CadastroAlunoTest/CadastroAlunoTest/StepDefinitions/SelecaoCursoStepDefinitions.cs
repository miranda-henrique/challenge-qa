using System;
using CadastroAlunoTest.Pages;
using OpenQA.Selenium;
using Reqnroll;

namespace CadastroAlunoTest.StepDefinitions
{
    [Binding]
    public class SelecaoCursoStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;

        public SelecaoCursoStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<IWebDriver>();
        }

        private SelecaoCursoPage selecaoCursoPage;
        private SelecaoCursoPage SelecaoCursoPage => selecaoCursoPage ??= new SelecaoCursoPage(_driver);

        private CadastroPage cadastroPage;
        private CadastroPage CadastroPage => cadastroPage ??= new CadastroPage(_driver);

        [Given("Acesso a página de seleção de curso")]
        public void GivenAcessoAPaginaDeSelecaoDeCurso()
        {
            string textoEsperado = "Escolha o seu nível de ensino e embarque nessa aventura!";

            string textoEncontrado = SelecaoCursoPage.RetornaTextoElemento(SelecaoCursoPage.TextoInicial);
            Assert.Equal(textoEsperado, textoEncontrado);
        }

        [Given("Seleciono nível de ensino graduação")]
        public void GivenSelecionoNivelDeEnsinoGraduacao()
        {
            SelecaoCursoPage.SelecionaNivelGraduacao();
        }

        [Given("Seleciono o curso {string}")]
        public void GivenSelecionoUmCursoDeGraduacao(string curso)
        {
            SelecaoCursoPage.SelecionaCurso(curso);
        }

        [When("Clico em Avançar")]
        public void WhenClicoEmAvancar()
        {
            SelecaoCursoPage.BotaoAvancar.Click();
        }

        [Then("Sou redirecionado para a tela de cadastro")]
        public void ThenSouRedirecionadoParaATelaDeCadastro()
        {
            string textoEsperado = "Pronto para essa aventura? Comece nos contando um pouco sobre você!";
            string textoObtido = CadastroPage.RetornaTextoElemento(CadastroPage.TextoInicial);

            Assert.Equal(textoEsperado, textoObtido);
        }

        [Given("Seleciono nível de ensino pós-graduação")]
        public void GivenSelecionoNivelDeEnsinoPos_Graduacao()
        {
            SelecaoCursoPage.SelecionaNivelPos();
        }

        [Then("É exibida mensagem de erro de seleção de curso")]
        public void ThenEExibidaMensagemDeErroDeSelecaoDeCurso()
        {
            string textoEsperado = "Por favor, selecione um curso...";
            string textoObtido = SelecaoCursoPage.Alert.Text.Trim();

            Assert.Equal(textoEsperado, textoObtido);
        }
    }
}
