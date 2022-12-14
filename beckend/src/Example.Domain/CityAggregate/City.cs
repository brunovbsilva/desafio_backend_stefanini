namespace Example.Domain.CityAggregate
{
    public sealed class City
    {
        public City(){}

        private City(string name, string uf)
        {
            this.Name = name;
            this.UF = uf;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string UF { get; set; }



        public static City Create(string name, string uf)
        {
            if (name == null)
                throw new ArgumentException("Invalid " + nameof(name));

            if (uf == null)
                throw new ArgumentException("Invalid " + nameof(uf));
            else if (uf.Length != 2)
                throw new InvalidUFExceptions();


            return new City(name, uf);
        }

        public void Update(string name, string uf)
        {
            if (name != null)
                Name = name;

            if (uf != null)
            {
                if(uf.Length == 2)
                    UF = uf;
                else
                    throw new InvalidUFExceptions();
            }
                
        }
    }
}
