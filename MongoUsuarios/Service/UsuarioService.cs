using MongoDB.Driver;
using MongoUsuarios.Models;

namespace MongoUsuarios.Service
{
    public class UsuarioService
    {
        private readonly IMongoCollection<Usuario> _usuarios;

        public UsuarioService(IConfiguration config)
        {
            var client = new MongoClient(config["MongoDB:ConnectionString"]);
            var database = client.GetDatabase(config["MongoDB:Database"]);
            _usuarios = database.GetCollection<Usuario>("usarios");
        }

        public List<Usuario> Get() => _usuarios.Find(u => true).ToList();

        public Usuario Get(string id) => _usuarios.Find(u => u.Id == id).FirstOrDefault();

        public Usuario Create(Usuario usuario)
        {
            _usuarios.InsertOne(usuario);
            Console.WriteLine($"Usuário salvo: {usuario.Nome}, {usuario.Email}, {usuario.Idade}");
            return usuario;
        }

        public void Update(string id, Usuario usuario) => _usuarios.ReplaceOne(u => u.Id == id, usuario);

        public void Delete(string id) => _usuarios.DeleteOne(u => u.Id == id);
    }
}
