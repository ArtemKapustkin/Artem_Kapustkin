using System.Collections.ObjectModel;

namespace Selenium
{
    public class AdminPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        private readonly By _adminButton = By.XPath("//a[@class=\"oxd-main-menu-item\" and contains(@href, \"/admin/viewAdminModule\")]");
        private readonly By _jobDropDownMenu = By.XPath("//li[@class=\"oxd-topbar-body-nav-tab --parent\" and contains(span/text(), \"Job\")]");
        private readonly By _jobTitlesButton = By.XPath("/html/body/div/div[1]/div[1]/header/div[2]/nav/ul/li[2]/ul/li[1]/a");
        private readonly By _jobTitleAddButton = By.XPath("/html/body/div/div[1]/div[2]/div[2]/div/div/div[1]/div/button");

        private readonly By _jobTitleField = By.XPath("/html/body/div/div[1]/div[2]/div[2]/div/div/form/div[1]/div/div[2]/input");
        private readonly By _jobTitleDescriptionField = By.XPath("/html/body/div/div[1]/div[2]/div[2]/div/div/form/div[2]/div/div[2]/textarea");
        private readonly By _jobTitleNoteField = By.XPath("/html/body/div/div[1]/div[2]/div[2]/div/div/form/div[4]/div/div[2]/textarea");
        private readonly By _jobTitleSaveButton = By.XPath("/html/body/div/div[1]/div[2]/div[2]/div/div/form/div[5]/button[2]");

        private readonly By _deleteJobTitle = By.XPath(".//i[@class=\"oxd-icon bi-trash\"]/ancestor::button");
        private readonly By _deleteConfirmButton = By.XPath("/html/body/div/div[3]/div/div/div/div[3]/button[2]");

        public AdminPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        public void ClickOnAdminButton()
        {
            IWebElement adminButton = _wait.Until(_driver => _driver.FindElement(_adminButton));
            adminButton.Click();
        }
        public void ClickOnJobDropBackMenu()
        {
            IWebElement jobDropDownMenu = _wait.Until(_driver => _driver.FindElement(_jobDropDownMenu));
            jobDropDownMenu.Click();

        }
        public void ClickOnJobTitleButton()
        {
            IWebElement jobTitlesButton = _wait.Until(_driver => _driver.FindElement(_jobTitlesButton));
            jobTitlesButton.Click();
        }

        public void ClickOnJobAddTitleButton()
        {
            IWebElement addJobTitleButton = _wait.Until(_driver => _driver.FindElement(_jobTitleAddButton));
            addJobTitleButton.Click();
        }
        public void WriteToTitleField(string title)
        {
            IWebElement jobTitleField = _wait.Until(_driver => _driver.FindElement(_jobTitleField));
            jobTitleField.SendKeys(title);
        }
        public void WriteToDescriptionField(string description)
        {
            IWebElement jobTitleDescription = _wait.Until(_driver => _driver.FindElement(_jobTitleDescriptionField));
            jobTitleDescription.SendKeys(description);
        }
        public void WriteToNoteField(string note)
        {
            IWebElement jobTitleNote = _wait.Until(_driver => _driver.FindElement(_jobTitleNoteField));
            jobTitleNote.SendKeys(note);
        }
        public void ClickOnSaveJobTitleButton()
        {
            IWebElement jobTitleSave = _wait.Until(_driver => _driver.FindElement(_jobTitleSaveButton));
            jobTitleSave.Click();
        }
        public ReadOnlyCollection<IWebElement> FindJobTitle(string title)
        {
            string jobTitleRowXPath = $"//div[contains(text(), '{title}')]/ancestor::div[@class='oxd-table-card']";
            List<IWebElement> elements = new List<IWebElement>();
            try
            {
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
                wait.Until(driver =>
                {
                    elements = driver.FindElements(By.XPath(jobTitleRowXPath)).ToList();
                    return elements.Count > 0;
                });
            }
            catch (WebDriverTimeoutException)
            {
                return new ReadOnlyCollection<IWebElement>(new List<IWebElement>());
            }
            var filteredCollection = elements.Where(row => row.Text.Contains(title)).ToList();
            return new ReadOnlyCollection<IWebElement>(filteredCollection);
        }

        public void DeleteJobTitle(ReadOnlyCollection<IWebElement> collection)
        {
            var deleteJobTitle = collection[0].FindElement(_deleteJobTitle);
            deleteJobTitle.Click();
            var deleteConfirmButton = _wait.Until(_driver => _driver.FindElement(_deleteConfirmButton));
            deleteConfirmButton.Click();
        }
    }
}
