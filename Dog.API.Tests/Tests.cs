using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Common.Utilities.Converters;
using Dog.API.Models;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Dog.API.Tests
{
    public class Tests
    {
        private ExtentReports extent;

        [OneTimeSetUp]
        public void Initialize()
        {
            extent = new ExtentReports();
            extent.AttachReporter(new ExtentHtmlReporter(Path.Combine(Directory.GetCurrentDirectory(), @"ExtentReports\")));
        }

        [TestCaseSource(typeof(TestData), nameof(TestData.GetTestCases))]
        public async Task GIVEN_ListAllSubBreedsEndPoint_WHEN_SendingRequest_THEN_ShouldReturnListOfSubBreedsForABreed(string breed, string subBreed)
        {
            DogApi dogApi = new DogApi();

            JsonConvert.DeserializeObject<Breed>(await dogApi.GetAllBreeds()).Message.Keys.Should().Contain(breed);
            JsonConvert.DeserializeObject<SubBreed>(await dogApi.GetByBreed(breed)).Message.Should().NotBeNullOrEmpty();
            JsonConvert.DeserializeObject<IDictionary<string, Uri>>(await dogApi.GetSingleRandomImage(breed, subBreed)).TryGetValue("message", out Uri actualImageLink);
            var match = Regex.Match(actualImageLink.ToString(), "^https?://.*", RegexOptions.IgnoreCase);
            Assert.IsTrue(match.Success);
        }

        [TearDown]
        public void CleanUp()
        {
            extent.CreateTest(TestContext.CurrentContext.Test.Name).Log(StatusConverter.Convert((int)TestContext.CurrentContext.Result.Outcome.Status), TestContext.CurrentContext.Result.Message);
            extent.Flush();
        }
    }
}