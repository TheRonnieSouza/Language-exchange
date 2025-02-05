namespace LanguageExchange.Core.Entities
{
    public class UserAddress
    {
        public UserAddress(Guid userId, string zipcode, string streetName, string houseNumber,
                           string country, string state, string city,
                           string neighborhood, string complement)
        {
            UserId = userId;
            Zipcode = zipcode;
            StreetName = streetName;
            HouseNumber = houseNumber;
            Country = country;
            State = state;
            City = city;
            Neighborhood = neighborhood;
            Complement = complement;
        }
        public UserAddress(string zipcode, string streetName, string houseNumber,
                           string country, string state, string city,
                           string neighborhood, string complement)
        {
            Zipcode = zipcode;
            StreetName = streetName;
            HouseNumber = houseNumber;
            Country = country;
            State = state;
            City = city;
            Neighborhood = neighborhood;
            Complement = complement;
        }
        public UserAddress() { }
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid UserId { get; private set; }
        public string Zipcode { get; private set; }
        public string StreetName { get; private set; }
        public string HouseNumber { get; private set; }  
        public string Country { get; private set; }
        public string State { get; private set; }
        public string City { get; private set; }
        public string Neighborhood { get; private set; } 
        public string Complement { get; private set; }

        public User User { get; private set; }
        public void UpdateAddress(string zipcode, string streetName, string houseNumber,
                                  string country, string state, string city,
                                  string neighborhood, string complement)
        {           
            Zipcode = zipcode;
            StreetName = streetName;
            HouseNumber = houseNumber;
            Country = country;
            State = state;
            City = city;
            Neighborhood = neighborhood;
            Complement = complement;
        }
    }
}
