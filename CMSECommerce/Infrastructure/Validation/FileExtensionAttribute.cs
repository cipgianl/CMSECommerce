﻿using System.ComponentModel.DataAnnotations;

namespace CMSECommerce.Infrastructure.Validation;

public class FileExtensionAttribute: ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName);
            string[] extentions = { "jpg", "png" };
            bool result = extentions.Any(x => extension.EndsWith(x));

            if (!result)
            {
                return new ValidationResult("Allowed extensions are jpg and png!");
            }
        }

        return ValidationResult.Success;
    }
}
