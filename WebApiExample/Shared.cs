namespace WebApiExample;

public static class Shared
{
    public static byte[] Key { get; } = "rQRJj5OcbgdXd5V5+yR3ekQ6SyV06ryxMTZKxiCAQz0"u8.ToArray();
    public static string Audience { get; } = "TestWebApiAudience";
    public static string Issuer { get; } = "TestWebApiIssuer";
    public static int DurationSeconds { get;  } = 60 * 20;
}