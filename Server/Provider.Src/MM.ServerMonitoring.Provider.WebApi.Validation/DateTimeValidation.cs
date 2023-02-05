using LanguageExt;
using MM.ServerMonitoring.Provider.WebApi.Infrastructure.Validation;
using MM.ServerMonitoring.Repository.EntityFramework.Model.Interfaces;

namespace MM.ServerMonitoring.Provider.WebApi.Validation;

public class DateTimeValidation<TEntity> where TEntity : class, IHasId
{
    private static readonly string mustBeGreaterThan = "must be greater than";

    public static Option<ValidationMessage> MustBeGreaterThan(DateTime property1, string nameOf1, DateTime property2,
        string nameOf2)
    {
        if (property1 < property2)
            return new ValidationMessage
            {
                TargetPath = nameOf1,
                Message = $"{nameOf1} ({property1.ToString()}) {mustBeGreaterThan} {nameOf2} ({property2.ToString()})"
            };
        return Option<ValidationMessage>.None;
    }
}