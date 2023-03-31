namespace Permit.Application.Common
{
    public static class AppEnvironment
    {
        public const string Development = "Development";
        public const string Staging = "Staging";
        public const string Production = "Production";

        public static string GetCurrentEnvironment()
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            return env ?? Development;
        }
    }
}
