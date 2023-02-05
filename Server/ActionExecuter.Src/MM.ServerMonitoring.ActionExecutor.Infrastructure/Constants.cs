namespace MM.ServerMonitoring.ActionExecutor.Infrastructure;

public static class Constants
{
    public class ParameterNames
    {
        public const string IP = "IP";
        public const string Url = "Url";
    }

    public class ActionNames
    {
        public const string Ping = "Ping";
        public const string HttpRequest = "HttpRequest";
    }

    public class ActionIds
    {
        public static readonly Guid Ping = new("86e8c90c-e44e-45b7-a79c-23db2f7d134b");
        public static readonly Guid HttpRequest = new("0CED0C93-F19E-48F1-A3C0-9E65CA127C44");
    }
}