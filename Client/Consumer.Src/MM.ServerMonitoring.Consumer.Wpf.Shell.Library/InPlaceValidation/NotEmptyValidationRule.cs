using System.Globalization;
using System.Windows.Controls;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Library.InPlaceValidation;

public class NotEmptyValidationRule : ValidationRule
{
    public bool IsEnabled { get; set; }

    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        if (!IsEnabled)
            return ValidationResult.ValidResult;
        if (value == null)
            return new ValidationResult(false, "required");
        if (value is string)
            if (string.IsNullOrEmpty((string)value))
                return new ValidationResult(false, "required");
        return ValidationResult.ValidResult;
    }
}