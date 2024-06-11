using System.ComponentModel.DataAnnotations;

namespace CMSECommerce.Infrastructure.Validation;

public class DecimalFieldAttribute: ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        // Logica di validazione personalizzata
        if (value == null)
        {
            return new ValidationResult(ErrorMessage ?? "Il valore non può essere nullo.");
        }

        if (value is decimal decimalValue)
        {
            if (decimalValue < 0)
            {
                return new ValidationResult(ErrorMessage ?? "Il valore non può essere negativo.");
            }
        }
        else
        {
            return new ValidationResult(ErrorMessage ?? "Il valore deve essere un numero decimale.");
        }

        return ValidationResult.Success;
    }
}
