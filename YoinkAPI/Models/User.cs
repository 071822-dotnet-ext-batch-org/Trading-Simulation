namespace Models;

/// <summary>
/// This is the Model to create a new User - contains UserID, Role, DateCreated, DateModified
/// </summary>
public class User
{
    public string? UserID { get; set; }
    public int? Role { get; set; }
    public DateTime? DateCreated { get; set; }
    public DateTime? DateModified { get; set; }

    /// <summary>
    /// This is the Constructor to create a new User that is empty
    /// </summary>
    public User()
    {
    }

    /// <summary>
    /// This is the Constructor to create a new User - contains UserID, Role, DateCreated, DateModified
    /// </summary>
    /// <param name="userID"></param>
    /// <param name="role"></param>
    /// <param name="dateCreated"></param>
    /// <param name="dateModified"></param>
    public User(string? userID, int? role, DateTime? dateCreated, DateTime? dateModified)
    {
        this.UserID = userID;
        this.Role = role;
        this.DateCreated = dateCreated;
        this.DateModified = dateModified;
    }


}
