using ApiMongoDB.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ApiMongoDB.Services
{
    public class UsuarioService
    {
        private readonly IMongoCollection<UsuarioTeste> _usuarioColletion;

        public UsuarioService(IOptions<ConfigBase> usuarioService)
        {
            var mongoClient = new MongoClient(usuarioService.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(usuarioService.Value.DataBaseName);

            _usuarioColletion = mongoDatabase.GetCollection<UsuarioTeste>(usuarioService.Value.ProdutoCollectionName);

        }

        public async Task<List<UsuarioTeste>> GetAsync() =>
            await _usuarioColletion.Find(x => true).ToListAsync();

        public async Task<UsuarioTeste> GetAsync(string id) =>
            await _usuarioColletion.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreatAsync(UsuarioTeste usuarioTeste) =>
            await _usuarioColletion.InsertOneAsync(usuarioTeste);

        public async Task UpdateAsync(string id, UsuarioTeste usuarioTeste) =>
            await _usuarioColletion.ReplaceOneAsync(x => x.Id == id, usuarioTeste);

        public async Task RemoveAsync(string id) =>
            await _usuarioColletion.DeleteOneAsync(x => x.Id == id);
    }
}
