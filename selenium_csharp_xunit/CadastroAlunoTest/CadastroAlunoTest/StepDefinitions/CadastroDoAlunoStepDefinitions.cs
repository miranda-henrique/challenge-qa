using CadastroAlunoTest.Models;
using CadastroAlunoTest.Pages;
using OpenQA.Selenium;


namespace CadastroAlunoTest.StepDefinitions
{
    [Binding]
    public class CadastroDoAlunoStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;

        public CadastroDoAlunoStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<IWebDriver>();
        }

        private SelecaoCursoPage selecaoCursoPage;
        private SelecaoCursoPage SelecaoCursoPage => selecaoCursoPage ??= new SelecaoCursoPage(_driver);

        private CadastroPage cadastroPage;
        private CadastroPage CadastroPage => cadastroPage ??= new CadastroPage(_driver);

        [Given("Acesso a página de cadastro")]
        public void GivenAcessoAPaginaDeCadastro()
        {
            string textoEsperado = "Pronto para essa aventura? Comece nos contando um pouco sobre você!";

            SelecaoCursoPage.NavegaAteCadastro();
            string textoObtido = CadastroPage.RetornaTextoElemento(CadastroPage.TextoInicial);

            Assert.Equal(textoEsperado, textoObtido);
        }

        [Given("Preencho todos os campos obrigatórios com as informações")]
        public void GivenPreenchoTodosOsCamposObrigatoriosComAsInformacoes(Table table)
        {
            var candidato = table.CreateInstance<CandidatoModel>();
            CadastroPage.PreencheFormulario(candidato);
        }

        [When("Clico em Avançar Cadastro")]
        public void WhenClicoEmAvancarCadastro()
        {
            CadastroPage.BotaoAvancar.Click();
        }

        [Then("Sou redirecionado para tela de cadastro com sucesso")]
        public void ThenSouRedirecionadoParaTelaDeCadastroComSucesso()
        {
            string textoEsperado = "Sua jornada começa aqui!";
            string textoObtido = CadastroPage.RetornaTextoElemento(CadastroPage.TextoSucessoCadastro);

            Assert.Equal(textoEsperado, textoObtido);
        }

        [Then("É exibido erro em campos obrigatórios")]
        public void ThenEExibidoErroEmCamposObrigatorios()
        {
            string texto = "Campo obrigatório";
            int numEsperado = 12;
            int numObtido = CadastroPage.RetornaNumElementosPorTexto(texto);

            Assert.Equal(numEsperado, numObtido);
        }
    }
}
