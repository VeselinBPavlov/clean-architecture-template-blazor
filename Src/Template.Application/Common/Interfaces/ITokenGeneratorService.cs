namespace Template.Application.Common.Interfaces
{
    public interface ITokenGeneratorService
    {
        string GenerateToken(User user, IEnumerable<string>? roles = null);
    }
}
