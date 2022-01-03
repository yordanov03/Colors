using Domain.Models;
using FakeItEasy;
using System;

namespace Tests.Fakes
{
    public class ColorFakes : IDummyFactory
    {
        public Priority Priority => Priority.Default;

        public bool CanCreate(Type type) => type == typeof(Color);

        public object Create(Type type)
        => new Color("blau");
    }
}
