namespace primeiraApi.Services;

public interface ISaltProtector
{
    string Protect(string salt);
    string Unprotect(string protectedSalt);
}
