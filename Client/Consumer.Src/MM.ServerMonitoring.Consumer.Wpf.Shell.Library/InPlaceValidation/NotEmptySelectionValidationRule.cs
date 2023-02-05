using System.Globalization;
using System.Windows.Controls;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Library.InPlaceValidation;

public class NotEmptySelectionValidationRule : ValidationRule
{
    public bool IsEnabled { get; set; }

    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        if (!IsEnabled)
            return ValidationResult.ValidResult;
        if (value == null) return new ValidationResult(false, "required");
        return ValidationResult.ValidResult;
    }
}