using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ConsoleMongoDB.Modelos
{
    public class OrdenModel
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public DateTime FechaOrden { get; set; }

        public List<string> Items { get; set; }

        public decimal Total { get; set; }

    }
}
