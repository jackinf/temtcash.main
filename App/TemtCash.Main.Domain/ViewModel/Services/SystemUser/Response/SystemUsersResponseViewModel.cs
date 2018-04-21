namespace TemtCash.Main.Domain.ViewModel.Services.SystemUser
{
    public class SystemUsersResponseViewModel
    {
        public int Id { get; set; }
        public string UsernameOrEmail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LastLoginTime { get; set; }
    }
}