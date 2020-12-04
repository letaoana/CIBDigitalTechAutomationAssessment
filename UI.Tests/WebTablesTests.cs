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
        private User firstUser;
        private User secondUser;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            page = new WebTablesPage(driver);
            firstUser = new User("FName1", "LName1", Guid.NewGuid().ToString().Replace("-", ""), string.Empty, "Admin", "admin@mail.com", "082555");
            secondUser = new User("FName2", "LName2", Guid.NewGuid().ToString().Replace("-", ""), string.Empty, "Customer", "cusomter@mail.com", "083444");
        }

        [Test]
        public void GIVEN_UserIsOnUserTable_WHEN_UserAdds2NewUsers_THEN_UserListTableShouldHaveDetailsOf2NewUsers()
        {
            page.GoToPage();
            Assert.IsTrue(page.GetUserTable().Displayed);
            page.FillAddUserForm(firstUser, "Pass1", CustomerEnum.CompanyAAA, RoleEnum.Admin);
            page.FillAddUserForm(secondUser, "Pass2", CustomerEnum.CompanyBBB, RoleEnum.Customer);

            var actualFirstAddedUser = page.GetUserByUsername(firstUser.Username);
            var actualSecondAddedUser = page.GetUserByUsername(secondUser.Username);
            actualFirstAddedUser.Should().BeEquivalentTo(firstUser);
            actualSecondAddedUser.Should().BeEquivalentTo(secondUser);
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}