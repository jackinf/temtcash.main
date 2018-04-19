using System;

namespace SpeysCloud.Main.Domain.ViewModel.Services.AddressBook
{
    public class AddressesResponseViewModel
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Contact { get; set; }
        public DateTime? CreationDate { get; set; }

        public string CityCountry => $"{City} - {Country}";
    }
}