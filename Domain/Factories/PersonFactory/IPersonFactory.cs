using Colors.Domain.Factories;
using Domain.Models;

namespace Domain.Factories.PersonFactory
{
    public interface IPersonFactory : IFactory<Person>
    {
        IPersonFactory WithFirstName(string firstName);
        IPersonFactory WithLastName(string lastName);
        IPersonFactory WithCity(string city);
        IPersonFactory WithZipcode(string zipcode);
        IPersonFactory WithColorId(int colordId);
    }
}
