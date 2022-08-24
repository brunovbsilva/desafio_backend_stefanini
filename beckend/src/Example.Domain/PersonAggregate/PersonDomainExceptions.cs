using System;

namespace Example.Domain.PersonAggregate
{
    public class InvalidAgeExceptions : ArgumentException
    {
        public InvalidAgeExceptions() : base("A person cannot have a negative age.")
        {
        }
    }

    public class InvalidCityExceptions : ArgumentException
    {
        public InvalidCityExceptions() : base("IdCity must be positive.")
        {
        }
    }

    public class InvalidCPFExceptions : ArgumentException
    {
        public InvalidCPFExceptions() : base("CPF must have 11 digits.")
        {
        }
    }
}
