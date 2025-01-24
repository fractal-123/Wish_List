using Microsoft.AspNetCore.Identity;

public class PasswordService
{
    private readonly PasswordHasher<string> _passwordHasher;

    public PasswordService()
    {
        _passwordHasher = new PasswordHasher<string>();
    }

    /// <summary>
    /// Хэширует пароль.
    /// </summary>
    /// <param name="password">Исходный пароль.</param>
    /// <returns>Хэшированный пароль.</returns>
    public string HashPassword(string password)
    {
        return _passwordHasher.HashPassword(null, password);
    }

    /// <summary>
    /// Проверяет соответствие пароля и хэша.
    /// </summary>
    /// <param name="hashedPassword">Хэшированный пароль.</param>
    /// <param name="providedPassword">Исходный пароль для проверки.</param>
    /// <returns>True, если пароли совпадают, иначе False.</returns>
    public bool VerifyPassword(string hashedPassword, string providedPassword)
    {
        var result = _passwordHasher.VerifyHashedPassword(null, hashedPassword, providedPassword);
        return result == PasswordVerificationResult.Success;
    }
}