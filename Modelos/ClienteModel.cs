using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ConsoleMongoDB.Modelos
{
    public class ClienteModel
    {
        [BsonId]
        public ObjectId Id { get; set; }
        
        public string Nombre { get; set; }

        public string Email { get; set; }
    }
}
