using Example.Domain.CityAggregate;

namespace Example.Domain.PersonAggregate
{
    public sealed class Person
    {
        public Person(){}

        private Person(string name, string cpf, int idCity, int age)
        {
            this.Name = name;
            this.CPF = cpf;
            this.IdCity = idCity;
            this.Age = age;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public int IdCity { get; set; }
        public int Age { get; set; }
        public City City { get; set; }



        public static Person Create(string name, string cpf, int idCity, int age)
        {
            if (name == null)
                throw new ArgumentException("Invalid " + nameof(name));

            if (cpf == null)
                throw new ArgumentException("Invalid " + nameof(cpf));
            else if (cpf.Length != 11)
                throw new InvalidCPFExceptions();

            if (idCity <= 0)
                throw new InvalidCityExceptions();

            if (age < 0)
                throw new InvalidAgeExceptions();


            return new Person(name, cpf, idCity, age);
        }

        public void Update(string name, string cpf, int idCity, int age)
        {
            if (name != null)
                Name = name;

            if (cpf != null)
            {
                if(cpf.Length == 11)
                    CPF = cpf;
                else
                    throw new InvalidCPFExceptions();
            }

            if (idCity > 0)
                IdCity = idCity;
            else
                throw new InvalidCityExceptions();

            if (age >= 0)
                Age = age;
            else
                throw new InvalidAgeExceptions();
        }
    }
}
