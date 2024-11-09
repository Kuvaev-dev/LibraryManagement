namespace LibraryManagementApp.models
{
    public class AuthenticationResult
    {
        public bool IsSuccess { get; set; }
        public string FullName { get; set; }
        public string Status { get; set; }
        public string ErrorMessage { get; set; }
        public int MemberId { get; set; }
    }
}