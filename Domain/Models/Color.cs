using Colors.Domain.Common;

namespace Domain.Models
{
    public class Color : Entity<int>, IAggregateRoot
    {
        public string Name { get; }

        public Color(string name)
        {
            this.Name = name;
        }
    }
}
