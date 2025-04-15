using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using CadastroAlunoTest.Models;
using System.Collections.ObjectModel;


namespace CadastroAlunoTest.Pages
{
    public class CadastroPage(IWebDriver driver)
    {
        private WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
        public IWebElement TextoInicial => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"app\"]/main/section/div/div[1]/h3")));
        public IWebElement InputCPF => wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("input[data-testid=\"cpf-input\"]")));
        public IWebElement InputNome => wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("input[data-testid=\"name-input\"]")));
        public IWebElement InputSobrenome => wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("input[data-testid=\"surname-input\"]")));
        public IWebElement InputDia => wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("div[data-radix-vue-date-field-segment=\"day\"]")));
        public IWebElement InputMes => wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("div[data-radix-vue-date-field-segment=\"month\"]")));
        public IWebElement InputAno => wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("div[data-radix-vue-date-field-segment=\"year\"]")));
        public IWebElement InputEmail => wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("input[data-testid=\"email-input\"]")));
        public IWebElement InputCelular => wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("input[data-testid=\"cellphone-input\"]")));
        public IWebElement InputCEP => wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("input[data-testid=\"cep-input\"]")));
        public IWebElement InputEndereco => wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("input[data-testid=\"address-input\"]")));
        public IWebElement InputBairro => wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("input[data-testid=\"neighborhood-input\"]")));
        public IWebElement InputCidade => wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("input[data-testid=\"city-input\"]")));
        public IWebElement InputEstado => wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("input[data-testid=\"state-input\"]")));

        public IWebElement InputPais => wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("input[data-testid=\"country-input\"]")));
        public IWebElement BotaoAvancar => wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button[data-testid=\"next-button\"]")));
        public IWebElement BotaoAcessaAreaCandidato => wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button[data-testid=\"next-button\"]")));
        public IWebElement TextoSucessoCadastro => wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#app > main > section  h3")));

        public string RetornaTextoElemento(IWebElement element) => element.Text.Trim();

        public void PreencheFormulario(CandidatoModel candidato)
        {
            InputCPF.SendKeys(candidato.cpf);
            InputNome.SendKeys(candidato.nome);
            InputSobrenome.SendKeys(candidato.sobrenome);

            string[] dataNascimento = candidato.dataNascimento.Split("/");
            InputDia.SendKeys(dataNascimento[0]);
            InputMes.SendKeys(dataNascimento[1]);
            InputAno.SendKeys(dataNascimento[2]);

            InputEmail.SendKeys(candidato.email);
            InputCelular.SendKeys(candidato.celular);
            InputCEP.SendKeys(candidato.cep);
            InputEndereco.SendKeys(candidato.endereco);
            InputBairro.SendKeys(candidato.bairro);
            InputCidade.SendKeys(candidato.cidade);
            InputEstado.SendKeys(candidato.estado);
            InputPais.SendKeys(candidato.pais);            
        } 

        public int RetornaNumElementosPorTexto(string texto)
        {
            ReadOnlyCollection<IWebElement> elements = driver.FindElements(By.XPath($"//*[contains(text(), '{texto}')]"));
            return elements.Count;
        }

        public void NavegaAteLogin(CandidatoModel candidato)
        {
            PreencheFormulario(candidato);
            BotaoAvancar.Click();
            BotaoAcessaAreaCandidato.Click();
        }
    }
}
