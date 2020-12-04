using Dog.API.Models;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Dog.API.Tests
{
    [AllureNUnit]
    [AllureSuite("Dog.Api.Tests")]
    public class Tests
    {
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
    }
}