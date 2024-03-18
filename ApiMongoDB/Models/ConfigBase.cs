namespace ApiMongoDB.Models
{
    public class ConfigBase
    {
        public string? ConnectionString { get; set; } = null;
        public string? DataBaseName { get; set;} = null;
        public string? ProdutoCollectionName { get; set;} = null ;
    }
}
