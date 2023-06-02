namespace Selenium
{
    public class LoginPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        private readonly By _usernameField = By.XPath("//input[@name='username']");
        private readonly By _passwordField = By.XPath("//input[@name='password']");
        private readonly By _loginButton = By.XPath("//button[@type='submit']");

        public LoginPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        public void WriteToUsernameField(string username)
        {
            IWebElement usernameField = _wait.Until(driver => driver.FindElement(_usernameField));
            usernameField.SendKeys(username);
        }
        public void WriteToPasswordField(string password)
        {
            IWebElement passwordField = _wait.Until(driver => driver.FindElement(_passwordField));
            passwordField.SendKeys(password);
        }
        public void SignIn()
        {
            IWebElement signInButton = _wait.Until(driver => driver.FindElement(_loginButton));
            signInButton.Click();
        }

    }
}
