namespace AirBnB.Infrastructure.Extensions;

public static class FileExtension
{
    public static string ToUrl(this string path, string? prefix = default) => $"{prefix + "/"}{path.Replace("\\", "/")}";
}