using System;
using System.Text.RegularExpressions;

public class Smartphone : IBrowseable, ICallable
{
    public string Browse(string url)
    {
        var pattern = "\\d+";
        Regex rgx = new Regex(pattern);
        Match match = rgx.Match(url);

        if (match.Success)
        {
            throw new ArgumentException("Invalid URL!");
        }

        return $"Browsing: {url}!";
    }

    public string Call(string phoneNumber)
    {
        var pattern = "^[0-9]*$";
        Regex rgx = new Regex(pattern);
        Match match = rgx.Match(phoneNumber);

        if (!match.Success)
        {
            throw new ArgumentException("Invalid number!");
        }

        return $"Calling... {phoneNumber}";
    }
}