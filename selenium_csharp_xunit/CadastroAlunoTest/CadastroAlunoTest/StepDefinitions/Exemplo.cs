using CadastroAlunoTest.Pages;
using OpenQA.Selenium;

namespace CadastroAlunoTest.StepDefinitions
{
    [Binding]
    public class Exemplo
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;

        public Exemplo(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<IWebDriver>();
        }

        private SelecaoCursoPage selecaoCursoPage;
        private SelecaoCursoPage AutenticacaoPage => selecaoCursoPage ??= new SelecaoCursoPage(_driver);

        [Given("que o usuário acessa o sistema {string}")]
        public void GivenQueOUsuarioAcessaOSistema(string url)
        {
            //_driver.Navigate().GoToUrl(url);
            Console.WriteLine("Estou aqui");
            Thread.Sleep(15000);
            //AutenticacaoPage.SetUsername("abacate");
        }

        [When("solicita para realizar o login informando seus dados de autenticação")]
        public void WhenSolicitaParaRealizarOLoginInformandoSeusDadosDeAutenticacao(DataTable dataTable)
        {
            Console.WriteLine("Estou aqui aqui");
        }

        [Then("acessa o sistema {string}")]
        public void ThenAcessaOSistema(string system)
        { Console.WriteLine("Estou aqui aqui aqui");
            //systemFound.Should().Be(system);
        }
    }
}
