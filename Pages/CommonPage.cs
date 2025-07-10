using OpenQA.Selenium;

namespace Pages
{
    public class CommonPage
    {
        protected IWebDriver driver;

        // Mapeamento dos Elementos comuns a duas ou mais páginas
        private IWebElement lblTituloSecao => driver.FindElement(By.CssSelector("span.title"));
        private IWebElement icoCarrinho => driver.FindElement(By.CssSelector("a.shopping_cart_link")); // o a. indica que é o link (<a class="shopping_cart_link" data-test="shopping-cart-link"></a>)

        // Métodos e Funções
        // Construtor
        public CommonPage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}

// declaramos o driver (selenium) no commonpage, para que as outras POs usem