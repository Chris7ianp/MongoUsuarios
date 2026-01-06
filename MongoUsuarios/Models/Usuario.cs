using MongoDB.Bson.Serialization.Attributes;

namespace MongoUsuarios.Models
{
    public class Usuario
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("nome")]
        public string Nome { get; set; }
        [BsonElement("email")]
        public string Email { get; set; }
        [BsonElement("idade")]
        public int Idade { get; set; }
    }
}
