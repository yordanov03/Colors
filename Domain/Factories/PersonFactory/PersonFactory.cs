using Domain.Models;

namespace Domain.Factories.PersonFactory
{
    public class PersonFactory : IPersonFactory
    {
        private string firstName;
        private string lastName;
        private string zipcode;
        private string city;
        private int colorId;

        public IPersonFactory WithFirstName(string firstName)
        {
            this.firstName = firstName;
            return this;
        }

        public IPersonFactory WithLastName(string lastName)
        {
            this.lastName = lastName;
            return this;
        }

        public IPersonFactory WithZipcode(string zipcode)
        {
            this.zipcode = zipcode;
            return this;
        }
        public IPersonFactory WithCity(string city)
        {
            this.city = city;
            return this;
        }

        public IPersonFactory WithColorId(int colorId)
        {
            this.colorId = colorId;
            return this;
        }

        public Person Build() => new Person
            (firstName,
            lastName,
            zipcode,
            city,
            colorId);
    }
}
