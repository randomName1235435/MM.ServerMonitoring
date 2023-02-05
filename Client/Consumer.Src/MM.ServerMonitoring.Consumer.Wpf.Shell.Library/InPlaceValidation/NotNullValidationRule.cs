using System.Collections;
using System.Globalization;
using System.Windows.Controls;

namespace MM.ServerMonitoring.Consumer.Wpf.Shell.Library.InPlaceValidation;

public class NotNullValidationRule : ValidationRule
{
    public bool IsEnabled { get; set; }

    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        if (!IsEnabled)
            return ValidationResult.ValidResult;

        if (value is null) return new ValidationResult(false, "required");
        if (value is DateTime)
            return ValidationResult.ValidResult;

        if (value is IList && ((IList)value).Count > 0)
            return ValidationResult.ValidResult;

        return new ValidationResult(false, "required");
    }
}