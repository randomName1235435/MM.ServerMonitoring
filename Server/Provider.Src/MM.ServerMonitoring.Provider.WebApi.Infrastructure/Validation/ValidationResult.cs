namespace MM.ServerMonitoring.Provider.WebApi.Infrastructure.Validation;

[Serializable]
public struct ValidationResult
{
    private readonly List<ValidationMessage> messages;

    public ValidationResult()
    {
        this.messages = new List<ValidationMessage>();
    }

    public bool Success => !Messages.Any();
    public bool Failed => !Success;

    public IEnumerable<ValidationMessage> Messages => this.messages.ToArray();

    public void AddMessages(IEnumerable<ValidationMessage> messages)
    {
        this.messages.AddRange(messages);
    }

    public void AddMessage(ValidationMessage message)
    {
        this.messages.Add(message);
    }
}