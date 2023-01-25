namespace QuizApp_BL.Services.HashService
{
    public interface IHashService
    {
        string GetHash(string password);
        bool ValidateHash(string password, string hash);
    }
}