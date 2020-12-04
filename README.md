# CIBDigitalTechAutomationAssessment

## COMMON PREREQUISITES FOR DOG API AND UI TESTS:
Tool:
1. Visual Studio 2019

Nuget Packages:
1. Microsoft.NET.Test.Sdk
2. NUnit 
3. NUnit3TestAdapter
4. FluentAssertions
5. NUnit.Allure

## PREREQUISITES FOR UI TESTS:
Tools:
1. Chrome Browser

Nuget Package:
1. Selenium.WebDriver
2. Selenium.WebDriver.ChromeDriver

## STEPS TO INSTALL ALLURE BEFORE RUNNING TESTS
1. Download the latest version as zip archive from Maven Central.
2. Unpack the archive to allure-commandline directory.
3. Navigate to bin directory.
4. Use allure.bat for Windows or allure for other Unix platforms.
5. Add allure to system PATH.

### TEST EXECUTION:

# To execute tests, you need to:

1. Browse to the CIBDigitalTechAutomationAssessment folder in the cloned repo location
2. Copy the **DogApiTestData.csv** file to a bin folder from the Dog.API.Tests project
2. Click on **.sln** file to launch project in Visual Studio
3. Click on View tab in the top Menu
4. Click on Solution Explorer
5. Right-click on the test case in the test explorer, then select **Run Test(s)**. 

## HOW TO GENERATE AND VIEW REPORT FOR TEST RUN RESULTS?

1. Open Command Prompt
2. Run this command **allure serve "allure-results-directory"** e.g.
    a. To view a report for Dog API Tests **allure serve C:\Users\DarthVader\source\repos\AutomationAssessment\Dog.API.Tests\bin\Debug\netcoreapp3.1\allure-results**
    b. To view a report for UI Tests **allure serve C:\Users\DarthVader\source\repos\AutomationAssessment\UI.Tests\bin\Debug\netcoreapp3.1\allure-results**
3. The report will be opened in a default browser (preferably Chrome)