using Domain.Models;
using FakeItEasy;
using System;

namespace Tests.Fakes
{
    public class PersonFakes : IDummyFactory
    {
        public Priority Priority => Priority.Default;

        public bool CanCreate(Type type) => type == typeof(Person);


        public object Create(Type type)
            => new Person(
                "John",
                "Smith",
                "12045",
                "Berlin",
<<<<<<< HEAD
                2);
=======
                 2);
>>>>>>> development
    }
}
