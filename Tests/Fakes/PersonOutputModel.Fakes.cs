using Application.Features.People.Queries.Common;
using FakeItEasy;
using System;

namespace Tests.Fakes
{
    public class PersonOutputModelFakes : IDummyFactory
    {
        public Priority Priority => Priority.Default;

        public bool CanCreate(Type type) => type == typeof(PersonOutputModel);

        public object Create(Type type)
        => new PersonOutputModel
        {
            Id = 1,
            FirstName = "John",
            LastName = "Smith",
            Zipcode = "12345",
            City = "Bonn",
            Color = "blau"
        };

    }
}
