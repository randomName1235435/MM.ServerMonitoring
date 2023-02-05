namespace MM.ServerMonitoring.Provider.WebApi.Infrastructure.Validation;

[Serializable]
public struct ValidationMessage
{
    public string TargetPath;
    public string Message;
}