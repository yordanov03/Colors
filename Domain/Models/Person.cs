using Colors.Domain.Common;

namespace Domain.Models
{
    public class Person : Entity<int>, IAggregateRoot
    {
        public const string PeopleDataSource = "PeopleData";

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Zipcode { get; private set; }
        public string City { get; private set; }
        public int ColorId { get; private set; }

        internal Person(
            string firstName,
            string lastName,
            string zipcode,
            string city,
            int colorId)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Zipcode = zipcode;
            this.City = city;
            this.ColorId = colorId;
        }
    }
}
