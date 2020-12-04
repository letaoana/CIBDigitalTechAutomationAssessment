using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace Dog.API.Tests
{
    public class TestData
    {
        public static List<TestCaseData> GetTestCases()
        {
            var testCases = new List<TestCaseData>();
            using (var fileStream = File.OpenRead(Path.Combine(Environment.CurrentDirectory, "DogApiTestData.csv")))
            using (var streamReader = new StreamReader(fileStream))
            {
                string line = string.Empty;
                while (line != null)
                {
                    line = streamReader.ReadLine();
                    if (line != null)
                    {
                        string[] split = line.Split(new char[] { ';' },
                            StringSplitOptions.None);

                        string breed = split[0];
                        string subBreed = split[1];

                        var testCase = new NUnit.Framework.TestCaseData(breed, subBreed);
                        testCases.Add(testCase);
                    }
                }
            }

            return testCases;
        }
    }
}
