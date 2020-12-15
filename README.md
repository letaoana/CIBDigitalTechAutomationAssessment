# Automation Assessment

## COMMON PREREQUISITES FOR DOG API AND UI TESTS:
Tool:
1. Visual Studio 2019

Nuget Packages:
1. Microsoft.NET.Test.Sdk
2. NUnit 
3. NUnit3TestAdapter
4. FluentAssertions
5. ExtentReports

## PREREQUISITES FOR UI TESTS:
Tools:
1. Chrome Browser

Nuget Package:
1. Selenium.WebDriver
2. Selenium.WebDriver.ChromeDriver

## TEST EXECUTION:

To execute tests, you need to:

1. Browse to the CIBDigitalTechAutomationAssessment folder in the cloned repo location
2. Copy the **DogApiTestData.csv** file to a bin folder from the Dog.API.Tests project
2. Click on **.sln** file to launch project in Visual Studio
3. Click on View tab in the top Menu
4. Click on Solution Explorer
5. Right-click on the test case in the test explorer, then select **Run Test(s)**

## VIEWING REPORTS FOR TEST RUN RESULTS
1. To view a report for Dog API Tests go to the bin folder of the API Tests project and inside the ExtentReports folder, open the **index.html**.
2. To view a report for UI Tests go to the bin folder of the UI Tests project and inside the ExtentReports folder, open the **index.html**.
