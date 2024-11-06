using System;
using System.Linq;

public static class CodeGenerator
{
    public static string GenerateRandomCode()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; // Chỉ có chữ cái viết hoa
        Random random = new Random();
        return new string(Enumerable.Repeat(chars, 8)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}
