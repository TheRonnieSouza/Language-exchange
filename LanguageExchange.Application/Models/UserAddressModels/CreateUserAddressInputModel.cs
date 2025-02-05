
using LanguageExchange.Core.Entities;

namespace LanguageExchange.Application.Models.UserAddressModels
{
    public class CreateUserAddressInputModel
    {        
        public string Zipcode { get; set; }
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Neighborhood { get; set; }
        public string Complement { get; set; }

        public UserAddress ToEntity(Guid userId)=> new(userId, Zipcode, StreetName, HouseNumber, Country, State, City, Neighborhood, Complement);
    }
}
