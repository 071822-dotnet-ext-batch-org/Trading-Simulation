

namespace Models;
public class Users
{

    string? userID;
    int? role;
    DateTime? dateCreated;
    DateTime? dateModified;

    public Users()
    {
    }

    public Users(string? userID, int? role, DateTime? dateCreated, DateTime? dateModified)
    {
        this.userID = userID;
        this.role = role;
        this.dateCreated = dateCreated;
        this.dateModified = dateModified;
    }
}
