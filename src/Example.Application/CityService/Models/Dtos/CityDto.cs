namespace Example.Application.CityService.Models.Dtos
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UF { get; set; }

        public static explicit operator CityDto(Domain.CityAggregate.City v)
        {
            return new CityDto()
            {
                Id = v.Id,
                Name = v.Name,
                UF = v.UF
            };
        }
    }
}
