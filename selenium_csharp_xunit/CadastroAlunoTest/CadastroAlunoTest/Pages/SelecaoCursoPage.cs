using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Internal;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace CadastroAlunoTest.Pages
{
    public class SelecaoCursoPage(IWebDriver driver)
    {
        private WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        public IWebElement TextoInicial => wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#app h3")));
        public IWebElement NivelEnsinoDropdown => wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button[data-testid=\"education-level-select\"]")));
        public IWebElement NivelEnsinoSelect => wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#app select")));
        public IWebElement OpcaoGraduacao => wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#radix-vue-select-content-4 > div > div > div:nth-child(3)")));
        public IWebElement OpcaoPosGraduacao => wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#radix-vue-select-content-4 > div > div > div:nth-child(4)")));
        public IWebElement CursosDropdown => wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button[data-testid=\"graduation-combo\"]")));
        public IWebElement CursosInput => wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("input.flex")));
        public IWebElement BotaoAvancar => wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button[data-testid=\"next-button\"]")));
        public IAlert Alert => wait.Until(ExpectedConditions.AlertIsPresent());

        public string RetornaTextoElemento(IWebElement element) => element.Text.Trim();


        public void PreencheSelect(IWebElement elementoSelect, string value) 
        {
            SelectElement select = new SelectElement(elementoSelect);
            select.SelectByValue(value);
        }
        public void SelecionaNivelGraduacao()
        {
            NivelEnsinoDropdown.Click();
            OpcaoGraduacao.Click();
        }

        public void SelecionaNivelPos()
        {
            NivelEnsinoDropdown.Click();
            OpcaoPosGraduacao.Click();
        }

        public void SelecionaCurso(string curso)
        {
            CursosDropdown.Click();
            CursosInput.SendKeys(curso);
            CursosInput.SendKeys(Keys.Enter);

        }
        public void FocaElemento(IWebElement elemento)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView();", elemento);
        }
    }
}
