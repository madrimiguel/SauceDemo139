using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V135.Runtime;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace MyNamespace
{
    [Binding]
    public class StepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver driver; // objeto do Selenium

        public StepDefinitions(ScenarioContext scenarioContext)
        {
            
        }

        [BeforeScenario] // o before serve pra apontar o momento da execução. fazer antes do cenário, antes da feature, etc.
        public void SetUp()
        {
            new DriverManager().SetUpDriver(new ChromeConfig()); // instanciando o Chrome Driver através do WebDrivermanager
            driver = new ChromeDriver(); // instanciou o Selenium no Chrome
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(10000); // espera 
            driver.Manage().Window.Maximize();
        }

        [AfterScenario]
        public void TearDown()
        {
            driver.Quit(); // encerra o selenium
        }

        [Given(@"que acesso a página inicial do site")]
        public void DadoQueAcessoAPaginaInicialDoSite()
        {
           driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        [When(@"preencho o usuário ""(.*)""")] // ""(.*)""" é um extrator, ele tira o conteúdo do que está entre aspas.
                                               // por exemplo, "standarduser" em "preencho o usuário "standard_user""
                                            // isso é útil porque se precisar alterar algum dado, é só ir direto no .feature
        public void QuandoPreenchoOUsuario(string username)
        {
            driver.FindElement(By.Id("user-name")).SendKeys(username);
        }

        [When(@"a senha ""(.*)"" e clico no botao Login")]
        public void QuandoASenhaEClicoNoBotaoLogin(string password)
        {
            driver.FindElement(By.Id("password")).SendKeys(password);
            driver.FindElement(By.Id("login-button")).Click();
        }

        [When(@"adiciono o produto ""(.*)"" ao carrinho")]
        public void QuandoAdicionoOProdutoAoCarrinho(string product)
        {
            String productSelector = "add-to-cart-" + product.ToLower().Replace(" ", "-");
            Console.WriteLine($"Seletor de Produto = {productSelector}");
            driver.FindElement(By.Id(productSelector)).Click();
            // nesse caso está sendo necessário adicionar um id dinâmico, pois cada produto tem um botão
            // id da mochila: add-to-cart-sauce-labs-backpack, id da lanterna: add-to-cart-sauce-labs-bike-light
            // além disso, o texto no feature está com maisculas e o id em minusculas e hifens (product.ToLower(); o replace é para trocar o espaço por -)
        }

        [When(@"clico no icone do carrinho de compras")]
        public void QuandoClicoNoIconeDoCarrinhoDeCompras()
        {
            driver.FindElement(By.Id("shopping_cart_container")).Click();
        }

        [Then(@"exibe ""(.*)"" no titulo da secao")]
        public void EntaoExibeNoTituloDaSecao(string title)
        {
            Assert.That(driver.FindElement(By.CssSelector("span.title")).Text, Is.EqualTo(title));
        }

        [Then(@"exibe a pagina do carrinho com a quantidade como ""(.*)""")]
        public void EntaoExibeAPaginaDoCarrinhoComAQuantidadeComo(string quantity)
        {
            Assert.That(driver.FindElement(By.CssSelector("div.cart_quantity")).Text, Is.EqualTo(quantity));
       }

        [Then(@"nome do produto ""(.*)""")]
        public void EntaoNomeDoProduto(string product)
        {
            Assert.That(driver.FindElement(By.CssSelector("div.inventory_item_name")).Text, Is.EqualTo(product));
        }

        [Then(@"o preco como ""(.*)""")]
        public void EntaoOPrecoComo(string price)
        {
            Assert.That(driver.FindElement(By.CssSelector("div.inventory_item_price")).Text, Is.EqualTo(price));
        }
    }
}