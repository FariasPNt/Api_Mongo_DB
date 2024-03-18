using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;
using ApiMongoDB.Validations;


namespace ApiMongoDB.Models
{
    public class UsuarioTeste
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        
        [Required(ErrorMessage ="Insira o nome completo")]
        [StringLength(30, ErrorMessage ="Maximo 30 caracteres", MinimumLength =5)]
        [RegularExpression(@"^[a-zA-ZÀ-ÖØ-öø-ÿ]+(?:['\s][a-zA-ZÀ-ÖØ-öø-ÿ]+)*$")]
        public string? NomeCompleto { get; set; }
        
        
        public int Idade { get; set; }



        //[cpfValido]
        [Required(ErrorMessage = "Campo CPF é obrigatório")]
        [RegularExpression(@"^\d{11}$", ErrorMessage ="Insira apenas números. CPF inválido")]
        public long CPF { get; set; }
        
        
        [Required(ErrorMessage ="Campo Data de Nascimento é obrigatório")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public string? DataNascimento { get; set; }

       
        public Int64 Telefone { get; set; }
        
        
        public string? Sexo { get; set; }
        
        
        [Required(ErrorMessage ="O email é obrigatório")]
        [RegularExpression(@"^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$", ErrorMessage = "Informe um email válido")]
        public string? Email { get; set; }
        
        
        [Required(ErrorMessage ="Insira um usuário")]
        [MinLength(4, ErrorMessage = "O login deve ter 4 ou mais caracteres")]
        public string? Login { get; set; }
        
        
        [Required(ErrorMessage ="Campo obrigatório")]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage ="A senha deve conter 8 caracteres. Letra minuscula, maiuscula, numero e caracter especial")]
        public string? Senha { get; set; }
        
        
        [Compare("Senha")]
        public string? ConfirmaSenha { get; set; }


        public int Status { get; set; }
        public bool Ativo { get; set; } = true;
    }
}
