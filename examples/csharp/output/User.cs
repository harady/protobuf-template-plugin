// This file is auto-generated. Do not edit manually.

public enum UserRole
{
    USER_ROLE_UNSPECIFIED = 0,
    USER_ROLE_GUEST = 1,
    USER_ROLE_MEMBER = 2,
    USER_ROLE_ADMIN = 3,
}

public class User
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public UserRole Role { get; set; }
    public string[] Tags { get; set; }
}

public class GetUserRequest
{
    public long Id { get; set; }
}

public class GetUserResponse
{
    public User User { get; set; }
}
