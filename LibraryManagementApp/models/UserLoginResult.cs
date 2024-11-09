namespace LibraryManagementApp.models
{
    public class UserLoginResult
    {
        public bool IsSuccess { get; set; }
        public string FullName { get; set; }
        public string Status { get; set; }
        public string ErrorMessage { get; set; }
    }
}