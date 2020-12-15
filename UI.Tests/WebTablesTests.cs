using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Common.Utilities.Converters;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using POM.Enums;
using POM.PageObjects;
using System;
using System.IO;

namespace UI.Tests
{
    public class Tests
    {

        [OneTimeSetUp]
        public void Initialize()
        {
            extent = new ExtentReports();
            extent.AttachReporter(new ExtentHtmlReporter(Path.Combine(Directory.GetCurrentDirectory(), @"ExtentReports\")));
        }

        private IWebDriver driver;
        WebTablesPage page;
        private User expectedFirstUser;
        private User expectedSecondUser;
        private ExtentReports extent;

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
            extent.CreateTest(TestContext.CurrentContext.Test.Name).Log(StatusConverter.Convert((int)TestContext.CurrentContext.Result.Outcome.Status), TestContext.CurrentContext.Result.Message);
            extent.Flush();
            driver.Quit();
        }
    }
}