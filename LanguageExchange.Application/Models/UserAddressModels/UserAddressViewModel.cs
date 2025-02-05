using LanguageExchange.Core.Entities;

namespace LanguageExchange.Application.Models.UserAddressModels
{
    public class UserAddressViewModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Zipcode { get; set; }
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Neighborhood { get; set; }
        public string Complement { get; set; }

        public static UserAddressViewModel FromEntity(UserAddress address)
        {
            var viewModel = new UserAddressViewModel
            {
                Id = address.Id,
                UserId = address.UserId,
                Zipcode = address.Zipcode,
                StreetName = address.StreetName,
                HouseNumber = address.HouseNumber,
                Country = address.Country,
                State = address.State,
                City = address.City,
                Neighborhood = address.Neighborhood,
                Complement = address.Complement
            };
            return viewModel;
        }
    }
}
