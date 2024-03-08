namespace JwtBearer.Models
{
    public record User
    (
        int id,
        string email,
        string password,

        //perfils usuario
        string[] Roles);
}
