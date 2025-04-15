using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;


namespace CadastroAlunoTest.Pages
{
    public class CadastroPage(IWebDriver driver)
    {
        private WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        public IWebElement TextoInicial => wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"app\"]/main/section/div/div[1]/h3")));

        public string RetornaTextoElemento(IWebElement element) => element.Text.Trim();

    }
}
