using System;

class PasswordComplexity
{
    public enum Complexity
    {
        light,
        weak,
        medium,
        reliable
    }

    public static Complexity GetComplexity(string password)
	{
		var complexity = 0;

        if (password.Length > 12) complexity++;
        if (ContainsDigit(password)) complexity++;
        if (ContainsLowerLetter(password)) complexity++;
        if (ContainsUpperLetter(password)) complexity++;
        if (ContainsSpecialCharacters(password)) complexity++;

        return (Complexity)complexity;
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

    private static bool ContainsSpecialCharacters(string password)
    {
        var specialCharacters = new string[] 
        { "!", "@", "#", "$", "%", "^", "&", "*", 
          "(", ")", "-", "_", "+", "=", ";", ":", 
          ",", ".", "/", "?", "\\", "|", "`", "~", 
          "[", "]", "{", "}", "." 
        };

        foreach (var characters in specialCharacters)
        {
            if (password.Contains(characters))
                return true;
        }

        return false;
    }
}
