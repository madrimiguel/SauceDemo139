// Bibliotecas

// Namespace
using OpenQA.Selenium;

namespace Pages
{

    // Classe (a estrutura de classes em uma PageObject é esta abaixo)
    public class LoginPage : CommonPage // extendendo a login page com a commonpage. o que uma usar, a outra irá usar também
    {
        // Atributos
        // Mapeamento dos elementos
        private IWebElement txtUsuario => driver.FindElement(By.Id("user-name"));
        private IWebElement txtSenha => driver.FindElement(By.Id("password"));
        private IWebElement btnLogin => driver.FindElement(By.Id("login-button"));

        // Métodos e Funções
        // Construtor
        public LoginPage(IWebDriver driver) : base(driver) { }
        // Ações a serem usadas na automação
        public void PreencherUsuarioESenha(String usuario, String senha) // usando os parâmetros já definidos na feature (usario e senha)
        {
            txtUsuario.SendKeys(usuario);
            txtSenha.SendKeys(senha);
        }

        public void ClicarNoBotaoLogin()
        {
            btnLogin.Click();
        }

        public void DarEnter()
        {
            txtSenha.SendKeys(Keys.Enter);
        }
    }

}