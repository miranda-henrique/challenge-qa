using CadastroAlunoTest.Models;
using CadastroAlunoTest.Pages;
using OpenQA.Selenium;


namespace CadastroAlunoTest.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;

        public LoginStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<IWebDriver>();
        }

        private SelecaoCursoPage selecaoCursoPage;
        private SelecaoCursoPage SelecaoCursoPage => selecaoCursoPage ??= new SelecaoCursoPage(_driver);

        private CadastroPage cadastroPage;
        private CadastroPage CadastroPage => cadastroPage ??= new CadastroPage(_driver);

        private LoginPage loginPage;
        private LoginPage LoginPage => loginPage ??= new LoginPage(_driver);

        private AreaCandidatoPage areaCandidatoPage;
        private AreaCandidatoPage AreaCandidatoPage => areaCandidatoPage ??= new AreaCandidatoPage(_driver);

        [Given("Acesso a página de login")]
        public void GivenAcessoAPaginaDeLogin(Table table)
        {
            var candidato = table.CreateInstance<CandidatoModel>();
            SelecaoCursoPage.NavegaAteCadastro();
            CadastroPage.NavegaAteLogin(candidato);
        }

        [Given("Preencho campo usuário com {string}")]
        public void GivenPreenchoCampoUsuarioCom(string usuario)
        {
            LoginPage.InputUsuario.SendKeys(usuario);
        }

        [Given("Preencho campo senha com {string}")]
        public void GivenPreenchoCampoSenhaCom(string senha)
        {
            LoginPage.InputSenha.SendKeys(senha);
        }

        [When("Clico em Login")]
        public void WhenClicoEmLogin()
        {
            LoginPage.BotaoLogin.Click();
        }

        [Then("Sou redirecionado para a área do candidato")]
        public void ThenSouRedirecionadoParaAAreaDoCandidato()
        {

            string textoEsperado = "Área do candidato";
            string textoObtido = AreaCandidatoPage.RetornaTextoElemento(AreaCandidatoPage.TextoAreaCandidato);

            Assert.Equal(textoEsperado, textoObtido);
        }

        [Then("Recebo mensagem de que campos são obrigatórios")]
        public void ThenReceboMensagemDeQueCamposSaoObrigatorios()
        {
            LoginPage.InputUsuario.Click();

            string textoEsperado = "Senha inválida";
            string textoObtido = LoginPage.RetornaTextoElemento(LoginPage.TextoSenhaInvalida);

            Assert.Equal(textoEsperado, textoObtido);
        }
    }
}
