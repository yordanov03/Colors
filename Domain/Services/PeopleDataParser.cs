using Domain.Factories.PersonFactory;
using Domain.Models;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using static Colors.Domain.Common.ModelConstants;

namespace Domain.Services
{
    public class PeopleDataParser : IPeopleDataParser
    {
        private readonly FileLocation _fileLocation;
        private readonly IPersonFactory _personFactory;

        public PeopleDataParser(
            IOptions<FileLocation> options,
            IPersonFactory personFactory)
        {
            this._fileLocation = options.Value;
            this._personFactory = personFactory;
        }

        public List<Person> ParseData()
        {
            var dataFromFile = File.ReadAllLines(_fileLocation.PeopleData);

            var concatenatedLines = ConcatenatedLines(dataFromFile);

            var parsedPeopleData = Parsepeople(PeopleInputRegexPattern, concatenatedLines);

            return parsedPeopleData;
        }

        private List<Person> Parsepeople(string pattern, List<string> concatenatedLines)
        {
            var people = new List<Person>();

            foreach (var line in concatenatedLines)
            {
                var matched = Regex.Match(line, pattern);
                var person = this._personFactory
                    .WithFirstName(matched.Groups[2].Value)
                    .WithLastName(matched.Groups[1].Value)
                    .WithZipcode(matched.Groups[3].Value)
                    .WithCity(matched.Groups[4].Value)
                    .WithColorId(int.Parse(matched.Groups[5].Value))
                    .Build();

                people.Add(person);
            }

            return people;
        }

        private static List<string> ConcatenatedLines(string[] readData)
        {
            var concatenatedLines = new List<string>();
            for (int i = 0; i < readData.Length; i++)
            {
                if (i < readData.Length - 2)
                {
                    if (readData[i].EndsWith(", "))
                    {
                        readData[i] = readData[i] + readData[i + 1];
                        concatenatedLines.Add(readData[i]);
                        i++;
                    }
                    else
                    {
                        concatenatedLines.Add(readData[i]);
                    }
                }
                else
                {
                    concatenatedLines.Add(readData[i]);
                }
            }
            return concatenatedLines;
        }
    }
}
