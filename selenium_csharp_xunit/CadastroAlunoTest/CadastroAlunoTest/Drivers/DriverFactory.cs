using CadastroAlunoTest.Support;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;

namespace CadastroAlunoTest.Drivers;
public class DriverFactory

{
    public static IConfigurationRoot Configuration { get; set; }

    protected DriverFactory() { }

    public static IWebDriver GetDriver()
    {
        var directoryDefaultProject = Environment.CurrentDirectory;
        Console.WriteLine("DIRETORIO: " + directoryDefaultProject);
        Configuration = GetAppSettingsConfig.Configuration;
        GetAppSettingsConfig.Initialize(directoryDefaultProject);

        string? browser = Configuration != null
            ? Configuration["driverSettings:browser"]
            : throw new Exception("Não foi possível ler o appsettings. Verifique.");

        string? baseUrl = Configuration != null
            ? Configuration["driverSettings:baseUrl"]
            : throw new Exception("Não foi possível ler o appsettings. Verifique.");

        string? environment = Configuration != null
            ? Configuration["driverSettings:environment"]
            : throw new Exception("Não foi possível ler o appsettings. Verifique.");

        string? gridUri = Configuration != null
           ? Configuration["driverSettings:gridUri"]
           : throw new Exception("Não foi possível ler o appsettings. Verifique.");


        if (environment == "local")
        {
            if (browser != null)
            {
                IWebDriver driver = browser.ToUpper() switch
                {
                    "CHROME" => new ChromeDriver(),
                    "EDGE" => new EdgeDriver(),
                    "FIREFOX" => new FirefoxDriver(),
                    _ => throw new Exception($"The browser '{browser}' is not implemented. Please check.")
                };

                if (!string.IsNullOrEmpty(baseUrl))
                {
                    driver.Navigate().GoToUrl(baseUrl);
                }

                return driver;
            }
        }
        else
        {
            if (browser != null)
            {
                IWebDriver driver = browser.ToUpper() switch
                {
                    "CHROME" => new RemoteWebDriver(new System.Uri(gridUri), new ChromeOptions()),
                    "EDGE" => new RemoteWebDriver(new System.Uri(gridUri), new EdgeOptions()),
                    "FIREFOX" => new RemoteWebDriver(new System.Uri(gridUri), new FirefoxOptions()),
                    _ => throw new Exception($"The browser '{browser}' is not implemented. Please check.")
                };

                if (!string.IsNullOrEmpty(baseUrl))
                {
                    driver.Navigate().GoToUrl(baseUrl);
                }

                return driver;
            }
        }


        throw new Exception("O valor do browser é nulo. Verifique suas configurações.");
    }
}
