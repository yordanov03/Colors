using Domain.Exceptions;
using FakeItEasy;
using FluentAssertions;
using System;
using Xunit;
using Domain.Models;
using Domain.Factories.PersonFactory;

namespace Tests.Specs
{
    public class PersonSpecs
    {

        [Fact]
        public void CreatePersonWithValidInput()
        {
            //Act
            Action person = ()=> A.Dummy<Person>();

            //Assert
            person.Should().NotThrow<InvalidPersonException>();
        }

        [Fact]
        public void CretePersonThrowsExceptionWhenFirstNameEmpty()
        {
            //Arrange
            var exception = Record.Exception(()=> new Person("", "Smith", "12045", "Berlin", 3));

            //Assert
            Assert.NotNull(exception);
        }

        [Fact]
        public void CretePersonThrowsExceptionWhenLastNameTooLong()
        {
            //Arrange
            var exception = Record.Exception(() => new Person("George", "Thislastnameisgoingtobetoolong", "12045", "Berlin", 3));

            //Assert
            Assert.NotNull(exception);
        }

        [Fact]
        public void CretePersonThrowsExceptionWhenZipCodeContainsLetters()
        {
            //Arrange
            var exception = Record.Exception(() => new Person("George", "Smith", "1204a", "Bonn", 3));

            //Assert
            Assert.NotNull(exception);
        }

        [Fact]
        public void CretePersonThrowsExceptionWhenCityNameTooShort()
        {
            //Arrange
            var exception = Record.Exception(() => new Person("George", "Smith", "12045", "Na", 3));

            //Assert
            Assert.NotNull(exception);
        }
    }
}
