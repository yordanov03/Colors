using Colors.Domain.Exceptions;

namespace Domain.Exceptions
{
    public class InvalidPersonException : BaseDomainException
    {
        public InvalidPersonException() { }

        public InvalidPersonException(string message) => this.Message = message;

    }
}
