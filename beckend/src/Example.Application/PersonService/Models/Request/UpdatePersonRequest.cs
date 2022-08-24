namespace Example.Application.PersonService.Models.Request
{
    public class UpdatePersonRequest
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        public int IdCity { get; set; }
        public int Age { get; set; }
    }
}
