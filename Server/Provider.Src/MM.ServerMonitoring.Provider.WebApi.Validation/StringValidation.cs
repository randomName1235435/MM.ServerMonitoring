using LanguageExt;
using MM.ServerMonitoring.Provider.WebApi.Infrastructure.Validation;

namespace MM.ServerMonitoring.Provider.WebApi.Validation;

public class StringValidation
{
    private static readonly string isRequired = "is required";
    private static readonly string maxLength = "max length is ";

    public static Option<ValidationMessage> RequiredFieldMaxLength(string property, int maxLength, string nameOf)
    {
        if (property == null)
            return new ValidationMessage { TargetPath = nameOf, Message = isRequired };
        if (property.Length > 1000)
            return new ValidationMessage { TargetPath = nameOf, Message = maxLength + maxLength.ToString() };
        return Option<ValidationMessage>.None;
    }
}