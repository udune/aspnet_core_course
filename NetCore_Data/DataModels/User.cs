namespace NetCore_Data.DataModels;

public class User
{
    public string UserId { get; set; }
    public string Username { get; set; }
    public string UserEmail { get; set; }
    public string Password { get; set; }
    public DateTime JoinedUtcDate { get; set; }
}