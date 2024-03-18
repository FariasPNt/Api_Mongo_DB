using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace ApiMongoDB.Validations;

public class cpfValidoAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value,
        ValidationContext validationContext)
    
    {


        if (value == null || string.IsNullOrEmpty(value.ToString()))
        {
            return new ValidationResult("Insira um cpf válido");

        }

        var cpfCaracter = value.ToString()[0].ToString();

        if (cpfCaracter.Length > 15)
        {
            return new ValidationResult("CPF inválido");
        }


        if (cpfCaracter.Contains(".") || cpfCaracter.Contains("-"))
        {
            RemoverCaracteresEspeciais(cpfCaracter);
            //return ValidationResult.Success;
        }
        
        if (cpfCaracter.Length < 15) 
        {
            ConverterValor(cpfCaracter);
          
        }

        return ValidationResult.Success;





        static string RemoverCaracteresEspeciais(string value)
        {
            // Remove os pontos e traços
            value = value.Replace(".", "").Replace("-", "");
            return value;
        }

        static long ConverterValor(string value)
        {
            // Transforma em Numero
            long cpfValor = long.Parse(value);
            return cpfValor;
        }

    }
}
