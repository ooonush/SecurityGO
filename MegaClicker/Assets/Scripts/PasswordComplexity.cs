using System;

public class PasswordComplexity : MonoSingleton<PasswordComplexity>
{
    public enum Complexity
    {
        light,
        weak,
        medium,
        reliable
    }

    public Complexity GetComplexity(string password)
	{
		var complexity = 0;

        if (password.Length > 12) complexity++;
        if (ContainsDigit(password)) complexity++;
        if (ContainsLowerLetter(password)) complexity++;
        if (ContainsUpperLetter(password)) complexity++;
        if (ContainsSpecialCharacters(password)) complexity++;

    }

    private static bool ContainsLowerLetter(string password)
    {
        foreach (char symbol in password)
        {
            if ((Char.IsLetter(symbol)) && (Char.IsLower(symbol)))
                return true;
        }
        return false;
    }

    private static bool ContainsUpperLetter(string pass)
    {
        foreach (char symbol in pass)
        {
            if ((Char.IsLetter(symbol)) && (Char.IsUpper(symbol)))
                return true;
        }
        return false;
    }

    private static bool ContainsDigit(string pass)
    {
        foreach (char symbol in pass)
        {
            if (Char.IsDigit(symbol))
                return true;
        }
        return false;
    }

    private static bool ContainsSpecialCharacters(string pass)
    {
        var specialCharacters = new char[] 
        { '!', '@', '#', '$', '%', '^', '&', '*', 
          '(', ')', '-', '_', '+', '=', ';', ':', 
          ',', '.', '/', '?', '\', '|', '`', '~', 
          '[', ']', '{', '}', '.' 
        };

        if (pass.Contains(specialCharacters))
            return true;

        return false;
    }
}
