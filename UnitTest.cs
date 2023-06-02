namespace Selenium
{
    [TestFixture]
    public class Test
    {
        private IWebDriver _webDriver;
        private WebDriverWait _wait;

        private string _username = "Admin";
        private string _password = "admin123";
        private string _title = "Cleaning Manager";
        private string _description = "Cleaning Managers supervise janitorial operations in a building and coordinate cleaning staff. " +
                    "Common activities these professionals complete are checking if facilities are cleaned correctly, assigning tasks, " +
                    "investigating client complaints, ordering supplies, creating schedules, and training employees.";
        private string _note = "123"; 

        [SetUp]
        public void SetUp()
        {
            _webDriver = WebDriverFactory.CreateChromeDriver();
            _webDriver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
            _wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
        }

        [TearDown]
        public void TearDown()
        {
            _webDriver.Quit();
        }

        [Test]
        public void UnitTest()
        {
            LoginPage loginPage = new LoginPage(_webDriver, _wait);
            loginPage.WriteToUsernameField(_username);
            loginPage.WriteToPasswordField(_password);
            loginPage.SignIn();

            AdminPage adminPage = new AdminPage(_webDriver, _wait);
            adminPage.ClickOnAdminButton();
            adminPage.ClickOnJobDropBackMenu();
            adminPage.ClickOnJobTitleButton();
            adminPage.ClickOnJobAddTitleButton();
            
            adminPage.WriteToTitleField(_title);
            adminPage.WriteToDescriptionField(_description);
            adminPage.WriteToNoteField(_note);
            adminPage.ClickOnSaveJobTitleButton();

            var collection = adminPage.FindJobTitle(_title);
            if (collection.Count > 0)
            {
                Console.WriteLine(collection[0]);
                Console.WriteLine("There is {0} in collection", _title);
                adminPage.DeleteJobTitle(collection);
                var collectionAfterDeletion = adminPage.FindJobTitle(_title);
                if (collectionAfterDeletion.Count == 0)
                    Assert.Pass();
                else
                    Assert.Fail();
            }
            else
            {
                Console.WriteLine("There is no {0} in collection", _title);
                Assert.Fail();
            }
        }
    }
}