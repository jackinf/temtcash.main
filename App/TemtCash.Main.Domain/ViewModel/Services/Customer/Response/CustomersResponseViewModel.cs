using System;

namespace TemtCash.Main.Domain.ViewModel.Services.Customer.Response
{
    public class CustomersResponseViewModel
    {
        public int Id { get; set; }
        public string UsernameOrEmail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public bool CompanysMainUser { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public bool IsActive { get; set; }
    }
}