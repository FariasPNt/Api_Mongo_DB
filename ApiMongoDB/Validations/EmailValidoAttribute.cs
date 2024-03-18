using System.ComponentModel.DataAnnotations;

namespace ApiMongoDB.Validations;

public class EmailValidoAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, 
        ValidationContext validationContext)
    {
        if (value == null || string.IsNullOrEmpty(value.ToString()))
        {
            return ValidationResult.Success;
        }

        string emailValido = value.ToString();
        if (emailValido.Contains(".com"))
        {
            return ValidationResult.Success;
        }
        else
        {
            return new ValidationResult("O email não é válido");
        }
    }
}
