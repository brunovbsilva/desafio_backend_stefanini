using System;

namespace Example.Domain.CityAggregate
{
    public class InvalidUFExceptions : ArgumentException
    {
        public InvalidUFExceptions() : base("CPF must have 2 characters.")
        {
        }
    }
}
