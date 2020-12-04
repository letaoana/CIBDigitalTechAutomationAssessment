using FluentAssertions;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using POM.Enums;
using POM.PageObjects;
using System;

namespace UI.Tests
{
    [AllureNUnit]
    [AllureSuite("AddUser.UI.Tests")]
    public class Tests
    {
        private IWebDriver driver;
        WebTablesPage page;
        private User expectedFirstUser;
        private User expectedSecondUser;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            page = new WebTablesPage(driver);
            page.GoToPage();
            expectedFirstUser = new User("FName1", "LName1", Guid.NewGuid().ToString().Replace("-", ""), string.Empty, "Admin", "admin@mail.com", "082555");
            expectedSecondUser = new User("FName2", "LName2", Guid.NewGuid().ToString().Replace("-", ""), string.Empty, "Customer", "cusomter@mail.com", "083444");
        }

        [Test]
        public void GIVEN_UserIsOnUserTable_WHEN_UserAdds2NewUsers_THEN_UserListTableShouldHaveDetailsOf2NewUsers()
        {            
            Assert.IsTrue(page.GetUserTable().Displayed);
            page.FillAddUserForm(expectedFirstUser, "Pass1", CustomerEnum.CompanyAAA, RoleEnum.Admin);
            page.FillAddUserForm(expectedSecondUser, "Pass2", CustomerEnum.CompanyBBB, RoleEnum.Customer);

            page.GetUserByUsername(expectedFirstUser.Username).Should().BeEquivalentTo(expectedFirstUser);
            page.GetUserByUsername(expectedSecondUser.Username).Should().BeEquivalentTo(expectedSecondUser);
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}