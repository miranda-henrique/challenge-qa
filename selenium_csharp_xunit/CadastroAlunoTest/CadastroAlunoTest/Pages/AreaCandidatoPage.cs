using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;


namespace CadastroAlunoTest.Pages
{
    public class AreaCandidatoPage(IWebDriver driver)
    {
        private WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
        public IWebElement TextoAreaCandidato => wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#app > main > div  a > span")));

        public string RetornaTextoElemento(IWebElement element) => element.Text.Trim();

        public int RetornaNumElementosPorTexto(string texto)
        {
            ReadOnlyCollection<IWebElement> elements = driver.FindElements(By.XPath($"//*[contains(text(), '{texto}')]"));
            return elements.Count;
        }
    }
}
