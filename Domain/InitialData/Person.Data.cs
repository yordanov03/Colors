using Domain.Common;
using Domain.Models;
using Domain.Services;
using System;
using System.Collections.Generic;

namespace Domain.InitialData
{
    internal class PersonData : IInitialData
    {
        private readonly IPeopleDataParser _peopleDataParser;

        public PersonData(IPeopleDataParser peopleDataParser)
        {
            this._peopleDataParser = peopleDataParser;
        }
        public Type EntityType => typeof(Person);

        public IEnumerable<object> GetData()
        => this._peopleDataParser.ParseData();
    }
}
