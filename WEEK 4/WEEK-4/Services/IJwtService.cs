namespace MyWebApi.Services
{
    public interface IJwtService
    {
        string GenerateToken(int userId, string userRole);
    }
}
