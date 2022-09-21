namespace Models;
public class User
{
    string? userID;
    int? role;
    DateTime? dateCreated;
    DateTime? dateModified;

    public User()
    {
    }

    public User(string? userID, int? role, DateTime? dateCreated, DateTime? dateModified)
    {
        this.userID = userID;
        this.role = role;
        this.dateCreated = dateCreated;
        this.dateModified = dateModified;
    }
}
