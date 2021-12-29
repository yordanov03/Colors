using Domain.Models;
using System.Collections.Generic;

namespace Domain.Services
{
    public interface IPeopleDataParser
    {
        List<Person> ParseData();
    }
}
