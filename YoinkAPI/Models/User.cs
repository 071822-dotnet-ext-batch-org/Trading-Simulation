namespace Models;
public class User
{
    public string? UserID { get; set; }
    public int? Role { get; set; }
    public DateTime? DateCreated { get; set; }
    public DateTime? DateModified { get; set; }

    public User()
    {
    }

    public User(string? userID, int? role, DateTime? dateCreated, DateTime? dateModified)
    {
        this.UserID = userID;
        this.Role = role;
        this.DateCreated = dateCreated;
        this.DateModified = dateModified;
    }
}
