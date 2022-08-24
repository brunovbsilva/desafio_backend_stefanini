namespace Example.Application.PersonService.Models.Dtos
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public int IdCity { get; set; }
        public int Age { get; set; }

        public static explicit operator PersonDto(Domain.PersonAggregate.Person v)
        {
            return new PersonDto()
            {
                Id = v.Id,
                Name = v.Name,
                CPF = v.CPF,
                IdCity = v.IdCity,
                Age = v.Age,
            };
        }
    }
}
