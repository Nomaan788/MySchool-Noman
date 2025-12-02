namespace MySchool.WebApi.ViewModels
{
    public class UserModel
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public int? RoleId { get; set; }
        public bool? SysAdmin { get; set; }
        public bool IsActive { get; set; }
    }
}
