using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using POM.Enums;
using System;
using System.Collections.Generic;

namespace POM.PageObjects
{
    public class WebTablesPage
    {
        readonly IWebDriver driver;
        readonly By table = By.TagName("table");
        readonly By addUserButton = By.CssSelector(".btn.btn-link.pull-right");
        readonly By firstNameTextBox = By.Name("FirstName");
        readonly By lastNameTextBox = By.Name("LastName");
        readonly By usernameTextBox = By.Name("UserName");
        readonly By passwordTextBox = By.Name("Password");
        readonly By roleDropDownList = By.Name("RoleId");
        readonly By emailTextBox = By.Name("Email");
        readonly By cellPhoneTextBox = By.Name("Mobilephone");
        readonly By saveButton = By.CssSelector(".btn.btn-success");
        readonly WebDriverWait wait;

        public WebTablesPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void GoToPage()
        {
            driver.Navigate().GoToUrl("http://www.way2automation.com/angularjs-protractor/webtables/");
        }

        public IWebElement GetUserTable()
        {
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(table));
        }

        private void ClickAddUser()
        {
            driver.FindElement(addUserButton).Click();
            ClearAddUserForm();
        }

        public void FillAddUserForm(User user, string password, CustomerEnum customer, RoleEnum role)
        {
            ClickAddUser();

            driver.FindElement(firstNameTextBox).SendKeys(user.FirstName);
            driver.FindElement(lastNameTextBox).SendKeys(user.LastName);
            driver.FindElement(usernameTextBox).SendKeys(user.Username);
            driver.FindElement(passwordTextBox).SendKeys(password);
            driver.FindElement(By.CssSelector($"input[value='{(int)customer}']")).Click();
            var roleDropDown = driver.FindElement(roleDropDownList);
            var roles = new SelectElement(roleDropDown);
            roles.SelectByValue(((int)role).ToString());
            driver.FindElement(emailTextBox).SendKeys(user.Email);
            driver.FindElement(cellPhoneTextBox).SendKeys(user.CellPhone);
            driver.FindElement(saveButton).Click();
        }

        public User GetUserByUsername(string username)
        {
            User user = new User();
            IReadOnlyList<IWebElement> tableRows = driver.FindElement(table).FindElements(By.TagName("tr"));
            for (int i = 0; i < tableRows.Count; i++)
            {
                var cells = tableRows[i].FindElements(By.XPath($"//table/tbody/tr[{i}]/td"));
                if (cells.Count > 0)
                {
                    if (cells[2].Text.Equals(username))
                    {
                        return new User
                        {
                            FirstName = cells[0].Text,
                            LastName = cells[1].Text,
                            Username = cells[2].Text,
                            Customer = cells[3].Text,
                            Role = cells[5].Text,
                            Email = cells[6].Text,
                            CellPhone = cells[7].Text
                        };
                    }
                }
            }
            return user;
        }

        private void ClearAddUserForm()
        {
            driver.SwitchTo().ActiveElement();
            driver.FindElement(firstNameTextBox).Clear();
            driver.FindElement(lastNameTextBox).Clear();
            driver.FindElement(usernameTextBox).Clear();
            driver.FindElement(passwordTextBox).Clear();
            var roleDropDown = driver.FindElement(roleDropDownList);
            var roles = new SelectElement(roleDropDown);
            roles.SelectByText("---");
            driver.FindElement(emailTextBox).Clear();
            driver.FindElement(cellPhoneTextBox).Clear();
        }
    }
}
