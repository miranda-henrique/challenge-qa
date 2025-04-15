using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;


namespace CadastroAlunoTest.Pages
{
    public class LoginPage(IWebDriver driver)
    {
        private WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
        public IWebElement InputUsuario => wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("input[data-testid=\"username-input\"]")));
        public IWebElement InputSenha => wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("password")));
        public IWebElement BotaoLogin => wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button[data-testid=\"login-button\"]")));
        public IWebElement TextoSenhaInvalida => wait.Until(ExpectedConditions.ElementIsVisible(By.Id("radix-94-form-item-message")));
        
        public string RetornaTextoElemento(IWebElement element) => element.Text.Trim();

        public int RetornaNumElementosPorTexto(string texto)
        {
            ReadOnlyCollection<IWebElement> elements = driver.FindElements(By.XPath($"//*[contains(text(), '{texto}')]"));
            return elements.Count;
        }
    }
}
